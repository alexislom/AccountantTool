using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using AccountantTool.Common;
using AccountantTool.Helpers;
using AccountantTool.Model;
using AccountantTool.ReoGrid.CustomDropDownCell;
using AccountantTool.ReoGrid.DataFormatter;
using ClosedXML.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Win32;
using unvell.ReoGrid;
using unvell.ReoGrid.DataFormat;
using unvell.ReoGrid.IO;
using UIControls;
using Cell = unvell.ReoGrid.Cell;

namespace AccountantTool.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Fields
        private List<AccountantRecord> _filteredRecords;
        private readonly Dictionary<string, string> _columnNamesMap = new Dictionary<string, string>
        {
            { "All", string.Empty},
            { "Companies", "Company"},
            {"Requisites", "Requisites"},
            {"Contact persons", "ContactPersons"},
            {"License", "License"},
            {"Products", "Products"},
            {"Contracts", "Contract"},
            { "Additional info", "AdditionalInfo"}
        };
        #endregion Fields

        #region Properties
        public ObservableCollection<AccountantRecord> AccountantRecords { get; set; }
        public Worksheet Worksheet { get; }
        public bool IsEnglishLanguage => App.SelectedLanguage.Equals(App.Languages[0]);
        public List<AccountantRecord> FilteredRecords
        {
            get => _filteredRecords ?? (_filteredRecords = AccountantRecords.ToList());
            set => _filteredRecords = value;
        }
        #endregion Properties

        #region Commands
        public ICommand ChangeLanguageCommand { get; }
        public ICommand LoadDataCommand { get; }
        public ICommand AddNewRecordCommand { get; }
        public ICommand DeleteRecordCommand { get; }
        public ICommand SaveDocumentCommand { get; }
        public ICommand ExportToExcelCommand { get; }
        public ICommand ExportToPdfCommand { get; }
        #endregion Commands

        #region Construction

        public MainWindowViewModel(Worksheet mainGrid)
        {
            Worksheet = mainGrid;

            AccountantRecords = new ObservableCollection<AccountantRecord>();

            ChangeLanguageCommand = new RelayCommand(ChangeLanguage);
            LoadDataCommand = new AsyncDelegateCommand(OnLoadData);
            AddNewRecordCommand = new AsyncDelegateCommand(OnAddNewRecord);
            DeleteRecordCommand = new AsyncDelegateCommand(OnDeleteRecord, CanExecuteOperation);
            SaveDocumentCommand = new RelayCommand(OnSaveDocument, CanExecuteOperation);
            ExportToExcelCommand = new RelayCommand(OnExportToExcel, CanExecuteOperation);
            ExportToPdfCommand = new RelayCommand(OnExportToPdf, CanExecuteOperation);

            InitializeWorksheet();
        }

        #endregion Construction

        public void OnSearch(SearchEventArgs searchArgs)
        {
            if (!searchArgs.Sections.Any())
            {
                searchArgs.Sections = new List<string> { "All" };
            }

            // global search
            if (searchArgs.Sections.Contains("All"))
            {
                if (string.IsNullOrWhiteSpace(searchArgs.Keyword))
                {
                    FilteredRecords = AccountantRecords.ToList();
                    RefreshFilteredRecords(AccountantRecords);
                }
                else
                {
                    var result = AccountantRecords.Where(t => Filter(t, searchArgs.Keyword));
                    if (result.Any())
                    {
                        FilteredRecords = result.ToList();
                        RefreshFilteredRecords(result);
                    }
                }
            }
            else // search by column
            {
                if (string.IsNullOrWhiteSpace(searchArgs.Keyword))
                {
                    RefreshFilteredRecords(AccountantRecords);
                }
                else
                {
                    var filteredProperties = searchArgs.Sections.Select(t => _columnNamesMap[t]).ToList();

                    var results = new List<AccountantRecord>();

                    foreach (var filter in filteredProperties)
                    {
                        if (!string.IsNullOrEmpty(filter))
                        {
                            var result = FilteredRecords.Where(t => FilterBy(t, searchArgs.Keyword, filter));
                            results.AddRange(result);
                        }
                    }

                    if (results.Any())
                    {
                        FilteredRecords = results.Distinct().ToList();
                        RefreshFilteredRecords(FilteredRecords);
                    }
                }
            }
        }

        #region Filter methods

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

            switch (propertyName)
            {
                #region delailed search
                //case "Company":
                //    var companyList = filteredProperty.GetValue(obj, null);
                //    var companyDetails = (Company)companyList;
                //    return companyDetails.LongName.ToLowerInvariant().Contains(value.ToLowerInvariant()) ||
                //           companyDetails.ShortName.ToLowerInvariant().Contains(value.ToLowerInvariant());
                //case "Requisites":

                //    break;
                #endregion delailed search
                case "ContactPersons":
                    var contactPersonsList = filteredProperty.GetValue(obj, null);
                    var contactPersonsDetails = (List<ContactPerson>)contactPersonsList;
                    if (contactPersonsDetails.Count > 0)
                    {
                        return contactPersonsDetails.Any(x => x.ToString().ToLowerInvariant().Contains(value.ToLowerInvariant()));
                    }
                    break;
                case "License":
                    var licenseList = filteredProperty.GetValue(obj, null);
                    var licenseDetails = (List<License>)licenseList;
                    if (licenseDetails.Count > 0)
                    {
                        return licenseDetails.Any(x => x.ToString().ToLowerInvariant().Contains(value.ToLowerInvariant()));
                    }
                    break;
                case "Products":
                    var productsList = filteredProperty.GetValue(obj, null);
                    var productsDetails = (List<Product>)productsList;
                    if (productsDetails.Count > 0)
                    {
                        return productsDetails.Any(x => x.ToString().ToLowerInvariant().Contains(value.ToLowerInvariant()));
                    }
                    break;
                #region detailed search
                //case "Contract":

                //    break;
                //case "AdditionalInfo":

                //    break;
                #endregion detailed search
                default:
                    var recordString = filteredProperty.GetValue(obj, null).ToString().ToLowerInvariant();
                    return recordString.Contains(value.ToLowerInvariant());
            }
            return false;
        }

        #endregion Filter methods

        private async Task RefreshFilteredRecords(IEnumerable<AccountantRecord> collection)
        {
            Worksheet.ClearRangeContent(RangePosition.EntireRange, CellElementFlag.All);

            var rowIndex = 0;

            foreach (var filteredAccountantRecords in collection)
            {
                await Task.Run(() =>
                {
                    AddRecord(rowIndex, filteredAccountantRecords);
                    rowIndex++;
                });
            }
        }

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
            FilteredRecords = AccountantRecords.ToList();

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
                        FilteredRecords = AccountantRecords.ToList();
                    });
                }
            }

            Worksheet.DeleteRows(Worksheet.SelectionRange.Row, Worksheet.SelectionRange.Rows);
        }

        public async Task RestoreLastFile(string defaultLastFileName)
        {
            await LoadRecords(defaultLastFileName);
            FilteredRecords = AccountantRecords.ToList();
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
                FilteredRecords = AccountantRecords.ToList();
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

        private void OnExportToPdf()
        {
            #region Another test
            //var workbook = new XLWorkbook();
            //var ws = workbook.Worksheets.Add("Style Alignment");

            //var co = 2;
            //var ro = 1;

            //ws.Cell(++ro, co).Value = "Horizontal = Right";
            //ws.Cell(ro, co).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

            //ws.Cell(++ro, co).Value = "Indent = 2";
            //ws.Cell(ro, co).Style.Alignment.Indent = 2;

            //ws.Cell(++ro, co).Value = "JustifyLastLine = true";
            //ws.Cell(ro, co).Style.Alignment.JustifyLastLine = true;

            //ws.Cell(++ro, co).Value = "ReadingOrder = ContextDependent";
            //ws.Cell(ro, co).Style.Alignment.ReadingOrder = XLAlignmentReadingOrderValues.ContextDependent;

            //ws.Cell(++ro, co).Value = "RelativeIndent = 2";
            //ws.Cell(ro, co).Style.Alignment.RelativeIndent = 2;

            //ws.Cell(++ro, co).Value = "ShrinkToFit = true";
            //ws.Cell(ro, co).Style.Alignment.ShrinkToFit = true;

            //ws.Cell(++ro, co).Value = "TextRotation = 45";
            //ws.Cell(ro, co).Style.Alignment.TextRotation = 45;

            //ws.Cell(++ro, co).Value = "TopToBottom = true";
            //ws.Cell(ro, co).Style.Alignment.TopToBottom = true;

            //ws.Cell(++ro, co).Value = "Vertical = Center";
            //ws.Cell(ro, co).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            //ro++;
            //var range = ws.Range(ro, co, ro, co + 2).Merge().Style.Alignment.WrapText = true;
            ////ws.Cell(ro, co).Style.Alignment.WrapText = true;
            //ws.Cell(ro, co).Value = "WrapText = true okkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkofofofofofofofoofof";

            //workbook.SaveAs("lalalalalala.xlsx");
            #endregion Another test
            #region Pdf export
            //var document = new Document();
            //PdfWriter.GetInstance(document, new FileStream(Environment.CurrentDirectory + @"\Document.pdf", FileMode.Create));
            //document.Open();

            //var table = new PdfPTable(3);
            //var cell = new PdfPCell(new Phrase("Simple table", new Font(Font.TIMES_ROMAN, 16, Font.NORMAL, Color.ORANGE)))
            //{
            //    BackgroundColor = Color.WHITE,
            //    Padding = 5,
            //    Colspan = 3,
            //    HorizontalAlignment = Element.ALIGN_CENTER
            //};
            //table.AddCell(cell);
            //table.AddCell("Col 1 Row 1");
            //table.AddCell("Col 2 Row 1");
            //table.AddCell("Col 3 Row 1");
            //table.AddCell("Col 1 Row 2");
            //table.AddCell("Col 2 Row 2");
            //table.AddCell("Col 3 Row 2");

            //document.Add(table);

            //document.Close();
            #endregion Pdf export
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

            if (FilteredRecords != null && !FilteredRecords.Any())
            {
                FilteredRecords = AccountantRecords.ToList();
            }

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Inserting Data");

                var row = 1;
                const int column = 1;

                foreach (var record in FilteredRecords)
                {
                    // Name of company
                    worksheet.Cell(row, column).Value = "Название компании";
                    worksheet.Range(row, column, row, column + 5).Merge().AddToNamed("Titles");

                    row++;

                    worksheet.Cell(row, column).Value = record.Company.LongName;
                    worksheet.Range(row, column, row, column + 5).Merge().Style.Alignment
                        .SetHorizontal(XLAlignmentHorizontalValues.Center);

                    row++;

                    // Requisites
                    worksheet.Cell(row, column).Value = "Реквизиты";
                    worksheet.Range(row, column, row, column + 5).Merge().AddToNamed("Titles");

                    row++;

                    worksheet.Cell(row, column).Value = "Адрес:";

                    var addressList = new List<string>
                    {
                        record.Requisites?.Address?.Index,
                        record.Requisites?.Address?.Country,
                        record.Requisites?.Address?.Region,
                        record.Requisites?.Address?.District,
                        record.Requisites?.Address?.City,
                        record.Requisites?.Address?.Street,
                        record.Requisites?.Address?.House,
                        record.Requisites?.Address?.Flat
                    };
                    var address = string.Join(", ", addressList.Where(x => x != string.Empty));
                    worksheet.Cell(row, column + 1).Value = address;
                    worksheet.Range(row, column + 1, row, column + 5).Merge();

                    row++;

                    worksheet.Cell(row, column).Value = "Адрес электронной почты:";
                    worksheet.Cell(row, column + 1).Value = record.Requisites?.Email;
                    var emailRange = worksheet.Range(row, column + 1, row, column + 5).Merge();
                    emailRange.Style.Font.Bold = true;

                    row++;

                    worksheet.Cell(row, column).Value = "Сайт:";
                    worksheet.Cell(row, column + 1).Value = record.Requisites?.Site;
                    var siteRange = worksheet.Range(row, column + 1, row, column + 5).Merge();
                    siteRange.Style.Font.Bold = true;

                    if (record.Requisites.Site != null)
                    {
                        worksheet.Cell(row, column + 1).Hyperlink =
                            new XLHyperlink(record.Requisites.Site.StartsWith("http:")
                                ? record.Requisites.Site
                                : "http://" + record.Requisites.Site);
                    }

                    row++;

                    if (record.Requisites.DepartmentPhones != null && record.Requisites.DepartmentPhones.Count > 0)
                    {
                        worksheet.Cell(row, column).Value = "Контактные телефоны:";
                        worksheet.Range(row, column, row, column + 5).Merge();

                        var phonesStyle = worksheet.Range(row, column, row, column + 5).Style;
                        phonesStyle.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        phonesStyle.Font.Bold = true;
                        phonesStyle.Font.FontSize = 12;

                        row++;
                        worksheet.Cell(row, column).Value = "Отдел";
                        worksheet.Cell(row, column + 1).Value = "Телефон";

                        var contactPhonesStyle = worksheet.Range(row, column, row, column + 1).Style;
                        contactPhonesStyle.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        contactPhonesStyle.Font.Bold = true;

                        row++;

                        var contactPhonesRange = worksheet.Cell(row, column)
                            .InsertData(record.Requisites.DepartmentPhones.AsEnumerable());
                        if (contactPhonesRange != null)
                        {
                            row += contactPhonesRange.RowCount();
                        }
                    }

                    if (record.Requisites.OtherRequisites != null && record.Requisites.OtherRequisites.Count > 0)
                    {
                        worksheet.Cell(row, column).Value = "Иные реквизиты:";
                        worksheet.Range(row, column, row, column + 5).Merge();

                        var otherRequisitesStyle = worksheet.Range(row, column, row, column + 5).Style;
                        otherRequisitesStyle.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        otherRequisitesStyle.Font.Bold = true;
                        otherRequisitesStyle.Font.FontSize = 12;

                        row++;
                        worksheet.Cell(row, column).Value = "Иной реквизит";
                        worksheet.Cell(row, column + 1).Value = "Его значение";

                        var otherStyle = worksheet.Range(row, column, row, column + 1).Style;
                        otherStyle.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        otherStyle.Font.Bold = true;

                        row++;

                        var contactOtherRequisites = worksheet.Cell(row, column)
                            .InsertData(record.Requisites.OtherRequisites.AsEnumerable());

                        if (contactOtherRequisites != null)
                        {
                            row += contactOtherRequisites.RowCount();
                        }
                    }

                    // Contact persons
                    worksheet.Cell(row, column).Value = "Контактные лица";
                    worksheet.Range(row, column, row, column + 5).Merge().AddToNamed("Titles");

                    row++;
                    if (record.ContactPersons.Any())
                    {
                        worksheet.Cell(row, column).Value = "Должность";
                        worksheet.Cell(row, column + 1).Value = "ФИО";
                        worksheet.Cell(row, column + 2).Value = "Контактный телефон";
                        worksheet.Cell(row, column + 3).Value = "Адрес электронной почты";

                        var contactsStyle = worksheet.Range(row, column, row, column + 3).Style;
                        contactsStyle.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        contactsStyle.Font.Bold = true;

                        row++;

                        var contactPersons =
                            worksheet.Cell(row, column).InsertData(record.ContactPersons.AsEnumerable());

                        for (var rowIndex = 0; rowIndex < contactPersons.RowCount(); rowIndex++)
                        {
                            for (var columnIndex = 0; columnIndex < 7; columnIndex++)
                            {
                                worksheet.Cell(row + rowIndex, column + columnIndex).Style.Alignment
                                    .SetVertical(XLAlignmentVerticalValues.Top);
                                worksheet.Cell(row + rowIndex, column + columnIndex).Style.Alignment
                                    .SetHorizontal(XLAlignmentHorizontalValues.Left);
                            }
                        }

                        row += contactPersons.RowCount();
                    }

                    // License
                    worksheet.Cell(row, column).Value = "Наличие лицензии и сроки";
                    worksheet.Range(row, column, row, column + 5).Merge().AddToNamed("Titles");

                    row++;

                    if (record.License.Any())
                    {
                        worksheet.Cell(row, column).Value = "Номер";
                        worksheet.Cell(row, column + 1).Value = "Дата выдачи";
                        worksheet.Cell(row, column + 2).Value = "Дата окончания";
                        worksheet.Cell(row, column + 3).Value = "Вид лицензии";

                        var licenseStyle = worksheet.Range(row, column, row, column + 3).Style;
                        licenseStyle.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        licenseStyle.Font.Bold = true;

                        row++;

                        var license = worksheet.Cell(row, column).InsertData(record.License.AsEnumerable());

                        for (var rowIndex = 0; rowIndex < license.RowCount(); rowIndex++)
                        {
                            for (var columnIndex = 0; columnIndex < 7; columnIndex++)
                            {
                                worksheet.Cell(row + rowIndex, column + columnIndex).Style.Alignment
                                    .SetVertical(XLAlignmentVerticalValues.Top);
                                worksheet.Cell(row + rowIndex, column + columnIndex).Style.Alignment
                                    .SetHorizontal(XLAlignmentHorizontalValues.Left);
                            }
                        }

                        row += license.RowCount();
                    }

                    // Products
                    worksheet.Cell(row, column).Value = "Покупаемые изделия и стоимость";
                    worksheet.Range(row, column, row, column + 5).Merge().AddToNamed("Titles");

                    row++;

                    if (record.Products.Any())
                    {
                        worksheet.Cell(row, column).Value = "Наименование изделия";
                        worksheet.Cell(row, column + 1).Value = "Стоимость у продавца";
                        worksheet.Cell(row, column + 2).Value = "Валюта";
                        worksheet.Cell(row, column + 3).Value = "Стоимость для покупателя";
                        worksheet.Cell(row, column + 4).Value = "Валюта";
                        worksheet.Cell(row, column + 5).Value = "Количество изделий";

                        var productsStyle = worksheet.Range(row, column, row, column + 5).Style;
                        productsStyle.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        productsStyle.Font.Bold = true;

                        row++;

                        foreach (var product in record.Products)
                        {
                            worksheet.Cell(row, column).Value = product.Name;
                            worksheet.Cell(row, column + 1).Value = product.CostFromSeller;
                            worksheet.Cell(row, column + 2).Value = product.CostFromSellerCurrency;
                            worksheet.Cell(row, column + 3).Value = product.CostForCustomer;
                            worksheet.Cell(row, column + 4).Value = product.CostForCustomerCurrency;
                            worksheet.Cell(row, column + 5).Value = product.Count;
                            row++;
                            if (!string.IsNullOrEmpty(product.Description))
                            {
                                worksheet.Cell(row, column).Value = product.Description;
                                worksheet.Range(row, column, row, column + 5).Merge();
                                //This is little cheat how to set height of row for the marged columns
                                worksheet.Row(row).Height = (product.Description.Length / 116 + 1) * 15;
                                row++;
                            }
                        }
                    }

                    // Contract
                    worksheet.Cell(row, column).Value = "Исполнение контракта";
                    worksheet.Range(row, column, row, column + 5).Merge().AddToNamed("Titles");

                    row++;

                    worksheet.Cell(row, column).Value = "Номер";
                    worksheet.Cell(row, column + 1).Value = "Дата";
                    worksheet.Cell(row, column + 2).Value = "Стороны";
                    worksheet.Cell(row, column + 3).Value = "Срок";
                    worksheet.Cell(row, column + 4).Value = "Статус";

                    var contractsStyle = worksheet.Range(row, column, row, column + 4).Style;
                    contractsStyle.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    contractsStyle.Font.Bold = true;
                    row++;

                    IEnumerable<Contract> contract = new List<Contract> { record.Contract };

                    var contractCell = worksheet.Cell(row, column).InsertData(contract);

                    row += contractCell.RowCount();

                    // Additional info
                    worksheet.Cell(row, column).Value = "Дополнительная информация";
                    worksheet.Range(row, column, row, column + 5).Merge().AddToNamed("Titles");

                    row++;

                    worksheet.Cell(row, column).Value = record.AdditionalInfo.Notes;
                    worksheet.Range(row, column, row, column + 5).Merge();//.AddToNamed("SubTitles");
                    worksheet.Cell(row, column).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left);

                    worksheet.Columns().AdjustToContents();

                    // End of record info, setting page break and add row
                    worksheet.PageSetup.AddHorizontalPageBreak(row);
                    row++;
                }
                // Style for tittles----------------------
                var titlesStyle = workbook.Style;
                titlesStyle.Font.Bold = true;
                titlesStyle.Font.FontSize = 16;
                titlesStyle.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                workbook.NamedRanges.NamedRange("Titles").Ranges.Style = titlesStyle;
                //Wrap text and columns alignment---------
                worksheet.Columns().AdjustToContents(2, 22);
                worksheet.Style.Alignment.SetWrapText(true);
                //----------------------------------------
                workbook.SaveAs($"{exportFileDialog.FileName}");
            }

            MessageBox.Show($"{(IsEnglishLanguage ? "File save as:" : "Файл сохранён как:")}" + Environment.NewLine +
                            exportFileDialog.FileName, $"{(IsEnglishLanguage ? "Export to excel" : "Экспорт в эксель")}",
                            MessageBoxButton.OK, MessageBoxImage.Information);
            // Only for debug
            //Process.Start($"{exportFileDialog.FileName}");
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