using MyShop.Models;
using MyShop.Services;
using MyShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyShop.Commands
{
    internal class DeleteCustomerCommand:BaseCommand
    {
        private CustomersViewModel _customersViewModel;

        public DeleteCustomerCommand(CustomersViewModel customersViewModel)
        {
            _customersViewModel = customersViewModel;

        }

        public override async void Execute(object parameter)
        {
            if (parameter is int customerId)
            {
                await ShopService.DeleteCustomerAsync(customerId);
                var temp = await ShopService.GetCustomersAsync(5, 0);
                _customersViewModel.Customers = new ObservableCollection<Customer>(temp.Value.Item1);
                _customersViewModel.Paging = temp.Value.Item2;
            }
        }
    }
}
