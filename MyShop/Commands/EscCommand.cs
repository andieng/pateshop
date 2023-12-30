using MyShop.Models;
using MyShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyShop.Commands
{
    public class EscCommand : BaseCommand
    {
        public override async void Execute(object parameter)
        {
            if (parameter is Category category)
            {
                category.CategoryName = category.OldCategoryName;
                category.OldCategoryName = category.CategoryName;   
                category.CategoryNameVisibility = Visibility.Visible;
                category.InputCategoryNameVisibility = Visibility.Collapsed;
            }
        }
    }
}
