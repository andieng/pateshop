using System;
using System.Windows;
using System.Windows.Input;
using MyShop.ViewModels;

namespace MyShop.Commands
{
    public class CancelCommand : BaseCommand
    {
        private BaseModalViewModel _baseModalViewModel;

        public CancelCommand(BaseModalViewModel baseModalViewModel)
        {
            _baseModalViewModel = baseModalViewModel;
        }

        public override void Execute(object parameter)
        {
            _baseModalViewModel.Close((Window)parameter);
        }
    }
}
