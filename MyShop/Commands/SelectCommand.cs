using MyShop.Models;
using MyShop.Services;
using MyShop.ViewModels;
using MyShop.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MyShop.Commands
{
    public class SelectCommand : BaseCommand
    {
        private readonly ProductsViewModel _productsViewModel;

        public SelectCommand(ProductsViewModel productsViewModel)
        {
            _productsViewModel = productsViewModel;
        }

        public override async void Execute(object parameter)
        {
            if (parameter is Category selectedCategory)
            {
                _productsViewModel.CurCategory = selectedCategory.CategoryName;
                await _productsViewModel.LoadProductsOfCategory(selectedCategory.CategoryId);
            }
        }
    }
}
