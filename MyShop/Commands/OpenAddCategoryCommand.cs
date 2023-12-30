using MyShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Commands
{
    public class OpenAddCategoryCommand : BaseCommand
    {
        private readonly ProductsViewModel _productsViewModel;

        public OpenAddCategoryCommand(ProductsViewModel productsViewModel)
        {
            _productsViewModel = productsViewModel;
        }

        public override async void Execute(object parameter)
        {
        }
    }
}
