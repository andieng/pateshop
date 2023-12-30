using MyShop.Services;
using MyShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Commands
{
    class AddProductCommand : BaseCommand
    {
        private readonly ProductsViewModel _productsViewModel;

        public AddProductCommand(ProductsViewModel productsViewModel)
        {
            _productsViewModel = productsViewModel;
        }

        public override async void Execute(object parameter)
        {
            var newProduct = _productsViewModel.NewProduct;
            bool finished = await ShopService.AddProduct(newProduct);
            if (finished)
            {
                _productsViewModel.CurView--;
                await _productsViewModel.LoadProductsOfCategory(newProduct.CategoryId);
            }
        }
    }
}
