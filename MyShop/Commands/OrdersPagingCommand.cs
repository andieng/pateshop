using MyShop.Services;
using MyShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Commands
{
    internal class OrdersPagingCommand:BaseCommand
    {
        OrdersViewModel _ordersViewModel;

        public OrdersPagingCommand(OrdersViewModel ordersViewModel)
        {
            _ordersViewModel = ordersViewModel;
        }

        public override async void Execute(object parameter)
        {
            int offset = _ordersViewModel.Paging.Offset;
            int limit = _ordersViewModel.Paging.Limit;
            int newOffset = 0;

            if (parameter.ToString() == "Next")
            {
                newOffset = offset + limit;
            }
            else
            {
                newOffset = offset - limit;
            }


            var result = await ShopService.GetOrdersAsync(limit, newOffset);

            var (orders, paging) = result.Value;

            _ordersViewModel.Orders = orders;
            _ordersViewModel.Paging = paging;
        }
    }
}
