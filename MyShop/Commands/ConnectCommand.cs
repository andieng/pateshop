using System;
using System.Windows;
using System.Windows.Input;
using MyShop.Services;
using MyShop.ViewModels;

namespace MyShop.Commands
{
    public class ConnectCommand : BaseCommand
    {
        private SettingsLoginViewModel _settingsLoginViewModel;

        public ConnectCommand(SettingsLoginViewModel settingsViewModel)
        {
            _settingsLoginViewModel = settingsViewModel;
        }

        public override async void Execute(object parameter)
        {
            var result = await _settingsLoginViewModel.SaveSettings();
            if (!result)
            {
                ShopService.ShowFailedConnection();
                return;
            }
            _settingsLoginViewModel.Close((Window)parameter);
        }
    }
}
