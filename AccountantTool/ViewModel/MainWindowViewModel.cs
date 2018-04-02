using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.ModelConfiguration.Conventions;
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
using unvell.ReoGrid;
using unvell.ReoGrid.DataFormat;

namespace AccountantTool.ViewModel
{
    public class MainWindowViewModel : ViewModelBase, IAccountantRecordSearch
    {
        public Worksheet Worksheet { get; }

        #region Fields
        private readonly object _accountantRecordsLock = new object();
        private string _searchString;
        #endregion Fields

        #region Properties
        public AccountantDbContext Context { get; set; }
        public ObservableCollection<AccountantRecord> AccountantRecords { get; set; }
        public ICollectionView<AccountantRecord> FilteredAccountantRecords { get; set; }
        public AccountantRecord SelectedAccountantRecord { get; set; }
        public bool IsDataLoaded { get; set; }
        public string SearchString
        {
            get => _searchString;
            set
            {
                _searchString = value; OnPropertyChanged();
                if (string.IsNullOrWhiteSpace(value))
                {
                    FilteredAccountantRecords.Filter = null;
                }
                else
                {
                    Task.Run(() =>
                    {
                        Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            FilteredAccountantRecords.Filter = obj => ((AccountantRecord)obj).ToString().Contains(value.ToLower());
                        }), DispatcherPriority.Background);
                    });
                }
            }
        }
        #endregion Properties

        #region Events
        public event EventHandler<EventArgs<AccountantRecord>> AddNewAccountantRecordEvent;
        #endregion Events

        #region Commands
        public ICommand OpenSettindsDialogCommand { get; set; }
        public ICommand AddNewAccountantRecordCommand { get; set; }
        public ICommand LoadAccountantRecordsAsyncCommand { get; set; }
        public ICommand AddNewRecordCommand { get; set; }
        public ICommand DeleteRecordCommand { get; set; }
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
            //OpenSettindsDialogCommand = new RelayCommand(DoStuff);
            //LoadAccountantRecordsAsyncCommand = new AsyncDelegateCommand(LoadAccountantRecordsAsync, x => IsDataLoaded);

            AddNewRecordCommand = new RelayCommand(OnAddNewRecord);
            DeleteRecordCommand = new RelayCommand(OnDeleteRecord, x => AccountantRecords.Count >= 1 && Worksheet.RowCount > 1);

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
            var id = Guid.NewGuid();
            var kek = new AccountantRecord
            {
                Id = id,
                Requisites = new Requisites
                {
                    Address = new Address
                    {
                        City = "asd",
                        Country = "asdaxzca",
                        District = "district",
                        Flat = "flat",
                        House = "5",
                        Index = "2222222",
                        Region = "nasgnals"
                    },
                    Email = "aaalalalalala",
                    DepartmentPhones = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("First department", "111111111"),
                        new KeyValuePair<string, string>("Second department", "22222222222"),
                        new KeyValuePair<string, string>("Third department", "33333333333"),
                    },
                    Site = "asfasfafw.com",
                    OtherRequisites = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("A", "aaa213214adsa"),
                        new KeyValuePair<string, string>("B", "agggggggsa"),
                        new KeyValuePair<string, string>("C", "dfsdgf3214adsa"),
                    }
                },
                Company = new Company
                {
                    ParentId = id,
                    LongName = "TestLongName",
                    ShortName = "TestShortName"
                },
                ContactPersons = new List<ContactPerson>
                {
                    new ContactPerson
                    {
                        ContactPhone = "12312412452154",
                        Email = "Email1",
                        FullName = "FIOName1",
                        Position = "Position1",
                    },
                    new ContactPerson
                    {
                        ContactPhone = "C15on5215125",
                        Email = "Email2",
                        FullName = "FIOName2",
                        Position = "Position2",
                    },
                    new ContactPerson
                    {
                        ContactPhone = "Con125215125Phone ",
                        Email = "Email3",
                        FullName = "FIOName3",
                        Position = "Position3",
                    },
                    new ContactPerson
                    {
                        ContactPhone = "15155656546 ",
                        Email = "Email4",
                        FullName = "FIOName4",
                        Position = "Position4",
                    }
                },
                Contract = new Contract
                {
                    ContractStage = ContractStage.One,
                    DateOfEnd = DateTime.Now,
                    DateOfStart = DateTime.Now,
                    //IsFulfilled = false,
                    NumberOfContract = "1",
                    SidesOfContract = "asdasd"
                },
                AdditionalInfo = new AdditionalInfo
                {
                    Notes = "asd"
                },
                License = new List<License>
                {
                    new License
                    {
                        LicenseType = LicenseType.One,
                        DateOfExpiration = DateTime.Now,
                        DateOfIssue = DateTime.Now,
                        NumberOfLicense = "355"
                    },
                    new License
                    {
                        LicenseType = LicenseType.Two,
                        DateOfExpiration = DateTime.Now,
                        DateOfIssue = DateTime.Now,
                        NumberOfLicense = "344"
                    },
                    new License
                    {
                        LicenseType = LicenseType.Three,
                        DateOfExpiration = DateTime.Now,
                        DateOfIssue = DateTime.Now,
                        NumberOfLicense = "366"
                    }
                },
                Products = new List<Product>
                {
                    new Product
                    {
                        Count = "6",
                        CostForCustomer = 2,
                        CostFromSeller = 4,
                        Description = "qweqweqwe",
                        Name = "asd4"
                    },
                    new Product
                    {
                        Count = 9.ToString(),
                        CostForCustomer = 2233223,
                        CostFromSeller = 44444,
                        Description = "qweqgfhdbgsdweqwe",
                        Name = "asd"
                    },
                    new Product
                    {
                        Count = "2",
                        CostForCustomer = 111.3,
                        CostFromSeller = 0.22,
                        Description = "eeteyherhgqweqweqwe",
                        Name = "asd3"
                    }
                },
            };
            AccountantRecords.Add(kek);

            for (var i = 0; i < AccountantRecords.Count; i++)
            {
                var accountantRecord = AccountantRecords[i];

                AddRecord(i, accountantRecord);
            }
        }

        private void InitializeHeaders()
        {
            Worksheet.ColumnHeaders[Constants.CompanyColumnIndex].Text = "Название компании";
            Worksheet.ColumnHeaders[Constants.RequisitesColumnIndex].Text = "Реквизиты";
            Worksheet.ColumnHeaders[Constants.ContactPersonColumnIndex].Text = "Контактное лицо";
            Worksheet.ColumnHeaders[Constants.LicenseColumnIndex].Text = "Наличие лицензии и сроки";
            Worksheet.ColumnHeaders[Constants.ProductsColumnIndex].Text = "Покупаемые изделия и стоимость";
            Worksheet.ColumnHeaders[Constants.ContractColumnIndex].Text = "Исполнение контракта";
            Worksheet.ColumnHeaders[Constants.AdditionalInfoColumnIndex].Text = "Дополнительная информация";
        }

        private void AddRecord(int row, AccountantRecord record)
        {
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

        #endregion Work with worksheet

        #region Event handlers

        private void OnAddNewAccountantRecordEvent(object sender, EventArgs<AccountantRecord> eventArgs)
        {
            Context.AccountantRecords.Add(eventArgs.Value);
            Context.SaveChanges();
        }

        #endregion Event handlers

        #region Commands implementation

        private void OnAddNewRecord()
        {
            var random = new Random();
            var id = Guid.NewGuid();
            var newRecord = new AccountantRecord { Id = id, Company = new Company { ShortName = "SN" + random.Next(1, 500), ParentId = id } };

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

        private void AddAccountantRecordOpenWindow()
        {
            var addWindow = new AddAccountantRecordWindow(this);
            addWindow.Owner = Application.Current.MainWindow;
            addWindow.ShowDialog();
        }

        public async Task AddNewAccountantRecordAsync(AccountantRecord record)
        {
            //Example data for testing command
            await Task.Run(() =>
            {
                AccountantRecords.Add(record);
                AddNewAccountantRecordEvent.Raise(this, record);
            });
            //await LoadFullAmountAndNumberAsync();
        }

        private static void DoStuff()
        {
            MessageBox.Show("Responding to button click event...");
        }

        private async Task LoadAccountantRecordsAsync(object arg)
        {
            IsDataLoaded = false;

            if (AccountantRecords.Count > 0)
                AccountantRecords.Clear();

            await Task.Factory.StartNew(() =>
            {
                Parallel.ForEach(Context.AccountantRecords, item =>
                {
                    Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        AccountantRecords.Add(item);           //Adding to Collection without freezing UI
                    }), DispatcherPriority.Background).Wait(); //WaitForAdding
                });
            });
            IsDataLoaded = true;

            //await LoadFullAmountAndNumberAsync(); //Then Show Total
            //await LoadRandomWatermarkAsync();//And Watermark of Search
        }

        #endregion Commands implementation
    }
}