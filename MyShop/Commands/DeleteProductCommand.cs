using MyShop.Services;
using MyShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Commands
{
    class DeleteProductCommand : BaseCommand
    {
        private readonly ProductsViewModel _productsViewModel;

        public DeleteProductCommand(ProductsViewModel productsViewModel)
        {
            _productsViewModel = productsViewModel;
        }

        public override async void Execute(object parameter)
        {
            var curProduct = _productsViewModel.CurProduct;
            bool finished = await ShopService.DeleteProduct(curProduct.ProductId, curProduct.CategoryId);
            if (finished)
            {
                _productsViewModel.CurView--;
                await _productsViewModel.LoadProductsOfCategory(curProduct.CategoryId);
                for (int i = 0; i < _productsViewModel.CategoriesList.Count; i++)
                {
                    if (_productsViewModel.CategoriesList[i].CategoryId == _productsViewModel.CurCategory.CategoryId)
                    {
                        _productsViewModel.CategoriesList[i].UpdatedDateTime = DateTime.Now;
                    }
                }
                _productsViewModel.CurProduct = null;
                _productsViewModel.BackCommand.Execute(null);
            }
        }
    }
}
