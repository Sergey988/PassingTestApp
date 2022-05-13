using LeftMenuApp.Services;
using LeftMenuApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LeftMenuApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    ///
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var loginService = new LoginService();
            var mainViewModel = new MainViewModel(loginService);
            var window = new MainWindow { DataContext = mainViewModel };
            App.Current.MainWindow = window;

            window.Show();
        }
    }
}
