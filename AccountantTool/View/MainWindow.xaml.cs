using System.Globalization;
using AccountantTool.ViewModel;
using MahApps.Metro.Controls;

namespace AccountantTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            var currentLanguage = App.SelectedLanguage;
            App.SelectedLanguage = new CultureInfo("en-US");
            App.SelectedLanguage = new CultureInfo("ru-RU");
            DataContext = new MainWindowViewModel();
        }
    }
}