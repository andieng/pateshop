using MyShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Data;
using System.ComponentModel;
using System.Configuration;
using System.Windows.Threading;
using MyShop.Commands;

namespace MyShop.Views
{
    public partial class MainView : Window
    {
        private bool _isFirstTimeOpened = true;

        public MainView()
        {
            InitializeComponent();

            var reader = new AppSettingsReader();
            var rememberLastOpenedWindow = (bool)reader.GetValue("RememberLastOpenedWindow", typeof(bool));
            if (rememberLastOpenedWindow)
            {
                MainWindow.Closing += SaveAppState;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _isFirstTimeOpened = false;
        }

        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            var tabControl = sender as TabControl;

            if (tabControl != null)
            {
                if (_isFirstTimeOpened && MainWindow.Tag != null)
                {
                    tabControl.SelectedIndex = int.Parse(MainWindow.Tag.ToString());
                }
                var index = tabControl.SelectedIndex;
                if (!_isFirstTimeOpened)
                {
                    MainWindow.Tag = index;
                }
                if (index == 0) 
                { 
                    dashboardTimeStackPanel.Visibility = Visibility.Visible;
                    dashboardTimeTextBlock.Text = DateTime.Now.ToString(@"MM\/yyyy");
                }
                else    
                { 
                    dashboardTimeStackPanel.Visibility = Visibility.Collapsed; 
                }
            }
        }

        private void SaveAppState(object sender, CancelEventArgs e)
        {
            string sectionName = "appSettings";
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            string currentWindowState = MainWindow.WindowState.ToString();
            if (config.AppSettings.Settings["WindowState"] == null)
            {
                config.AppSettings.Settings.Add("WindowState", currentWindowState);
            }
            else
            {
                config.AppSettings.Settings["WindowState"].Value = currentWindowState;
            }

            string currentWindowPositionTop = MainWindow.Top.ToString("G");
            if (config.AppSettings.Settings["WindowPositionTop"] == null)
            {
                config.AppSettings.Settings.Add("WindowPositionTop", currentWindowPositionTop);
            }
            else
            {
                config.AppSettings.Settings["WindowPositionTop"].Value = currentWindowPositionTop;
            }

            string currentWindowPositionLeft = MainWindow.Left.ToString("G");
            if (config.AppSettings.Settings["WindowPositionLeft"] == null)
            {
                config.AppSettings.Settings.Add("WindowPositionLeft", currentWindowPositionLeft);
            }
            else
            {
                config.AppSettings.Settings["WindowPositionLeft"].Value = currentWindowPositionLeft;
            }

            string currentWindow = MainWindow.Name;
            if (config.AppSettings.Settings["Window"] == null)
            {
                config.AppSettings.Settings.Add("Window", currentWindow);
            }
            else
            {
                config.AppSettings.Settings["Window"].Value = currentWindow;
            }

            string currentTab = MainWindow.Tag.ToString();
            if (config.AppSettings.Settings["Tab"] == null)
            {
                config.AppSettings.Settings.Add("Tab", currentTab);
            }
            else
            {
                config.AppSettings.Settings["Tab"].Value = currentTab;
            }

            config.Save(ConfigurationSaveMode.Full);
            ConfigurationManager.RefreshSection(sectionName);
        }
    }
}
