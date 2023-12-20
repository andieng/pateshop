using MyShop.Models;
using MyShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Commands
{
    class BackCommand : BaseCommand
    {
        private readonly ProductsViewModel _productsViewModel;

        public BackCommand(ProductsViewModel productsViewModel)
        {
            _productsViewModel = productsViewModel;
        }

        public override async void Execute(object parameter)
        {
            if (_productsViewModel.CurView == 0)
            {
                _productsViewModel.CategoryListVisibility = System.Windows.Visibility.Visible;
                _productsViewModel.CategoryDetailVisibility = System.Windows.Visibility.Collapsed;
                _productsViewModel.BackBtnVisibility = System.Windows.Visibility.Hidden;
            }
            else
            {
                _productsViewModel.CurView--;
                switch (_productsViewModel.CurView)
                {
                    case 0:
                        _productsViewModel.CategoryListVisibility = System.Windows.Visibility.Visible;
                        _productsViewModel.CategoryDetailVisibility = System.Windows.Visibility.Collapsed;
                        _productsViewModel.BackBtnVisibility = System.Windows.Visibility.Hidden;
                        break;
                }
            }
        }
    }
}
