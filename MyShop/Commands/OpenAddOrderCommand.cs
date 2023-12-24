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
    internal class OpenAddOrderCommand:BaseCommand
    {
        public OpenAddOrderCommand() { }

        public override void Execute(object parameter)
        {
            Window openAddOrder = new AddOrderView()
            {
                DataContext = new AddOrderViewModel()
            };
            openAddOrder.ShowDialog();
        }
    }
}
