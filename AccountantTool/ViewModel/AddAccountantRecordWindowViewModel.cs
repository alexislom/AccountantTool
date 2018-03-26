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
        #endregion Accountant record binding

        public AddAccountantRecordWindowViewModel(MainWindowViewModel model)
        {
            Model = model;
            Company = new Company();
            Requisites = new Requisites { Address = new Address() };
            ContactPerson = new ContactPerson();

            AddAccountantRecordCommand = new RelayCommand<MetroWindow>(AddAccountantRecord);
        }

        private async void AddAccountantRecord(MetroWindow window)
        {
            var record = new AccountantRecord
            {
                Company = Company,
                Requisites = Requisites,
                ContactPerson = ContactPerson
            };

            await Model.AddNewAccountantRecordAsync(record);

            window.Close();
        }
    }
}