using DogFetchApp.ViewModels;
using System.Threading;
using System.Windows;

namespace DogFetchApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel currentViewmodel;
        
        public MainWindow()
        {
            var lang = DogFetchApp.Properties.Settings.Default.Language;
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(lang);
            InitializeComponent();
            ApiHelper.ApiHelper.InitializeClient();
            currentViewmodel = new MainViewModel();

            DataContext = currentViewmodel;
        }
    }
}
