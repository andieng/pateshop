using MyShop.Commands;
using MyShop.Models;
using MyShop.Services;
using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Net.Http;
using System.Security;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MyShop.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _username;
        private string _password;

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

        public LoginViewModel()
        {
            InitCommands();
        }

        public BaseCommand OpenSettingsLoginCommand { get; set; }
        public BaseCommand LoginCommand { get; set; }
        public void InitCommands()
        {
            OpenSettingsLoginCommand = new OpenSettingsLoginCommand();
            LoginCommand = new LoginCommand(this);
        }

        public async Task<User?> Login()
        {
            var user = await ShopService.LoginAsync(_username, _password);

            if (user != null)
            {
                UpsertSettings("LoginUsername", _username);
                UpsertSettings("LoginPassword", _password);
            }

            return user;
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
    }
}
