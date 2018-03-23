using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;
using AccountantTool.Data;
using AccountantTool.Model;
using AccountantTool.View;
using AccountantTool.ViewModel.MainComponents;

namespace AccountantTool.ViewModel
{
    public class MainWindowViewModel
    {
        #region Fields

        private object _accountantRecordsLock = new object();

        #endregion Fields

        #region Properties

        public AccountantDbContext Context { get; set; }

        public ObservableCollection<AccountantRecord> AccountantRecords { get; set; }

        public ICollectionView FilteredAccountantRecords { get; set; }

        public AccountantRecord SelectedAccountantRecord { get; set; }

        public bool IsDataLoaded { get; set; }

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

        public MainWindowViewModel()
        {
            Context = new AccountantDbContext();
            AccountantRecords = new ObservableCollection<AccountantRecord>();

            BindingOperations.EnableCollectionSynchronization(AccountantRecords, _accountantRecordsLock);
            FilteredAccountantRecords = CollectionViewSource.GetDefaultView(AccountantRecords);

            AddNewAccountantRecordCommand = new RelayCommand(AddAccountantRecordOpenWindow);
            OpenSettindsDialogCommand = new RelayCommand(DoStuff);
            LoadAccountantRecordsAsyncCommand = new AsyncDelegateCommand(LoadAccountantRecordsAsync, x => IsDataLoaded);

            AddNewAccountantRecordEvent += OnAddNewAccountantRecordEvent;
        }

        #endregion Construction

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