using MyShop.Commands;
using MyShop.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyShop.ViewModels
{
    public class SettingsLoginViewModel : BaseModalViewModel
    {
        private string _server;
        private string _database;
        private string _username;
        private string _password;

        public string Server
        {
            get => _server;
            set
            {
                if (_server != value)
                {
                    _server = value;
                }
            }
        }

        public string Database
        {
            get => _database;
            set
            {
                if (_database != value)
                {
                    _database = value;
                }
            }
        }

        public string Username
        {
            get => _username;
            set
            {
                if (_username != value)
                {
                    _username = value;
                }
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                if (_password != value)
                {
                    _password = value;
                }
            }
        }

        public SettingsLoginViewModel()
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;

            _server = settings["PGServer"].Value;
            _database = settings["PGDatabase"].Value;
            _username = settings["PGUsername"].Value;
            _password = settings["PGPassword"].Value;

            InitCommands();
        }

        public void InitCommands()
        {
            ConnectCommand = new ConnectCommand(this);
            CancelCommand = new CancelCommand(this);
        }

        public BaseCommand ConnectCommand { get; set; }
        public BaseCommand CancelCommand { get; set; }

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

        public async Task<bool> SaveSettings()
        {
            UpsertSettings("PGServer", _server);
            UpsertSettings("PGDatabase", _database);
            UpsertSettings("PGUsername", _username);
            UpsertSettings("PGPassword", _password);

            return await ShopService.ConnectAsync();
        }
    }
}
