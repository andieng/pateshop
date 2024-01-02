using System;
using System.Windows;
using System.Windows.Input;
using MyShop.Services;
using MyShop.ViewModels;

namespace MyShop.Commands
{
    public class SaveSettingsCommand : BaseCommand
    {
        private SettingsViewModel _settingsViewModel;

        public SaveSettingsCommand(SettingsViewModel settingsViewModel)
        {
            _settingsViewModel = settingsViewModel;
        }

        public override async void Execute(object parameter)
        {
            _settingsViewModel.SaveSettings();
        }
    }
}
