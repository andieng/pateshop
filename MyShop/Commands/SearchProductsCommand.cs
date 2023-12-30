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
    public class SearchProductsCommand : BaseCommand
    {
        private readonly ProductsViewModel _productsViewModel;

        public SearchProductsCommand(ProductsViewModel productsViewModel)
        {
            _productsViewModel = productsViewModel;
        }

        public override async void Execute(object parameter)
        {
            if (parameter is string searchText)
            {
                await _productsViewModel.PerformSearch(searchText);
            }
        }
    }
}
