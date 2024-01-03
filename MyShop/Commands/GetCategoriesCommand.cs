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
    public class GetCategoriesCommand : BaseCommand
    {

        ProductsViewModel _productsViewModel;

        public GetCategoriesCommand(ProductsViewModel productsViewModel)
        {
            _productsViewModel = productsViewModel;
        }

        public override async void Execute(object parameter)
        {
            int offset = _productsViewModel.CategoryPaging.Offset;
            int limit = _productsViewModel.CategoryPaging.Limit;
            int newOffset = 0;

            if (parameter.ToString() == "Next")
            {
                newOffset = offset + limit;
            }
            else
            {
                newOffset = offset - limit;
            }

            var result = await ShopService.GetAllCategories(limit, newOffset);

            var (categories, paging) = result.Value;

            _productsViewModel.CategoriesList = new ObservableCollection<Category>(categories);
            _productsViewModel.CategoryPaging = paging;
        }
    }
}
