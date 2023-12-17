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
            return user;
        }
    }
}
