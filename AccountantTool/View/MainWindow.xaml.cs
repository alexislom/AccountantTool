using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using AccountantTool.ViewModel;
using MahApps.Metro.Controls;
using unvell.ReoGrid;
using UIControls;
using MessageBox = System.Windows.MessageBox;

namespace AccountantTool.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindowViewModel ViewModel { get; set; }
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

            ViewModel = (MainWindowViewModel)DataContext;

            ContentRendered += MainWindow_ContentRendered;

            // SearchTextBox settings----------------------------------------------------

            // Supply the control with the list of sections
            var sections = new List<string> { "All", "Companies", "Requisites", "Contact persons", "License", "Products", "Contracts", "Additional info" };
            SearchTextBox.SectionsList = sections;

            // Choose a style for displaying sections
            SearchTextBox.SectionsStyle = SearchTextBox.SectionsStyles.CheckBoxStyle;

            // Add a routine handling the event OnSearch
            SearchTextBox.OnSearch += OnSearch;
            // --------------------------------------------------------------------------
        }

        private void OnSearch(object sender, RoutedEventArgs e)
        {
            var searchArgs = e as SearchEventArgs;

            ViewModel.OnSearch(searchArgs);
        }

        private async void MainWindow_ContentRendered(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.LastFileName == null)
                return;
            if (!File.Exists(Properties.Settings.Default.LastFileName))
                return;

            var messageBoxResult = MessageBox.Show($"{(ViewModel.IsEnglishLanguage ? "Do you want to load last used file?" : "Вы хотите загрузить последний использованный файл?")}" + Environment.NewLine +
                                                   Properties.Settings.Default.LastFileName, $"{(ViewModel.IsEnglishLanguage ? "Restore last used file" : "Восстановить последний используемый файл")}", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                await ViewModel.RestoreLastFile(Properties.Settings.Default.LastFileName);
            }
        }
    }
}