using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;
using AccountantTool.Common;
using AccountantTool.Data;
using AccountantTool.Helpers;
using AccountantTool.Helpers.Search;
using AccountantTool.Model;
using AccountantTool.ReoGrid.CustomDropDownCell;
using AccountantTool.ReoGrid.DataFormatter;
using AccountantTool.View;
using AccountantTool.ViewModel.MainComponents;
using Microsoft.Win32;
using Newtonsoft.Json;
using unvell.ReoGrid;
using unvell.ReoGrid.DataFormat;
using unvell.ReoGrid.IO;

namespace AccountantTool.ViewModel
{
    public class MainWindowViewModel : ViewModelBase //, IAccountantRecordSearch
    {
        public Worksheet Worksheet { get; }

        #region Fields
        //private readonly object _accountantRecordsLock = new object();
        //private string _searchString;
        #endregion Fields

        #region Properties
        //public AccountantDbContext Context { get; set; }
        public ObservableCollection<AccountantRecord> AccountantRecords { get; set; }
        public bool IsRussianLanguage => App.SelectedLanguage.Equals(App.Languages[0]);
        //public ICollectionView<AccountantRecord> FilteredAccountantRecords { get; set; }
        //public AccountantRecord SelectedAccountantRecord { get; set; }
        //public bool IsDataLoaded { get; set; }
        //public string SearchString
        //{
        //    get => _searchString;
        //    set
        //    {
        //        _searchString = value; OnPropertyChanged();
        //        if (string.IsNullOrWhiteSpace(value))
        //        {
        //            FilteredAccountantRecords.Filter = null;
        //        }
        //        else
        //        {
        //            Task.Run(() =>
        //            {
        //                Application.Current.Dispatcher.BeginInvoke(new Action(() =>
        //                {
        //                    FilteredAccountantRecords.Filter = obj => ((AccountantRecord)obj).ToString().Contains(value.ToLower());
        //                }), DispatcherPriority.Background);
        //            });
        //        }
        //    }
        //}
        #endregion Properties

        //#region Events
        //public event EventHandler<EventArgs<AccountantRecord>> AddNewAccountantRecordEvent;
        //#endregion Events

        #region Commands
        //public ICommand AddNewAccountantRecordCommand { get; set; }
        //public ICommand LoadAccountantRecordsAsyncCommand { get; set; }

        public ICommand ChangeLanguageCommand { get; }
        public ICommand LoadDataCommand { get; }
        public ICommand AddNewRecordCommand { get; }
        public ICommand DeleteRecordCommand { get; }
        public ICommand SaveDocumentCommand { get; }
        #endregion Commands

        #region Construction

        public MainWindowViewModel(Worksheet mainGrid)
        {
            Worksheet = mainGrid;

            //Context = new AccountantDbContext();
            AccountantRecords = new ObservableCollection<AccountantRecord>();

            //BindingOperations.EnableCollectionSynchronization(AccountantRecords, _accountantRecordsLock);
            //FilteredAccountantRecords = new CollectionViewGeneric<AccountantRecord>(CollectionViewSource.GetDefaultView(AccountantRecords));

            //AddNewAccountantRecordCommand = new RelayCommand(AddAccountantRecordOpenWindow);
            ChangeLanguageCommand = new RelayCommand(ChangeLanguage);
            //LoadAccountantRecordsAsyncCommand = new AsyncDelegateCommand(LoadAccountantRecordsAsync, x => IsDataLoaded);

            LoadDataCommand = new RelayCommand(OnLoadData);
            AddNewRecordCommand = new RelayCommand(OnAddNewRecord);
            DeleteRecordCommand = new RelayCommand(OnDeleteRecord, x => AccountantRecords.Count >= 1 && Worksheet.RowCount > 1);
            SaveDocumentCommand = new RelayCommand(OnSaveDocument);

            //AddNewAccountantRecordEvent += OnAddNewAccountantRecordEvent;

            //LoadAccountantRecordsAsyncCommand.Execute(null);

            // Worksheet
            InitializeWorksheet();
        }

        #endregion Construction

        #region Work with worksheet

        private void InitializeWorksheet()
        {
            Worksheet.Columns = Constants.CountOfColumns;
            Worksheet.SelectionMode = WorksheetSelectionMode.Row;

            InitializeHeaders();

            DataFormatterManager.Instance.DataFormatters.Add(CellDataFormatFlag.Custom, new AccountantToolDataFormatter());
            Worksheet.SetColumnsWidth(0, 7, 200);
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
            Worksheet.SetCellBody(row, Constants.ContractColumnIndex, new ContactListViewDropdownCell(record.Contract));

            Worksheet.SetCellData(row, Constants.AdditionalInfoColumnIndex, record.AdditionalInfo);
            Worksheet.SetCellBody(row, Constants.AdditionalInfoColumnIndex, new AdditionalInfoListViewDropdownCell(record.AdditionalInfo));
        }

