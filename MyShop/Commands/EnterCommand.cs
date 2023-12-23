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
                }
            }
        }
    }
}
