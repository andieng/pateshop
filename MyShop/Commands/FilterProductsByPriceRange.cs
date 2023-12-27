using MyShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyShop.Commands
{
    public class FilterProductsByPriceRange : BaseCommand
    {
        private readonly ProductsViewModel _productsViewModel;

        public FilterProductsByPriceRange(ProductsViewModel productsViewModel)
        {
            _productsViewModel = productsViewModel;
        }

        public override async void Execute(object parameter)
        {
            _productsViewModel.PerformFilter();
        }
    }
}
