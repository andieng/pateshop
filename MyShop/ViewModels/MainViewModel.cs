using MyShop.Commands;
using MyShop.Models;
using MyShop.Services;
using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows;

namespace MyShop.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public User User { get; private set; }

        public static async Task<MainViewModel> Create()
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;

            var user = await ShopService.LoginAsync(settings["LoginUsername"].Value, settings["LoginPassword"].Value);
            if (user == null)
            {
                throw new Exception("Login failed");
            }
            return new MainViewModel(user);
        }

        public MainViewModel(User user)
        {
            User = user;
            initCommands();
        }

        public BaseCommand OpenSettingsCommand { get; set; }
        public BaseCommand LogoutCommand { get; set; }
        public void initCommands()
        {
            LogoutCommand = new LogoutCommand(this);
        }

        public async Task<bool> Logout()
        {
            return await ShopService.LogoutAsync();
        }
    }
}
