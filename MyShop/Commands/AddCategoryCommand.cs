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

            var result = await ShopService.AddCategory(newCategoryName);
            if (result != 0)
            {
                DateTime currentDate = DateTime.Now;
                Category newCategory = new Category(result, newCategoryName, currentDate.ToString(), currentDate.ToString());
                _productsViewModel.CategoriesList.Add(newCategory);
                _productsViewModel.NewCategory.CategoryName = "";
            }
        }
    }
}
