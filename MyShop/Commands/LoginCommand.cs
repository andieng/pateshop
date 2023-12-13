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

        public override void Execute(object parameter)
        {
            _loginViewModel.Login();
        }
    }
}
