using System;
using System.Windows;
using System.Windows.Input;
using MyShop.Services;
using MyShop.ViewModels;

namespace MyShop.Commands
{
    public class ConnectCommand : BaseCommand
    {
        private SettingsLoginViewModel _settingsViewModel;

        public ConnectCommand(SettingsLoginViewModel settingsViewModel)
        {
            _settingsViewModel = settingsViewModel;
        }

        public override async void Execute(object parameter)
        {
            var result = await _settingsViewModel.SaveSettings();
            if (!result)
            {
                ShopService.ShowFailedConnection();
                return;
            }
            _settingsViewModel.Close((Window)parameter);
        }
    }
}
