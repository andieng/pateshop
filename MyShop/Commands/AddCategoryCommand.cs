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
    public class AddCategoryCommand : BaseCommand
    {
        private readonly ProductsViewModel _productsViewModel;

        public AddCategoryCommand(ProductsViewModel productsViewModel)
        {
            _productsViewModel = productsViewModel;
        }

        public override async void Execute(object parameter)
        {
            var newCategoryName = _productsViewModel.NewCategory.CategoryName;
            await _productsViewModel.AddCategory(newCategoryName);
        }
    }
}
