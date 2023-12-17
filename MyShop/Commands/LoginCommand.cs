using MyShop.Services;
using MyShop.ViewModels;
using MyShop.Views;
using System;
using System.Configuration;
using System.Windows;

namespace MyShop.Commands
{
    public class LoginCommand : BaseCommand
    {
        LoginViewModel _loginViewModel;

        public LoginCommand(LoginViewModel loginViewModel)
        {
            _loginViewModel = loginViewModel;
        }

        public override async void Execute(object parameter)
        {
            if (!ShopService.IsConnected)
            {
                ShopService.ShowFailedConnection();
                return;
            }
            var user = await _loginViewModel.Login();
            var data = await ShopService.GetCustomersAsync(3, 0);

            if (user != null)
            {
                Window mainView = new MainView();
                ((Window)parameter).Close();
                mainView.ShowDialog();
                return;
            } 


            ShopService.ShowLoginFailed();
        }
    }
}
