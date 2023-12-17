using MyShop.Services;
using MyShop.ViewModels;
using MyShop.Views;
using System;
using System.Configuration;
using System.Windows;

namespace MyShop.Commands
{
    public class LogoutCommand : BaseCommand
    {
        MainViewModel _mainViewModel;

        public LogoutCommand(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public override async void Execute(object parameter)
        {
            var isLoggedOut = await _mainViewModel.Logout();
            if (isLoggedOut)
            {
                Window loginView = new LoginView
                {
                    DataContext = new LoginViewModel()
                };
                ((Window)parameter).Close();
                loginView.ShowDialog();
            } 
            else
            {
                ShopService.ShowLogoutFailed();
            }
        }
    }
}
