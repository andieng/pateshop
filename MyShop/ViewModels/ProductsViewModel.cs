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
        private ObservableCollection<Product> _productDetail;
        private Visibility _backBtnVisibility = Visibility.Hidden;
        private Visibility _categoryListVisibility = Visibility.Visible;
        private Visibility _categoryDetailVisibility = Visibility.Collapsed;
        private Visibility _productDetailVisibility = Visibility.Collapsed;
        private Visibility _searchBarVisibility = Visibility.Visible;
        private Visibility _editProductVisibility = Visibility.Collapsed;
        private Visibility _addProductVisibility = Visibility.Collapsed;
        private Category _curCategory;
        private Product _curProduct;
        private Product _editedProduct;
        private Product _newProduct = new Product();
        public int CurView { get; set; }

        public BaseCommand SelectCommand { get; set; }
        public BaseCommand BackCommand { get; set; }
        public BaseCommand OpenEditCommand { get; set; }
        public BaseCommand UpdateCommand { get; set; }
        public BaseCommand InlineUpdateCommand { get; set; }
        public BaseCommand OpenAddCommand { get; set; }
        public BaseCommand AddProductCommand { get; set; }
        public BaseCommand DeleteProductCommand { get; set; }
        public BaseCommand EnterCommand { get; set; }
        public BaseCommand EscCommand { get; set; }


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

        public ObservableCollection<Product> ProductDetail
        {
            get => _productDetail;
            set
            {
                _productDetail = value;
                OnPropertyChanged("ProductDetail");
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
        public Visibility ProductDetailVisibility
        {
            get => _productDetailVisibility;
            set
            {
                _productDetailVisibility = value;
                OnPropertyChanged("ProductDetailVisibility");
            }
        }
        public Visibility EditProductVisibility
        {
            get => _editProductVisibility;
            set
            {
                _editProductVisibility = value;
                OnPropertyChanged("EditProductVisibility");
            }
        }
        public Visibility SearchBarVisibility
        {
            get => _searchBarVisibility;
            set
            {
                _searchBarVisibility = value;
                OnPropertyChanged("SearchBarVisibility");
            }
        }
        public Visibility AddProductVisibility
        {
            get => _addProductVisibility;
            set
            {
                _addProductVisibility = value;
                OnPropertyChanged("AddProductVisibility");
            }
        }

        public Category CurCategory {
            get => _curCategory;
            set
            {
                _curCategory = value;
                OnPropertyChanged("CurCategory");
            }
        }

        public Product CurProduct
        {
            get => _curProduct;
            set
            {
                _curProduct = value;
                OnPropertyChanged("CurProduct");
            }
        }

        public Product EditedProduct
        {
            get => _editedProduct;
            set
            {
                _editedProduct = value;
                OnPropertyChanged("EditedProduct");
            }
        }

        public Product NewProduct
        {
            get => _newProduct;
            set
            {
                _newProduct = value;
                OnPropertyChanged("NewProduct");
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
            OpenEditCommand = new OpenEditCommand(this);
            UpdateCommand = new UpdateCommand(this);
            InlineUpdateCommand = new InlineUpdateCommand();
            OpenAddCommand = new OpenAddCommand(this);
            AddProductCommand = new AddProductCommand(this);
            DeleteProductCommand = new DeleteProductCommand(this);
            EnterCommand = new EnterCommand();
            EscCommand = new EscCommand();
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
                NewProduct.CategoryId = categoryId;
                CurView++;
                return true; 
            }
            return false;
        }

        public async Task<bool> LoadProduct(int productId, int categoryId)
        {
            var product = await ShopService.GetProduct(productId, categoryId);
            if (product != null)
            {
                ProductDetail = new ObservableCollection<Product>();
                ProductDetail.Add(product);
                CategoryDetailVisibility = Visibility.Collapsed;
                ProductDetailVisibility = Visibility.Visible;
                BackBtnVisibility = Visibility.Visible;
                SearchBarVisibility = Visibility.Hidden;
                CurView++;
                return true;
            }
            return false;
        }
    }
}