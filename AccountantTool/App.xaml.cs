using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Markup;
using AccountantTool.Common;
using MahApps.Metro;

namespace AccountantTool
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static event EventHandler LanguageChanged;

        public static List<CultureInfo> Languages { get; } = new List<CultureInfo>();

        public App()
        {
            InitializeComponent();
            LanguageChanged += ApplicationLanguageChanged;

            Languages.Clear();
            Languages.Add(new CultureInfo("en-US"));
            Languages.Add(new CultureInfo("ru-RU"));

            SelectedLanguage = AccountantTool.Properties.Settings.Default.Language;
        }

        public static CultureInfo SelectedLanguage
        {
            get => Thread.CurrentThread.CurrentUICulture;
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));
                if (Equals(value, Thread.CurrentThread.CurrentUICulture))
                    return;

                Thread.CurrentThread.CurrentUICulture = value;

                var dictionary = new ResourceDictionary();

                switch (value.Name)
                {
                    case "ru-RU":
                        dictionary.Source = new Uri($"Resources/Language.{value.Name}.xaml", UriKind.Relative);
                        break;
                    default:
                        dictionary.Source = new Uri("Resources/Language.xaml", UriKind.Relative);
                        break;
                }

                ResourceDictionary oldDictionary = (from d in Current.Resources.MergedDictionaries
                                                    where d.Source != null && d.Source.OriginalString.StartsWith("Resources/Language.")
                                                    select d).First();

                if (oldDictionary != null)
                {
                    int index = Current.Resources.MergedDictionaries.IndexOf(oldDictionary);
                    Current.Resources.MergedDictionaries.Remove(oldDictionary);
                    Current.Resources.MergedDictionaries.Insert(index, dictionary);
                }
                else
                {
                    Current.Resources.MergedDictionaries.Add(dictionary);
                }
                LanguageChanged.Raise(Current);
            }
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement),
                                    new FrameworkPropertyMetadata(XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));

            // Get the current app style (theme and accent) from the application
            // you can then use the current theme and custom accent instead set a new theme
            Tuple<AppTheme, Accent> appStyle = ThemeManager.DetectAppStyle(Current);

            // Now set the accent and theme
            ThemeManager.ChangeAppStyle(Current, ThemeManager.GetAccent("Cobalt"),
                                                 ThemeManager.GetAppTheme("BaseLight")); // or appStyle.Item1(it's turple)
            base.OnStartup(e);
        }

        private void ApplicationLanguageChanged(object sender, EventArgs e)
        {
            AccountantTool.Properties.Settings.Default.Language = SelectedLanguage;
            AccountantTool.Properties.Settings.Default.Save();
        }
    }
}