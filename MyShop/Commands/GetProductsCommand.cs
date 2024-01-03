using MyShop.Models;
using MyShop.Services;
using MyShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Commands
{
    public class GetProductsCommand : BaseCommand
    {
        ProductsViewModel _productsViewModel;

        public GetProductsCommand(ProductsViewModel productsViewModel)
        {
            _productsViewModel = productsViewModel;
        }

        public override async void Execute(object parameter)
        {
            int offset = _productsViewModel.ProductPaging.Offset;
            int limit = _productsViewModel.ProductPaging.Limit;
            int newOffset = 0;

            if (parameter.ToString() == "Next")
            {
                newOffset = offset + limit;
            }
            else
            {
                newOffset = offset - limit;
            }

            var result = await ShopService.GetProductsOfCategory(_productsViewModel.CurCategory.CategoryId, limit, newOffset);

            var (products, paging) = result.Value;

            _productsViewModel.ProductsList = new ObservableCollection<Product>(products);
            _productsViewModel.ProductPaging = paging;
        }
    }
}
