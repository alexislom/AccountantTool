using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using AccountantTool.Model;
using AccountantTool.ViewModel.MainComponents;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using MahApps.Metro.Controls;

namespace AccountantTool.ViewModel
{
    public class AddAccountantRecordWindowViewModel
    {
        public MainWindowViewModel Model { get; }

        public Task<List<AccountantRecord>> Records { get; set; }

        public ICommand AddAccountantRecordCommand { get; set; }

        public AddAccountantRecordWindowViewModel(MainWindowViewModel model)
        {
            Model = model;
            Records = Model.Context.AccountantRecords.ToListAsync();

            AddAccountantRecordCommand = new RelayCommand<MetroWindow>(AddAccountantRecord);
        }

        private async void AddAccountantRecord(MetroWindow window)
        {
            var record = new AccountantRecord { };

            await Model.AddNewAccountantRecordAsync(record);

            window.Close();
        }

    }
}