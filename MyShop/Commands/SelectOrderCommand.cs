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
    internal class SelectOrderCommand : BaseCommand
    {
        private readonly OrdersViewModel _ordersViewModel;

        public SelectOrderCommand(OrdersViewModel ordersViewModel)
        {
            _ordersViewModel = ordersViewModel;
        }

        public override async void Execute(object parameter)
        {
            
            if (parameter is Order orderSelected)
            {
                
                _ordersViewModel.OrderDetail = await ShopService.GetOrderDetailAsync(orderSelected.OrderId);
                _ordersViewModel.OrderVisibility = Visibility.Hidden;
                _ordersViewModel.OrderDetailVisibility = Visibility.Visible;
            }
        }
    }
}
