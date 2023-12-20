using MyShop.Commands;
using MyShop.Models;
using MyShop.Services;
using MyShop.ViewModels;
using MyShop.Views;
using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MyShop.ViewModels
{
    public class ProductsViewModel : BaseViewModel
    {
        private ObservableCollection<Category> _categoriesList;
        private ObservableCollection<Product> _productsList;
        private Visibility _categoryDetailVisibility;
        private Visibility _backBtnVisibility = Visibility.Hidden;
        private Visibility _categoryListVisibility = Visibility.Visible;
        private string _curCategory;

        public BaseCommand SelectCommand { get; set; }
        public BaseCommand BackCommand { get; set; }

        public ObservableCollection<Category> CategoriesList
        {
            get => _categoriesList;
            set
            {
                _categoriesList = value;
                OnPropertyChanged("CategoriesList");
            }
        }

        public ObservableCollection<Product> ProductsList
        {
            get => _productsList;
            set
            {
                _productsList = value;
                OnPropertyChanged("ProductsList");
            }
        }

        public Visibility CategoryDetailVisibility
        {
            get => _categoryDetailVisibility;
            set
            {
                _categoryDetailVisibility = value;
                OnPropertyChanged("CategoryDetailVisibility");
            }
        }

        public Visibility CategoryListVisibility
        {
            get => _categoryListVisibility;
            set
            {
                _categoryListVisibility = value;
                OnPropertyChanged("CategoryListVisibility");
            }
        }

        public Visibility BackBtnVisibility
        {
            get => _backBtnVisibility;
            set
            {
                _backBtnVisibility = value;
                OnPropertyChanged("BackBtnVisibility");
            }
        }

        public int CurView { get; set; }

        public string CurCategory {
            get => _curCategory;
            set
            {
                _curCategory = value;
                OnPropertyChanged("CurCategory");
            }
        } 

        public ProductsViewModel()
        {
            InitCommands();
            LoadCategories();
        }

        public void InitCommands()
        {
            SelectCommand = new SelectCommand(this);
            BackCommand = new BackCommand(this);
        }

        public async void LoadCategories()
        {
            var result = await ShopService.GetAllCategories();

            if (result != null)
            {
                CategoryDetailVisibility = Visibility.Collapsed;
                var (categories, _) = result.Value;
                CategoriesList = new ObservableCollection<Category>(categories);
            }
        }

        public async Task<bool> LoadProductsOfCategory(int categoryId)
        {
            var results = await ShopService.GetProductsOfCategory(categoryId);
            if (results != null)
            {
                var (products, _) = results.Value;
                ProductsList = new ObservableCollection<Product>(products);
                CategoryDetailVisibility = Visibility.Visible;
                BackBtnVisibility = Visibility.Visible;
                CurView++;
                return true; 
            }
            return false;
        }
    }
}
