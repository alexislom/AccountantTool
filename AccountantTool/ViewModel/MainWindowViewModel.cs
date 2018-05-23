using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;
using AccountantTool.Common;
using AccountantTool.Helpers;
using AccountantTool.Helpers.Search;
using AccountantTool.Model;
using AccountantTool.ReoGrid.CustomDropDownCell;
using AccountantTool.ReoGrid.DataFormatter;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using unvell.ReoGrid;
using unvell.ReoGrid.DataFormat;
using unvell.ReoGrid.IO;

namespace AccountantTool.ViewModel
{
    public class MainWindowViewModel : ViewModelBase, IAccountantRecordSearch
    {
        #region Fields
        private readonly object _accountantRecordsLock = new object();
        private string _searchString;
        #endregion Fields

        #region Properties
        public ObservableCollection<AccountantRecord> AccountantRecords { get; set; }
        public Worksheet Worksheet { get; }
        public bool IsEnglishLanguage => App.SelectedLanguage.Equals(App.Languages[0]);
        public ICollectionView<AccountantRecord> FilteredAccountantRecords { get; }
        public string SearchString
        {
            get => _searchString;
            set
            {
                _searchString = value;
                OnPropertyChanged();

                if (string.IsNullOrWhiteSpace(value))
                {
                    FilteredAccountantRecords.Filter = null;

                    RefreshFilteredRecords(AccountantRecords);
                }
                else
                {
                    Task.Run(() =>
                    {
                        Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            FilteredAccountantRecords.Filter = obj => Filter(obj, value);
                        }), DispatcherPriority.Background);
                    });
                    if (!FilteredAccountantRecords.IsEmpty)
                    {
                        RefreshFilteredRecords(FilteredAccountantRecords);
                    }
                }
            }
        }

        private bool Filter(object obj, string value)
        {
            var recordString = ((AccountantRecord)obj).ToString().ToLower();
            return recordString.Contains(value.ToLower());

            #region RegExp try
            //const string pattern = "\"(.*?)\"";
            //var regex = new Regex(pattern);
            //MatchCollection matchCollection = regex.Matches(recordString);

            //foreach (Match match in matchCollection)
            //{
            //    if (match.ToString().ToLower().Contains(value.ToLower()))
            //        return true;
            //}

            //return false;
            #endregion RegExp try
        }

        private bool FilterBy(object obj, string value, string propertyName)
        {
            var filteredProperty = obj.GetType().GetProperty(propertyName, BindingFlags.Public
                                                                           | BindingFlags.Instance
                                                                           | BindingFlags.IgnoreCase);
            if (filteredProperty == null)
                return false;

            var recordString = filteredProperty.GetValue(obj, null).ToString().ToLower();
            return recordString.Contains(value.ToLower());
        }

        private void RefreshFilteredRecords(IEnumerable<AccountantRecord> collection)
        {
            Worksheet.ClearRangeContent(RangePosition.EntireRange, CellElementFlag.All);

            var rowIndex = 0;

            foreach (var filteredAccountantRecords in collection)
            {
                AddRecord(rowIndex, filteredAccountantRecords);
                rowIndex++;
            }
        }

        #endregion Properties

        #region Commands
        public ICommand ChangeLanguageCommand { get; }
        public ICommand LoadDataCommand { get; }
        public ICommand AddNewRecordCommand { get; }
        public ICommand DeleteRecordCommand { get; }
        public ICommand SaveDocumentCommand { get; }
        public ICommand ExportToExcelCommand { get; }
        #endregion Commands

        #region Construction

        public MainWindowViewModel(Worksheet mainGrid)
        {
            Worksheet = mainGrid;

            AccountantRecords = new ObservableCollection<AccountantRecord>();

            BindingOperations.EnableCollectionSynchronization(AccountantRecords, _accountantRecordsLock);
            FilteredAccountantRecords = new CollectionViewGeneric<AccountantRecord>(CollectionViewSource.GetDefaultView(AccountantRecords));

            ChangeLanguageCommand = new RelayCommand(ChangeLanguage);
            LoadDataCommand = new AsyncDelegateCommand(OnLoadData);
            AddNewRecordCommand = new AsyncDelegateCommand(OnAddNewRecord);
            DeleteRecordCommand = new AsyncDelegateCommand(OnDeleteRecord, CanExecuteOperation);
            SaveDocumentCommand = new RelayCommand(OnSaveDocument, CanExecuteOperation);
            ExportToExcelCommand = new RelayCommand(OnExportToExcel, CanExecuteOperation);

            InitializeWorksheet();
        }

        #endregion Construction

        #region Commands implementation

        private bool CanExecuteOperation(object param) => AccountantRecords.Count >= 1 && Worksheet.RowCount > 1;

        private void ChangeLanguage()
        {
            App.SelectedLanguage = IsEnglishLanguage ? new CultureInfo("ru-RU") : new CultureInfo("en-US");
            InitializeHeaders();
        }

        private static void SaveDefaultFileNameSetting(string fileName)
        {
            Properties.Settings.Default.LastFileName = fileName;
            Properties.Settings.Default.Save();
        }

        private async Task OnAddNewRecord(object param)
        {
            // TODO: Refactor this
            var id = Guid.NewGuid();
            var newEmptyRecord = new AccountantRecord
            {
                Id = id,
                Company = new Company { ParentId = id },
                Requisites = new Requisites(),
                ContactPersons = new List<ContactPerson>(),
                License = new List<License>(),
                Products = new List<Product>(),
                Contract = new Contract(),
                AdditionalInfo = new AdditionalInfo()
            };

            var rowIndexToInsertNewRecord = AccountantRecords.Count;

            AccountantRecords.Add(newEmptyRecord);

            if (Worksheet.RowCount == AccountantRecords.Count)
            {
                Worksheet.AppendRows(Constants.CountOfRowsToAdd);
            }

            await Task.Run(() =>
            {
                AddRecord(rowIndexToInsertNewRecord, newEmptyRecord);
            });
        }

        private async Task OnDeleteRecord(object o)
        {
            for (int i = 0, index = Worksheet.SelectionRange.Row; i < Worksheet.SelectionRange.Rows; i++, index++)
            {
                var companyCell = Worksheet.GetCell(index, Constants.CompanyColumnIndex);

                if (companyCell != null)
                {
                    var recordToRemove = AccountantRecords.FirstOrDefault(s => s.Id == companyCell.GetData<Company>().ParentId);
                    await Task.Run(() =>
                    {
                        AccountantRecords.Remove(recordToRemove);
                    });
                }
            }

            Worksheet.DeleteRows(Worksheet.SelectionRange.Row, Worksheet.SelectionRange.Rows);
        }

        public async Task RestoreLastFile(string defaultLastFileName)
        {
            await LoadRecords(defaultLastFileName);
        }

        private async Task OnLoadData(object param)
        {
            var openFileDialog = new OpenFileDialog
            {
                RestoreDirectory = Constants.FileDialogRestoreDirectory,
                Filter = Constants.SaveFileDialogFilter
            };

            if (openFileDialog.ShowDialog() == true)
            {
                await LoadRecords(openFileDialog.FileName);
                SaveDefaultFileNameSetting(openFileDialog.FileName);
            }
        }

        private async Task LoadRecords(string filePath)
        {
            Worksheet.Workbook.Load($"{filePath}", FileFormat.ReoGridFormat);

            SetWorksheetSettings();

            AccountantRecords.Clear();

            for (var rowIndex = 0; rowIndex <= Worksheet.RowCount; rowIndex++)
            {
                var accountantRecord = new AccountantRecord();

                for (var columnIndex = Constants.CompanyColumnIndex; columnIndex < Constants.CountOfColumns; columnIndex++)
                {
                    var cell = Worksheet.GetCell(rowIndex, columnIndex);
                    // TODO: REFACTOR THIS???!!!
                    if (cell == null)
                        return;

                    SetRecordData(cell, accountantRecord, columnIndex);
                }

                var rowIndexClosure = rowIndex;
                await Task.Run(() =>
                {
                    AccountantRecords.Add(accountantRecord);

                    AddRecord(rowIndexClosure, AccountantRecords.Last());
                });
            }
        }

        private void OnSaveDocument()
        {
            var saveFileDialog = new SaveFileDialog
            {
                RestoreDirectory = Constants.FileDialogRestoreDirectory,
                Filter = Constants.SaveFileDialogFilter,
                Title = IsEnglishLanguage ? "Save input data" : "Сохранить введённые данные"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                Worksheet.Workbook.Save($"{saveFileDialog.FileName}", FileFormat.ReoGridFormat);

                SaveDefaultFileNameSetting(saveFileDialog.FileName);

                MessageBox.Show($"{(IsEnglishLanguage ? "File save as:" : "Файл сохранён как:")}" + Environment.NewLine +
                                saveFileDialog.FileName, $"{(IsEnglishLanguage ? "Save input data" : "Сохранить введённые данные")}",
                                MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void OnExportToExcel()
        {
            var exportFileDialog = new SaveFileDialog
            {
                RestoreDirectory = Constants.FileDialogRestoreDirectory,
                Filter = Constants.ExportFileDialogFilter,
                Title = IsEnglishLanguage ? "Export to excel" : "Экспорт в эксель"
            };

            if (exportFileDialog.ShowDialog() != true)
                return;

            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Inserting Data");

            var row = 1;
            const int column = 1;

            foreach (var record in AccountantRecords)
            {
                // Name of company
                worksheet.Cell(row, column).Value = "Название компании";
                worksheet.Range(row, column, row, column + 4).Merge().AddToNamed("Titles");

                row++;

                worksheet.Cell(row, column).Value = record.Company.LongName;
                worksheet.Range(row, column, row, column + 4).Merge().Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                row++;

                // Requisites
                worksheet.Cell(row, column).Value = "Реквизиты:";
                worksheet.Range(row, column, row, column + 4).Merge().AddToNamed("Titles");

                row++;

                worksheet.Cell(row, column).Value = "Адрес:";

                row++;

                var addressList = new List<string>
                    {
                        record.Requisites.Address.Index,
                        record.Requisites.Address.Country,
                        record.Requisites.Address.Region,
                        record.Requisites.Address.District,
                        record.Requisites.Address.City,
                        record.Requisites.Address.Street,
                        record.Requisites.Address.House,
                        record.Requisites.Address.Flat
                    };
                worksheet.Cell(row, column).Value = string.Join(", ", addressList.Where(x => x != string.Empty));
                worksheet.Cell(row, column).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                worksheet.Range(row, column, row, column + 4).Merge().AddToNamed("SubTitles");

                row++;

                worksheet.Cell(row, column).Value = "Адрес электронной почты:";
                worksheet.Cell(row, column + 1).Value = record.Requisites.Email;

                row++;

                worksheet.Cell(row, column).Value = "Сайт:";
                worksheet.Cell(row, column + 1).Value = record.Requisites.Site;
                worksheet.Cell(row, column + 1).Hyperlink = 
                    new XLHyperlink(record.Requisites.Site.StartsWith("http:") ? record.Requisites.Site : "http://" + record.Requisites.Site);

                row++;

                worksheet.Cell(row, column).Value = "Контактные телефоны:";
                worksheet.Range(row, column, row, column + 4).Merge().Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                row++;

                var contactPhonesRange = worksheet.Cell(row, column).InsertData(record.Requisites.DepartmentPhones.AsEnumerable());
                if (contactPhonesRange != null)
                {
                    row += contactPhonesRange.RowCount();
                }

                worksheet.Cell(row, column).Value = "Иные реквизиты:";
                worksheet.Range(row, column, row, column + 4).Merge().Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                row++;

                var contactOtherRequisites = worksheet.Cell(row, column).InsertData(record.Requisites.OtherRequisites.AsEnumerable());

                if (contactOtherRequisites != null)
                {
                    row += contactOtherRequisites.RowCount();
                }

                // Contact persons
                worksheet.Cell(row, column).Value = "Контактные лица";
                worksheet.Range(row, column, row, column + 4).Merge().AddToNamed("Titles");

                row++;
                if (record.ContactPersons.Any())
                {
                    var contactPersons = worksheet.Cell(row, column).InsertData(record.ContactPersons.AsEnumerable());

                    row += contactPersons.RowCount();
                }

                // License
                worksheet.Cell(row, column).Value = "Наличие лицензии и сроки";
                worksheet.Range(row, column, row, column + 4).Merge().AddToNamed("Titles");

                row++;

                if (record.License.Any())
                {
                    var license = worksheet.Cell(row, column).InsertData(record.License.AsEnumerable());

                    row += license.RowCount();
                }

                // Products
                worksheet.Cell(row, column).Value = "Покупаемые изделия и стоимость";
                worksheet.Range(row, column, row, column + 4).Merge().AddToNamed("Titles");

                row++;

                if (record.Products.Any())
                {
                    var products = worksheet.Cell(row, column).InsertData(record.Products.AsEnumerable());

                    row += products.RowCount();
                }

                // Contract
                worksheet.Cell(row, column).Value = "Исполнение контракта";
                worksheet.Range(row, column, row, column + 4).Merge().AddToNamed("Titles");

                row++;

                IEnumerable<Contract> contract = new List<Contract> { record.Contract };

                var contractCell = worksheet.Cell(row, column).InsertData(contract);

                row += contractCell.RowCount();

                // Additional info
                worksheet.Cell(row, column).Value = "Дополнительная информация";
                worksheet.Range(row, column, row, column + 4).Merge().AddToNamed("Titles");

                row++;

                worksheet.Cell(row, column).Value = record.AdditionalInfo.Notes;

                worksheet.Columns().AdjustToContents();

                // End of record info, setting page break and add row
                worksheet.PageSetup.AddHorizontalPageBreak(row);
                row++;
            }

            var titlesStyle = workbook.Style;
            titlesStyle.Font.Bold = true;
            titlesStyle.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            workbook.NamedRanges.NamedRange("Titles").Ranges.Style = titlesStyle;

            worksheet.Columns().AdjustToContents();

            workbook.SaveAs($"{exportFileDialog.FileName}");

            MessageBox.Show($"{(IsEnglishLanguage ? "File save as:" : "Файл сохранён как:")}" + Environment.NewLine +
                            exportFileDialog.FileName, $"{(IsEnglishLanguage ? "Export to excel" : "Экспорт в эксель")}",
                            MessageBoxButton.OK, MessageBoxImage.Information);

        }

        #endregion Commands implementation

        #region Work with worksheet

        private static void SetRecordData(Cell cell, AccountantRecord accountantRecord, int columnIndex)
        {
            switch (columnIndex)
            {
                case Constants.CompanyColumnIndex:
                    var company = cell.GetData<Company>();
                    accountantRecord.Company = company;
                    accountantRecord.Id = company.ParentId;
                    break;
                case Constants.RequisitesColumnIndex:
                    var requisites = cell.GetData<Requisites>();
                    accountantRecord.Requisites = requisites;
                    break;
                case Constants.ContactPersonColumnIndex:
                    var contactPersons = cell.GetData<ListWrapper<ContactPerson>>();
                    accountantRecord.ContactPersons = new List<ContactPerson>(contactPersons.Context.Count);
                    accountantRecord.ContactPersons.AddRange(contactPersons.Context);
                    break;
                case Constants.LicenseColumnIndex:
                    var license = cell.GetData<ListWrapper<License>>();
                    accountantRecord.License = new List<License>(license.Context.Count);
                    accountantRecord.License.AddRange(license.Context);
                    break;
                case Constants.ProductsColumnIndex:
                    var products = cell.GetData<ListWrapper<Product>>();
                    accountantRecord.Products = new List<Product>(products.Context.Count);
                    accountantRecord.Products.AddRange(products.Context);
                    break;
                case Constants.ContractColumnIndex:
                    var contract = cell.GetData<Contract>();
                    accountantRecord.Contract = contract;
                    break;
                case Constants.AdditionalInfoColumnIndex:
                    var addInfo = cell.GetData<AdditionalInfo>();
                    accountantRecord.AdditionalInfo = addInfo;
                    break;
            }
        }

        private void InitializeWorksheet()
        {
            Worksheet.Columns = Constants.CountOfColumns;
            Worksheet.SelectionMode = WorksheetSelectionMode.Row;
            SetWorksheetSettings();

            InitializeHeaders();

            DataFormatterManager.Instance.DataFormatters.Add(CellDataFormatFlag.Custom, new AccountantToolDataFormatter());
            Worksheet.SetColumnsWidth(Constants.CompanyColumnIndex, Constants.CountOfColumns, Constants.ColumnsWidth);
        }

        private void SetWorksheetSettings()
        {
            Worksheet.SetSettings(WorksheetSettings.Edit_Readonly, Constants.EditReadonly);
        }

        private void AddRecord(int row, AccountantRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            Worksheet.SetCellData(row, Constants.CompanyColumnIndex, record.Company);
            Worksheet.SetCellBody(row, Constants.CompanyColumnIndex, new CompanyListViewDropdownCell(record.Company));

            Worksheet.SetCellData(row, Constants.RequisitesColumnIndex, record.Requisites);
            Worksheet.SetCellBody(row, Constants.RequisitesColumnIndex, new RequisitesListViewDropdownCell(record.Requisites));

            Worksheet.SetCellData(row, Constants.ContactPersonColumnIndex, new ListWrapper<ContactPerson>(record.ContactPersons));
            Worksheet.SetCellBody(row, Constants.ContactPersonColumnIndex, new ContactPersonListViewDropdownCell(record.ContactPersons));

            Worksheet.SetCellData(row, Constants.LicenseColumnIndex, new ListWrapper<License>(record.License));
            Worksheet.SetCellBody(row, Constants.LicenseColumnIndex, new LicenseListViewDropdownCell(record.License));

            Worksheet.SetCellData(row, Constants.ProductsColumnIndex, new ListWrapper<Product>(record.Products));
            Worksheet.SetCellBody(row, Constants.ProductsColumnIndex, new ProductsListViewDropdownCell(record.Products));

            Worksheet.SetCellData(row, Constants.ContractColumnIndex, record.Contract);
            Worksheet.SetCellBody(row, Constants.ContractColumnIndex, new ContractListViewDropdownCell(record.Contract));

            Worksheet.SetCellData(row, Constants.AdditionalInfoColumnIndex, record.AdditionalInfo);
            Worksheet.SetCellBody(row, Constants.AdditionalInfoColumnIndex, new AdditionalInfoListViewDropdownCell(record.AdditionalInfo));
        }

        private void InitializeHeaders()
        {
            Worksheet.ColumnHeaders[Constants.CompanyColumnIndex].Text = IsEnglishLanguage ? "Name of the company" : "Название компании";
            Worksheet.ColumnHeaders[Constants.RequisitesColumnIndex].Text = IsEnglishLanguage ? "Requisites" : "Реквизиты";
            Worksheet.ColumnHeaders[Constants.ContactPersonColumnIndex].Text = IsEnglishLanguage ? "Contact person" : "Контактное лицо";
            Worksheet.ColumnHeaders[Constants.LicenseColumnIndex].Text = IsEnglishLanguage ? "Availability of license and terms" : "Наличие лицензии и сроки";
            Worksheet.ColumnHeaders[Constants.ProductsColumnIndex].Text = IsEnglishLanguage ? "Purchased products and cost" : "Покупаемые изделия и стоимость";
            Worksheet.ColumnHeaders[Constants.ContractColumnIndex].Text = IsEnglishLanguage ? "Execution of contract" : "Исполнение контракта";
            Worksheet.ColumnHeaders[Constants.AdditionalInfoColumnIndex].Text = IsEnglishLanguage ? "Additional Information" : "Дополнительная информация";
        }

        #endregion Work with worksheet
    }
}