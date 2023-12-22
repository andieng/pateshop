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
    public class UpdateCustomerCommand:BaseCommand
    {
        private UpdateCustomerViewModel _updateCustomerViewModel;

        public UpdateCustomerCommand(UpdateCustomerViewModel updateCustomerViewModel)
        {
            _updateCustomerViewModel = updateCustomerViewModel;
        }

        public override async void Execute(object parameter)
        {
            object data = new
            {
                customerName = _updateCustomerViewModel.CustomerName,
                email = _updateCustomerViewModel.Email,
                phoneNumber = _updateCustomerViewModel.PhoneNumber,
                address = _updateCustomerViewModel.Address
            };
            if (data != null)
            {
                await ShopService.UpdateCustomer(data,_updateCustomerViewModel.CustomerId);
            }
            _updateCustomerViewModel.Close((Window)parameter);
        }
    }
}
