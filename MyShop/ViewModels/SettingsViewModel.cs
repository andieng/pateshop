using MyShop.Commands;
using MyShop.Services;
using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows;

namespace MyShop.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        private int _itemsPerPageOrders;
        private int _itemsPerPageProducts;
        private int _itemsPerPageCustomers;
        private bool _rememberLastOpenedWindow;

        public int ItemsPerPageOrders
        {
            get => _itemsPerPageOrders;
            set
            {
                _itemsPerPageOrders = value;
                OnPropertyChanged("ItemsPerPageOrders");
            }
        }

        public int ItemsPerPageProducts
        {
            get => _itemsPerPageProducts;
            set
            {
                _itemsPerPageProducts = value;
                OnPropertyChanged("ItemsPerPageProducts");
            }
        }

        public int ItemsPerPageCustomers
        {
            get => _itemsPerPageCustomers;
            set
            {
                _itemsPerPageCustomers = value;
                OnPropertyChanged("ItemsPerPageCustomers");
            }
        }

        public bool RememberLastOpenedWindow
        {
            get => _rememberLastOpenedWindow;
            set
            {
                _rememberLastOpenedWindow = value;
                OnPropertyChanged("RememberLastOpenedWindow");
            }
        }

        public SettingsViewModel()
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;

            _itemsPerPageOrders = int.Parse(settings["ItemsPerPage_Orders"].Value);
            _itemsPerPageProducts = int.Parse(settings["ItemsPerPage_Products"].Value);
            _itemsPerPageCustomers = int.Parse(settings["ItemsPerPage_Customers"].Value);
            _rememberLastOpenedWindow = bool.Parse(settings["RememberLastOpenedWindow"].Value);

            initCommands();
        }

        public BaseCommand SaveSettingsCommand { get; set; }

        public void initCommands()
        {
            SaveSettingsCommand = new SaveSettingsCommand(this);
        }

        public void UpsertSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }

                // Save settings
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error while modified app settings");
            }
        }

        public void SaveSettings()
        {
            UpsertSettings("ItemsPerPage_Orders", _itemsPerPageOrders.ToString());
            UpsertSettings("ItemsPerPage_Customers", _itemsPerPageCustomers.ToString());
            UpsertSettings("ItemsPerPage_Products", _itemsPerPageProducts.ToString());
            UpsertSettings("RememberLastOpenedWindow", _rememberLastOpenedWindow.ToString());

            string messageBoxText = "Save settings successfully, restart app to see changes.";
            string caption = "Save settings";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Asterisk;
            MessageBox.Show(messageBoxText, caption, button, icon);
        }
    }
}