        private void InitializeHeaders()
        {
            Worksheet.ColumnHeaders[Constants.CompanyColumnIndex].Text = IsRussianLanguage ? "Name of the company" : "Название компании";
            Worksheet.ColumnHeaders[Constants.RequisitesColumnIndex].Text = IsRussianLanguage ? "Requisites" : "Реквизиты";
            Worksheet.ColumnHeaders[Constants.ContactPersonColumnIndex].Text = IsRussianLanguage ? "Contact person" : "Контактное лицо";
            Worksheet.ColumnHeaders[Constants.LicenseColumnIndex].Text = IsRussianLanguage ? "Availability of license and terms" : "Наличие лицензии и сроки";
            Worksheet.ColumnHeaders[Constants.ProductsColumnIndex].Text = IsRussianLanguage ? "Purchased products and cost" : "Покупаемые изделия и стоимость";
            Worksheet.ColumnHeaders[Constants.ContractColumnIndex].Text = IsRussianLanguage ? "Execution of the contract" : "Исполнение контракта";
            Worksheet.ColumnHeaders[Constants.AdditionalInfoColumnIndex].Text = IsRussianLanguage ? "Additional Information" : "Дополнительная информация";
        }

        #endregion Work with worksheet

        //#region Event handlers

        //private void OnAddNewAccountantRecordEvent(object sender, EventArgs<AccountantRecord> eventArgs)
        //{
        //    Context.AccountantRecords.Add(eventArgs.Value);
        //    Context.SaveChanges();
        //}

        //#endregion Event handlers

        #region Commands implementation

        private void ChangeLanguage()
        {
            App.SelectedLanguage = IsRussianLanguage ? new CultureInfo("ru-RU") : new CultureInfo("en-US");
            InitializeHeaders();
        }

        private void OnAddNewRecord()
        {
            // TODO: Refactor this
            var id = Guid.NewGuid();
            var newRecord = new AccountantRecord { Id = id, Company = new Company { ParentId = id } };

            var rowIndexToInsertNewRecord = AccountantRecords.Count;

            AccountantRecords.Add(newRecord);

            if (Worksheet.RowCount == AccountantRecords.Count)
            {
                Worksheet.AppendRows(Constants.CountOfRowsToAdd);
            }

            AddRecord(rowIndexToInsertNewRecord, newRecord);
        }

        private void OnDeleteRecord()
        {
            for (int i = 0, index = Worksheet.SelectionRange.Row; i < Worksheet.SelectionRange.Rows; i++, index++)
            {
                var companyCell = Worksheet.GetCell(index, Constants.CompanyColumnIndex);

                if (companyCell != null)
                {
                    var recordToRemove = AccountantRecords.FirstOrDefault(s => s.Id == companyCell.GetData<Company>().ParentId);
                    AccountantRecords.Remove(recordToRemove);
                }
            }

            Worksheet.DeleteRows(Worksheet.SelectionRange.Row, Worksheet.SelectionRange.Rows);
        }

        private void OnLoadData()
        {
            var openFileDialog = new OpenFileDialog
            {
                RestoreDirectory = Constants.FileDialogRestoreDirectory,
                Filter = Constants.FileDialogFilter
            };

            if (openFileDialog.ShowDialog() == true)
            {
                Worksheet.Workbook.Load($"{openFileDialog.FileName}", FileFormat.ReoGridFormat);

                AccountantRecords.Clear();

                for (var rowIndex = 0; rowIndex < Worksheet.RowCount; rowIndex++)
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

                    AccountantRecords.Add(accountantRecord);

                    AddRecord(rowIndex, AccountantRecords.Last());
                }
            }
        }

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

        private void OnSaveDocument()
        {
            var saveFileDialog = new SaveFileDialog
            {
                RestoreDirectory = Constants.FileDialogRestoreDirectory,
                Filter = Constants.FileDialogFilter
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                Worksheet.Workbook.Save($"{saveFileDialog.FileName}", FileFormat.ReoGridFormat);
            }
        }

        //private void AddAccountantRecordOpenWindow()
        //{
        //    var addWindow = new AddAccountantRecordWindow(this);
        //    addWindow.Owner = Application.Current.MainWindow;
        //    addWindow.ShowDialog();
        //}

        //public async Task AddNewAccountantRecordAsync(AccountantRecord record)
        //{
        //    //Example data for testing command
        //    await Task.Run(() =>
        //    {
        //        AccountantRecords.Add(record);
        //        AddNewAccountantRecordEvent.Raise(this, record);
        //    });
        //    //await LoadFullAmountAndNumberAsync();
        //}

        //private async Task LoadAccountantRecordsAsync(object arg)
        //{
        //    IsDataLoaded = false;

        //    if (AccountantRecords.Count > 0)
        //        AccountantRecords.Clear();

        //    await Task.Factory.StartNew(() =>
        //    {
        //        Parallel.ForEach(Context.AccountantRecords, item =>
        //        {
        //            Application.Current.Dispatcher.BeginInvoke(new Action(() =>
        //            {
        //                AccountantRecords.Add(item);           //Adding to Collection without freezing UI
        //            }), DispatcherPriority.Background).Wait(); //WaitForAdding
        //        });
        //    });
        //    IsDataLoaded = true;

        //    //await LoadFullAmountAndNumberAsync(); //Then Show Total
        //    //await LoadRandomWatermarkAsync();//And Watermark of Search
        //}

        #endregion Commands implementation
    }
}