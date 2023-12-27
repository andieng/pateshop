using MyShop.Models;
using MyShop.ViewModels;
using MyShop.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyShop.Commands
{
    public class OpenUpdateCustomerCommand:BaseCommand
    {
        public OpenUpdateCustomerCommand() { }

        public override void Execute(object parameter)
        {
            if (parameter is Customer customer)
            {

                Window openUpdateCustomerCommand = new UpdateCustomerView()
                {
                    DataContext = new UpdateCustomerViewModel(customer)
                };
                openUpdateCustomerCommand.ShowDialog();
            }
        }
    }
}
