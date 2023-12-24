using MyShop.Models;
using MyShop.Services;
using MyShop.ViewModels;
using MyShop.Views;
using System;
using System.Configuration;
using System.Windows;
using System.Windows.Documents;

namespace MyShop.Commands
{
    public class CustomersCommand : BaseCommand
    {
        CustomersViewModel _customerViewModel;

        public CustomersCommand(CustomersViewModel customersViewModel)
        {
            _customerViewModel = customersViewModel;
        }

        public override async void Execute(object parameter)
        {
            int offset = _customerViewModel.Paging.Offset;
            int limit = _customerViewModel.Paging.Limit;
            int newOffset = 0;
            
            if (parameter.ToString()=="Next")
            {
                   newOffset =  offset + limit;
            }
            else
            {
                    newOffset = offset - limit;
            }


            var result = await ShopService.GetCustomersAsync(limit, newOffset);

            var (customers, paging) = result.Value;

            _customerViewModel.Customers = customers;
            _customerViewModel.Paging = paging;
        }
    }
}
