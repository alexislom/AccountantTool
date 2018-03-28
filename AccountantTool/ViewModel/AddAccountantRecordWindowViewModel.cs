using System.Windows.Input;
using AccountantTool.Model;
using AccountantTool.ViewModel.MainComponents;
using MahApps.Metro.Controls;

namespace AccountantTool.ViewModel
{
    public class AddAccountantRecordWindowViewModel
    {
        public MainWindowViewModel Model { get; }
        public ICommand AddAccountantRecordCommand { get; set; }

        #region Accountant record binding
        public Company Company { get; set; }
        public Requisites Requisites { get; set; }
        public ContactPerson ContactPerson { get; set; }
        public License License { get; set; }
        public LicenseType LicenseType { get; set; }
        public Product Product { get; set; }
        public Contract Contract { get; set; }
        public ContractStage ContractStage { get; set; }
        public AdditionalInfo AdditionalInfo { get; set; }
        #endregion Accountant record binding

        public AddAccountantRecordWindowViewModel(MainWindowViewModel model)
        {
            Model = model;
            Company = new Company();
            Requisites = new Requisites { Address = new Address() };
            ContactPerson = new ContactPerson();
            License = new License();
            //!!!!!!!!!!
            Product = new Product();
            Contract = new Contract();
            AdditionalInfo = new AdditionalInfo();

            AddAccountantRecordCommand = new RelayCommand<MetroWindow>(AddAccountantRecord);
        }

        private async void AddAccountantRecord(MetroWindow window)
        {
            var record = new AccountantRecord
            {
                Company = Company,
                Requisites = Requisites,
                ContactPerson = ContactPerson,
                License = License,

                Contract = Contract,
                AdditionalInfo = AdditionalInfo
            };

            await Model.AddNewAccountantRecordAsync(record);

            window.Close();
        }
    }
}