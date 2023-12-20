using MyShop.Models;
using MyShop.Services;
using MyShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MyShop.Commands
{
    public class UpdateCommand : BaseCommand
    {
        private readonly ProductsViewModel _productsViewModel;

        public UpdateCommand(ProductsViewModel productsViewModel)
        {
            _productsViewModel = productsViewModel;
        }

        public override void Execute(object parameter)
        {
            var editedProduct = _productsViewModel.EditedProduct;
            ShopService.UpdateProduct(_productsViewModel.CurProduct.CategoryId, editedProduct);
        }
    }
}
