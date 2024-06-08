using LibraryManagementApp.ViewModels;
using LibraryManagementApp.Views;
using LibraryManagementApp.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;


namespace LibraryManagementApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindow = new MainWindow();
            var navigationService = new NavigationService(mainWindow.ContentControl);

            navigationService.Configure("HomeView", typeof(HomeView));
            

            var mainViewModel = new MainViewModel(navigationService);
            mainWindow.DataContext = mainViewModel;

            mainWindow.Show();
        }
    }
}
