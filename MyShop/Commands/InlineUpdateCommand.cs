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
    class InlineUpdateCommand : BaseCommand
    {
        private readonly ProductsViewModel _productsViewModel;

        public InlineUpdateCommand(ProductsViewModel productsViewModel)
        {
            _productsViewModel = productsViewModel;
        }

        public override void Execute(object parameter)
        {
            _productsViewModel.InputCategoryNameVisibility = Visibility.Visible;
            _productsViewModel.CategoryNameVisibility = Visibility.Collapsed;
        }
    }
}
