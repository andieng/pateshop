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
    public class SearchCustomerCommand:BaseCommand
    {
        private CustomersViewModel _customersViewModel;

        public SearchCustomerCommand(CustomersViewModel customersViewModel)
        {
            _customersViewModel = customersViewModel;
        }

        public override async void Execute(object parameter)
        {
            if (parameter is string q)
            {
               var data = await ShopService.searchCustomersAsync(100,0,q);
                _customersViewModel.Customers = new ObservableCollection<Customer>(data.Value.Item1);
                _customersViewModel.Paging = data.Value.Item2;

            }

        }
    }
}
