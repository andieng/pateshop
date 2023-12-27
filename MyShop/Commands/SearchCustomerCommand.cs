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
    public class SearchCustomerCommand:BaseCommand
    {
        private CustomersViewModel _customersViewModel;

        public SearchCustomerCommand(CustomersViewModel customersViewModel)
        {
            _customersViewModel = customersViewModel;
        }

        public override async void Execute(object parameter)
        {
            if (parameter != "")
            {
               // await ShopService.UpdateOrder(data, _ordersCustomerViewModel.OrderDetail.OrderId);
            }
            //await ShopService.GetOrderDetailAsync(_ordersCustomerViewModel.OrderDetail.OrderId);

        }
    }
}
