using System;
using System.Windows;
using System.Windows.Input;
using MyShop.ViewModels;

namespace MyShop.Commands
{
    public class SaveSettingsCommand : BaseCommand
    {
        private SettingsLoginViewModel _settingsViewModel;

        public SaveSettingsCommand(SettingsLoginViewModel settingsViewModel)
        {
            _settingsViewModel = settingsViewModel;
        }

        public override void Execute(object parameter)
        {
            if (_settingsViewModel.SaveSettings())
            {
                _settingsViewModel.Close((Window)parameter);
            }
        }
    }
}
