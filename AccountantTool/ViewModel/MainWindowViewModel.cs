﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;
using AccountantTool.Data;
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
        #endregion Commands

        #region Construction

        public MainWindowViewModel(Worksheet mainGrid)
        {
            Worksheet = mainGrid;

            Context = new AccountantDbContext();
            AccountantRecords = new ObservableCollection<AccountantRecord>();

            BindingOperations.EnableCollectionSynchronization(AccountantRecords, _accountantRecordsLock);
            FilteredAccountantRecords = new CollectionViewGeneric<AccountantRecord>(CollectionViewSource.GetDefaultView(AccountantRecords));

            AddNewAccountantRecordCommand = new RelayCommand(AddAccountantRecordOpenWindow);
            OpenSettindsDialogCommand = new RelayCommand(DoStuff);
            LoadAccountantRecordsAsyncCommand = new AsyncDelegateCommand(LoadAccountantRecordsAsync, x => IsDataLoaded);

            AddNewAccountantRecordEvent += OnAddNewAccountantRecordEvent;

            LoadAccountantRecordsAsyncCommand.Execute(null);

            DataFormatterManager.Instance.DataFormatters.Add(CellDataFormatFlag.Custom, new AccountantToolDataFormatter());
            InitializeWorksheet();
        }

        #endregion Construction

        #region Work with worksheet

        private void InitializeWorksheet()
        {
            AccountantRecords.Add(new AccountantRecord
            {
                Requisites = new Requisites
                {
                    Address = new Address
                    {
                        City = "asd",
                        Country = "asdaxzca",
                        District = "district",
                        Flat = "flat",
                        House = "5",
                        Index = 2222222,
                        Region = "nasgnals"
                    }
                },
                Company = new Company
                {
                    LongName = "TestLongName",
                    ShortName = "TestShortName"
                },
                ContactPerson = new ContactPerson
                {
                    ContactPhone = "ContactPhone ",
                    Email = "Email",
                    Name = "Name",
                    Patronymic = "Patronymic ",
                    Position = "Position",
                    Surname = "Surname"
                },
                Contract = new Contract
                {
                    ContractStage = ContractStage.One,
                    DateOfEnd = DateTime.Now,
                    DateOfStart = DateTime.Now,
                    IsFulfilled = false,
                    NumberOfContract = 1,
                    SideOfContract = "asdasd"
                },
                AdditionalInfo = new AdditionalInfo
                {
                    Notes = "asd"
                },
                License = new License
                {
                    LicenseType = LicenseType.One,
                    DateOfExpiration = DateTime.Now,
                    DateOfIssue = DateTime.Now,
                    NumberOfLicense = 3
                },
                Product = new List<Product>
                {
                    new Product
                    {
                        Count = 6,
                        CostForCustomer = 2,
                        CostFromSeller = 4,
                        Description = "qweqweqwe",
                        Name = "asd4"
                    },
                    new Product
                    {
                        Count = 9,
                        CostForCustomer = 2,
                        CostFromSeller = 4,
                        Description = "qweqgfhdbgsdweqwe",
                        Name = "asd"
                    },new Product
                    {
                        Count = 2,
                        CostForCustomer = 2,
                        CostFromSeller = 4,
                        Description = "eeteyherhgqweqweqwe",
                        Name = "asd3"
                    }
                },
            });
            Worksheet.Columns = 8;
            for (var i = 0; i < AccountantRecords.Count; i++)
            {
                var accountantRecord = AccountantRecords[i];
                Worksheet.SetCellData(i, 0, accountantRecord.Company);


                Worksheet.SetCellBody(i, 0, new CompanyListViewDropdownCell(accountantRecord.Company));

                Worksheet.SetCellData(i, 1, accountantRecord.Requisites);
                Worksheet.SetCellData(i, 2, accountantRecord.ContactPerson);
                Worksheet.SetCellData(i, 3, accountantRecord.License);
                Worksheet.SetCellData(i, 4, accountantRecord.Product);
                Worksheet.SetCellData(i, 5, accountantRecord.Contract);
                Worksheet.SetCellData(i, 6, accountantRecord.AdditionalInfo);
            }
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