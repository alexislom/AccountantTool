using System.Windows;
using System.Windows.Input;
using AccountantTool.ViewModel.MainComponents;

namespace AccountantTool.ViewModel
{
    public class MainWindowViewModel
    {
        private ICommand _command;

        public ICommand Command
        {
            get
            {
                return _command ?? (_command = new RelayCommand(
                           x =>
                           {
                               DoStuff();
                           }));
            }

        }

        private static void DoStuff()
        {
            MessageBox.Show("Responding to button click event...");
        }
    }
}