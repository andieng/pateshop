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
    internal class AddCustomerCommand:BaseCommand
    {
        private AddCustomerViewModel _addCustomerViewModel;

        public AddCustomerCommand(AddCustomerViewModel addCustomerViewModel)
        {
            _addCustomerViewModel = addCustomerViewModel;
        }

        public override async void Execute(object parameter)
        {

            object data = new
            {
                customerName = _addCustomerViewModel.CustomerName,
                email = _addCustomerViewModel.Email,
                phoneNumber = _addCustomerViewModel.PhoneNumber,
                address = _addCustomerViewModel.Address
            };
            if (data != null)
            {
                await ShopService.AddCustomer(data);
            }

            _addCustomerViewModel.Close((Window)parameter);
        }
    }
}
