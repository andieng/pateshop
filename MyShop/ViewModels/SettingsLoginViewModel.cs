using MyShop.Commands;
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

        public SettingsLoginViewModel()
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;

            _server = settings["Server"]?.Value;
            _database = settings["Database"]?.Value;

            InitCommands();
        }

        public void InitCommands()
        {
            SaveSettingsCommand = new SaveSettingsCommand(this);
            CancelCommand = new CancelCommand(this);
        }

        public BaseCommand SaveSettingsCommand { get; set; }
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
                Console.WriteLine("Error writing app settings");
            }
        }

        public bool SaveSettings()
        {
            UpsertSettings("Server", _server);
            UpsertSettings("Database", _database);
            return true;
        }
    }
}
