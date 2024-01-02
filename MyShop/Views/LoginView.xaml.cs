using HarfBuzzSharp;
using MyShop.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Windows.UI.WebUI;

namespace MyShop.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
            
            var reader = new AppSettingsReader();
            var rememberLastOpenedWindow = (bool)reader.GetValue("RememberLastOpenedWindow", typeof(bool));
            if (rememberLastOpenedWindow)
            {
                LoginWindow.Closing += SaveAppState;
            }

            DataContext = new LoginViewModel();
        }

        private void SaveAppState(object sender, CancelEventArgs e)
        {
            string sectionName = "appSettings";
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            string currentWindowState = LoginWindow.WindowState.ToString();
            if (config.AppSettings.Settings["WindowState"] == null)
            {
                config.AppSettings.Settings.Add("WindowState", currentWindowState);
            }
            else
            {
                config.AppSettings.Settings["WindowState"].Value = currentWindowState;
            }

            string currentWindowPositionTop = LoginWindow.Top.ToString("G");
            if (config.AppSettings.Settings["WindowPositionTop"] == null)
            {
                config.AppSettings.Settings.Add("WindowPositionTop", currentWindowPositionTop);
            }
            else
            {
                config.AppSettings.Settings["WindowPositionTop"].Value = currentWindowPositionTop;
            }

            string currentWindowPositionLeft = LoginWindow.Left.ToString("G");
            if (config.AppSettings.Settings["WindowPositionLeft"] == null)
            {
                config.AppSettings.Settings.Add("WindowPositionLeft", currentWindowPositionLeft);
            }
            else
            {
                config.AppSettings.Settings["WindowPositionLeft"].Value = currentWindowPositionLeft;
            }

            string currentWindow = LoginWindow.Name;
            if (config.AppSettings.Settings["Window"] == null)
            {
                config.AppSettings.Settings.Add("Window", currentWindow);
            }
            else
            {
                config.AppSettings.Settings["Window"].Value = currentWindow;
            }

            config.Save(ConfigurationSaveMode.Full);
            ConfigurationManager.RefreshSection(sectionName);
        }
    }
}
