using MyShop.Models;
using MyShop.Services;
using MyShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Commands
{
    public class DeleteOrderCommand:BaseCommand
    {
        private OrdersViewModel _ordersViewModel;

        public DeleteOrderCommand(OrdersViewModel ordersViewModel)
        {
            _ordersViewModel = ordersViewModel;

        }

        public override async void Execute(object parameter)
        {
            if (parameter is int id)
            {
                await ShopService.DeleteOrderAsync(id);
                var temp = await ShopService.GetOrdersAsync(_ordersViewModel.Paging.Limit, 0);
                _ordersViewModel.Orders = new ObservableCollection<Order>(temp.Value.Item1);
                _ordersViewModel.Paging = temp.Value.Item2;

            }
        }
    }
}
