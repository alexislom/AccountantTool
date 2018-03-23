using AccountantTool.ViewModel;
using MahApps.Metro.Controls;

namespace AccountantTool.View
{
    /// <summary>
    /// Interaction logic for AddAccountantRecordWindow.xaml
    /// </summary>
    public partial class AddAccountantRecordWindow : MetroWindow
    {
        public AddAccountantRecordWindow(MainWindowViewModel model)
        {
            InitializeComponent();

            DataContext = new AddAccountantRecordWindowViewModel(model);
        }
    }
}
