using System.Windows.Forms;
using AccountantTool.ViewModel;
using MahApps.Metro.Controls;
using unvell.ReoGrid;

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

            // Wrap winform control into WPF
            var grid = new ReoGridControl
            {
                Dock = DockStyle.Fill,
            };
            WindowsFormsHost.Child = grid;

            // Hide sheet tab control
            grid.SetSettings(WorkbookSettings.View_ShowSheetTabControl, false);

            DataContext = new MainWindowViewModel(grid.Worksheets[0]);
        }
    }
}