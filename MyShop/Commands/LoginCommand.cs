using MyShop.Services;
using MyShop.ViewModels;
using MyShop.Views;
using Newtonsoft.Json.Linq;
using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MyShop.Commands
{
    public class LoginCommand : BaseCommand
    {
        LoginViewModel? _loginViewModel;

        public LoginCommand(LoginViewModel loginViewModel)
        {
            _loginViewModel = loginViewModel;
        }

        public override async void Execute(object parameter)
        {
            if (_loginViewModel != null)
            {
                if (!ShopService.IsConnected)
                {
                    ShopService.ShowFailedConnection();
                    return;
                }
                var user = await _loginViewModel.Login();
                if (user != null)
                {
                    Window mainView = new MainView
                    {
                        DataContext = new MainViewModel(user)
                    };
                    ((Window)parameter).Close();
                    mainView.ShowDialog();
                    return;
                }
            }

            ShopService.ShowLoginFailed();
        }
    }
}
