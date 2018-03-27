using System.Globalization;
using System.Windows.Controls;
using System.Windows.Media;
using AccountantTool.ViewModel;
using MahApps.Metro.Controls;

namespace AccountantTool.View
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

        private void AccountantRecordsListMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var hitTestResult = VisualTreeHelper.HitTest(this, e.GetPosition(this));
            if (hitTestResult.VisualHit.GetType() != typeof(ListBoxItem))
            {
                //AccountantRecordsList.UnselectAll();
            }
        }
    }
}