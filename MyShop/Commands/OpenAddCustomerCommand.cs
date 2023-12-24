using MyShop.ViewModels;
using MyShop.Views;
using System;
using System.Windows;

namespace MyShop.Commands
{
    public class OpenAddCustomerCommand:BaseCommand
    {
        public OpenAddCustomerCommand() { }

        public override void Execute(object parameter)
        {
            Window openAddCustomer = new AddCustomerView()
            {
                DataContext = new AddCustomerViewModel()
            };
            openAddCustomer.ShowDialog();
        }
    }
}
