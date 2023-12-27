using MyShop.Models;
using MyShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
                _productsViewModel.CategoryListVisibility = Visibility.Visible;
                _productsViewModel.CategoryDetailVisibility = Visibility.Collapsed;
                _productsViewModel.ProductDetailVisibility = Visibility.Collapsed;
                _productsViewModel.BackBtnVisibility = Visibility.Hidden;
                _productsViewModel.OriginalResultList = null;
            }
            else
            {
                _productsViewModel.CurView--;
                switch (_productsViewModel.CurView)
                {
                    case 0: // trang list các category
                        _productsViewModel.CategoryListVisibility = Visibility.Visible;
                        _productsViewModel.CategoryDetailVisibility = Visibility.Collapsed;
                        _productsViewModel.BackBtnVisibility = Visibility.Hidden;
                        _productsViewModel.SearchResultVisibility = Visibility.Collapsed;
                        _productsViewModel.CurCategory = null;
                        _productsViewModel.CurProduct = null;
                        _productsViewModel.OriginalResultList = null;

                        break;
                    case 1: // trang list các products của category 
                        if (_productsViewModel.CurCategory != null)
                        {
                            _productsViewModel.CategoryListVisibility = Visibility.Collapsed;
                            _productsViewModel.CategoryDetailVisibility = Visibility.Visible;
                            _productsViewModel.ProductDetailVisibility = Visibility.Collapsed;
                            _productsViewModel.SearchBarVisibility = Visibility.Visible;
                            _productsViewModel.AddProductVisibility = Visibility.Collapsed;
                            _productsViewModel.SearchResultVisibility = Visibility.Collapsed;
                        }
                        else
                        {
                            _productsViewModel.SearchBarVisibility = Visibility.Visible;
                            _productsViewModel.ProductDetailVisibility = Visibility.Collapsed;
                            _productsViewModel.SearchResultVisibility = Visibility.Visible;
                        }
                        break;
                    case 2: // trang product detail
                        _productsViewModel.CategoryDetailVisibility = Visibility.Collapsed;
                        _productsViewModel.ProductDetailVisibility = Visibility.Visible;
                        _productsViewModel.SearchBarVisibility = Visibility.Hidden;
                        _productsViewModel.EditProductVisibility = Visibility.Collapsed;
                        break;
                }
            }
        }
    }
}
