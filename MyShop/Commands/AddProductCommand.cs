using MyShop.Services;
using MyShop.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
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
            if (_productsViewModel.SelectedImg != null)
            {
                string currentDirectory = Directory.GetCurrentDirectory();
                string projectDirectory = currentDirectory.Substring(0, currentDirectory.IndexOf("\\MyShop") + "\\MyShop".Length);

                string destinationFolder = Path.Combine(projectDirectory, "Resources", "Products");

                string selectedFileName = Path.GetFileName(_productsViewModel.SelectedImg);

                string destinationFilePath = Path.Combine(destinationFolder, selectedFileName);

                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(selectedFileName);
                string fileExtension = Path.GetExtension(selectedFileName);

                int counter = 1;
                while (File.Exists(destinationFilePath))
                {
                    string newFileName = $"{fileNameWithoutExtension}_{counter}{fileExtension}";
                    destinationFilePath = Path.Combine(destinationFolder, newFileName);
                    counter++;
                }

                File.Copy(_productsViewModel.SelectedImg, destinationFilePath);
                counter--;
                _productsViewModel.SelectedImg = null;
                _productsViewModel.NewProduct.Image = fileNameWithoutExtension + "_" + counter + fileExtension;
            }

            var newProduct = _productsViewModel.NewProduct;
            bool finished = await ShopService.AddProduct(newProduct);
            if (finished)
            {
                _productsViewModel.CurView--;
                await _productsViewModel.LoadProductsOfCategory(newProduct.CategoryId);

                for (int i = 0; i < _productsViewModel.CategoriesList.Count; i++)
                {
                    if (_productsViewModel.CategoriesList[i].CategoryId == _productsViewModel.CurCategory.CategoryId)
                    {
                        _productsViewModel.CategoriesList[i].UpdatedDateTime = DateTime.Now;
                    }
                }
            }
        }
    }
}
