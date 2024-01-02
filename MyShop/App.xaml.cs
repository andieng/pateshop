using Microsoft.Extensions.DependencyInjection;
using MyShop.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.Hosting;
using MyShop.ViewModels;
using System.ComponentModel;
using MyShop.Views;

namespace MyShop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App() { }

        private async void Run(object sender, StartupEventArgs e)
        {
            ShopService.InitializeClient();

            var reader = new AppSettingsReader();
            var rememberLastOpenedWindow = (bool)reader.GetValue("RememberLastOpenedWindow", typeof(bool));
            if (!rememberLastOpenedWindow || !await RestoreWindow())
            {
                MainWindow = new LoginView();
            }

            MainWindow.Show();
        }

        protected async Task<bool> RestoreWindow()
        {
            var reader = new AppSettingsReader();

            string windowStateValue, windowName;
            int tab;
            try
            {
                windowStateValue = reader.GetValue("WindowState", typeof(string)) as string;
                windowName = reader.GetValue("Window", typeof(string)) as string;
                tab = (int)reader.GetValue("Tab", typeof(int));
            }
            catch (InvalidOperationException)
            {
                // There are no previously persisted values (first launch)
                // or user not set remember last opened window
                return false;
            }

            if (windowName == "MainWindow")
            {
                var mainViewModel = await MainViewModel.Create();
                MainWindow = new MainView
                {
                    Tag = tab,
                    DataContext = mainViewModel
                };
            } 
            else if (windowName == "LoginWindow")
            {
                MainWindow = new LoginView();
            }
            MainWindow.WindowStartupLocation = WindowStartupLocation.Manual;

            WindowState windowState;
            if (!string.IsNullOrWhiteSpace(windowStateValue) && Enum.TryParse(windowStateValue, out windowState))
            {
                MainWindow.WindowState = windowState;
            }

            string windowTopValue = reader.GetValue("WindowPositionTop", typeof(string)) as string;
            string windowLeftValue = reader.GetValue("WindowPositionLeft", typeof(string)) as string;

            double windowPositionTop;
            double windowPositionLeft;
            if (!string.IsNullOrWhiteSpace(windowStateValue)
                && double.TryParse(windowTopValue, out windowPositionTop)
                && double.TryParse(windowLeftValue, out windowPositionLeft))
            {
                MainWindow.Top = windowPositionTop;
                MainWindow.Left = windowPositionLeft;
            }

            return true;
        }
    }
}
