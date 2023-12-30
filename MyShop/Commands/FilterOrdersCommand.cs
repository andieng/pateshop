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
    public class FilterOrdersCommand : BaseCommand
    {
        private OrdersViewModel _orderdViewModel;

        public FilterOrdersCommand(OrdersViewModel ordersViewModel)
        {
            _orderdViewModel = ordersViewModel;
        }

        public override async void Execute(object parameter)
        {
            var temp = await ShopService.GetOrdersAsync(_orderdViewModel.Paging.Limit, 0, _orderdViewModel.StartOrderDate, _orderdViewModel.EndOrderDate);
            if(temp!= null)
            {
                _orderdViewModel.Orders = new ObservableCollection<Order>(temp.Value.Item1);
                _orderdViewModel.Paging = temp.Value.Item2;
            }

        }
    }
}
