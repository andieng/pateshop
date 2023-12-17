using MyShop.ViewModels;
using MyShop.Views;
using System;
using System.Configuration;
using System.Windows;

namespace MyShop.Commands
{
    public class OpenSettingsLoginCommand : BaseCommand
    {
        public OpenSettingsLoginCommand() { }

        public override void Execute(object parameter)
        {
            Window settings = new SettingsLoginView
            {
                DataContext = new SettingsLoginViewModel()
            };
            settings.ShowDialog();
        }
    }
}
