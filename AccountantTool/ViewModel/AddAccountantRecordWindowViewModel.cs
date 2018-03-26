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

        public Company Company { get; set; }



        public AddAccountantRecordWindowViewModel(MainWindowViewModel model)
        {
            Model = model;
            Company = new Company();

            AddAccountantRecordCommand = new RelayCommand<MetroWindow>(AddAccountantRecord);
        }

        private async void AddAccountantRecord(MetroWindow window)
        {
            var record = new AccountantRecord { Company = Company};

            await Model.AddNewAccountantRecordAsync(record);

            window.Close();
        }
    }
}