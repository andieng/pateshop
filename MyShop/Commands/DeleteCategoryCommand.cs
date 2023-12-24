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
    public class DeleteCategoryCommand : BaseCommand
    {
        private readonly ProductsViewModel _productsViewModel;

        public DeleteCategoryCommand(ProductsViewModel productsViewModel)
        {
            _productsViewModel = productsViewModel;
        }

        public override async void Execute(object parameter)
        {
            if (parameter is Category category)
            {
                var result = await ShopService.DeleteCategory(category.CategoryId);
                if (result)
                {
                    Category categoryToRemove = _productsViewModel.CategoriesList.FirstOrDefault(curCategory => curCategory.CategoryId == category.CategoryId);
                    if (categoryToRemove != null)
                    {
                        _productsViewModel.CategoriesList.Remove(categoryToRemove);
                    }
                }
            }
        }
    }
}
