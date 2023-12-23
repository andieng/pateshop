using MyShop.Models;
using MyShop.Services;
using MyShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MyShop.Commands
{
    public class InlineUpdateCommand : BaseCommand
    {
        public override void Execute(object parameter)
        {
            if (parameter is Category category)
            {
                category.InputCategoryNameVisibility = Visibility.Visible;
                category.CategoryNameVisibility = Visibility.Collapsed;
            }
        }
    }
}
