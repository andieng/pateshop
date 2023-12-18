using MyShop.Commands;
using MyShop.Models;
using MyShop.Services;
using MyShop.ViewModels;
using MyShop.Views;
using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Windows;

namespace MyShop.ViewModels
{
    public class ProductsViewModel : BaseViewModel
    {
        private ObservableCollection<Category> _categoriesList;
        public ObservableCollection<Category> CategoriesList
        {
            get => _categoriesList;
            set
            {
                _categoriesList = value;
                OnPropertyChanged("CategoriesList");
            }
        }

        public ProductsViewModel()
        {
            LoadCategories();
        }

        public async void LoadCategories()
        {
            var result = await ShopService.GetAllCategories();

            if (result != null)
            {
                var (categories, _) = result.Value;
                CategoriesList = new ObservableCollection<Category>(categories);
            }
        }
    }
}
