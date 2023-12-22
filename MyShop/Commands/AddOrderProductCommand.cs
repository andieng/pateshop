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
    public class AddOrderProductCommand : BaseCommand
    {
        public AddOrderProductCommand() { }

        public override void Execute(object parameter)
        {
            Window openAddOrderProduct = new AddOrderProductView()
            {
                DataContext = new AddOrderProductViewModel()
            };
            openAddOrderProduct.ShowDialog();
        }
    }
}
