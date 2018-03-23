using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
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

        #endregion Properties

        #region Events

        public event EventHandler<EventArgs<AccountantRecord>> AddNewAccountantRecordEvent;

        #endregion Events

        #region Commands

        public ICommand OpenSettindsDialogCommand { get; set; }

        public ICommand AddNewAccountantRecordCommand { get; set; }

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

            AddNewAccountantRecordEvent += OnAddNewAccountantRecordEvent;
        }

        #endregion Construction

        #region Event handlers

        private void OnAddNewAccountantRecordEvent(object sender, EventArgs<AccountantRecord> eventArgs)
        {
            //Context.AccountantRecords.Add(eventArgs.Value);
            //Context.SaveChanges();
        }

        #endregion Event handlers

        #region Commands implementation

        private void AddAccountantRecordOpenWindow()
        {
            var addWindow = new AddAccountantRecordWindow(this);
            addWindow.Owner = Application.Current.MainWindow;
            addWindow.ShowDialog();
        }

        private static void DoStuff()
        {
            MessageBox.Show("Responding to button click event...");
        }

        #endregion Commands implementation
    }
}