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
    public class EnterCommand : BaseCommand
    {
        private readonly ProductsViewModel _productsViewModel;

        public EnterCommand(ProductsViewModel productsViewModel)
        {
            _productsViewModel = productsViewModel;
        }
        public override async void Execute(object parameter)
        {
            if (parameter is Category category)
            {
                var result = await ShopService.UpdateCategoryName(category.CategoryId, category.CategoryName);
                if (result)
                {
                    category.CategoryNameVisibility = Visibility.Visible;
                    category.InputCategoryNameVisibility = Visibility.Collapsed;
                    category.OldCategoryName = category.CategoryName;

                    for (int i = 0; i < _productsViewModel.CategoriesList.Count; i++)
                    {
                        if (_productsViewModel.CategoriesList[i].CategoryId == category.CategoryId)
                        {
                            _productsViewModel.CategoriesList[i].UpdatedDateTime = DateTime.Now;
                        }
                    }
                }
            }
        }
    }
}
