using MyShop.Models;
using MyShop.Services;
using MyShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyShop.Commands
{
    public class BackOrderCommand:BaseCommand
    {
        private readonly OrdersViewModel _ordersViewModel;

        public BackOrderCommand(OrdersViewModel ordersViewModel)
        {
            _ordersViewModel = ordersViewModel;
        }

        public override async void Execute(object parameter)
        {

                
                _ordersViewModel.OrderDetailVisibility = Visibility.Hidden;
            _ordersViewModel.OrderVisibility = Visibility.Visible;

        }
    }
}
