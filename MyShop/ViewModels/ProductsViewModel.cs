using MyShop.Commands;
using MyShop.Models;
using MyShop.Services;
using MyShop.ViewModels;
using MyShop.Views;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MyShop.ViewModels
{
    public class ProductsViewModel : BaseViewModel
    {
        private ObservableCollection<Category> _categoriesList = new ObservableCollection<Category>();
        private ObservableCollection<Product> _productsList;
        private ObservableCollection<Product> _searchResultList = new ObservableCollection<Product>();
        private ObservableCollection<Product> _originalResultList;
        private ObservableCollection<Product> _productDetail;
        private Visibility _backBtnVisibility = Visibility.Hidden;
        private Visibility _categoryListVisibility = Visibility.Visible;
        private Visibility _categoryDetailVisibility = Visibility.Collapsed;
        private Visibility _productDetailVisibility = Visibility.Collapsed;
        private Visibility _searchBarVisibility = Visibility.Visible;
        private Visibility _editProductVisibility = Visibility.Collapsed;
        private Visibility _addProductVisibility = Visibility.Collapsed;
        private Visibility _searchResultVisibility = Visibility.Collapsed;
        private Category _curCategory;
        private Product _curProduct;
        private Product _editedProduct;
        private Product _newProduct = new Product();
        private Category _newCategory = new Category("");
        private float _priceFrom = 0;
        private float _priceTo = 0;
        private string _selectedImg;
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
        public BaseCommand DeleteCategoryCommand { get; set; }
        public BaseCommand AddCategoryCommand { get; set; }
        public BaseCommand SearchProductsCommand { get; set; }  
        public BaseCommand FilterProductsByPriceRange { get; set; }
        public BaseCommand SelectImageCommand { get; set; }


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

        public ObservableCollection<Product> SearchResultList
        {
            get => _searchResultList;
            set
            {
                _productsList = value;
                OnPropertyChanged("SearchResultList");
            }
        }

        public ObservableCollection<Product> OriginalResultList
        {
            get => _originalResultList;
            set
            {
                _originalResultList = value;
                OnPropertyChanged("OriginalResultList");
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
        public Visibility SearchResultVisibility
        {
            get => _searchResultVisibility;
            set
            {
                _searchResultVisibility = value;
                OnPropertyChanged("SearchResultVisibility");
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

        public Category NewCategory
        {
            get => _newCategory;
            set
            {
                _newCategory = value;
                OnPropertyChanged("NewCategory");
            }
        }

        public float PriceFrom
        {
            get => _priceFrom;
            set
            {
                _priceFrom = value;
                OnPropertyChanged("PriceFrom");
            }
        }

        public float PriceTo
        {
            get => _priceTo;
            set
            {
                _priceTo = value;
                OnPropertyChanged("PriceTo");
            }
        }

        public string SelectedImg
        {
            get => _selectedImg;
            set
            {
                _selectedImg = value;
                OnPropertyChanged("SelectedImg");
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
            DeleteCategoryCommand = new DeleteCategoryCommand(this);
            AddCategoryCommand = new AddCategoryCommand(this);
            SearchProductsCommand = new SearchProductsCommand(this);
            FilterProductsByPriceRange = new FilterProductsByPriceRange(this);
            SelectImageCommand = new SelectImageCommand(this);
        }

        public async void LoadCategories()
        {
            var result = await ShopService.GetAllCategories();

            if (result != null)
            {
                CategoryDetailVisibility = Visibility.Collapsed;
                _categoriesList.Clear();
                var (categories, _) = result.Value;
                foreach(var category in categories)
                {
                    _categoriesList.Add(category);
                }
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
                CategoryListVisibility = Visibility.Collapsed;
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
                SearchResultVisibility = Visibility.Collapsed;
                BackBtnVisibility = Visibility.Visible;
                SearchBarVisibility = Visibility.Hidden;
                CurView++;
                return true;
            }
            return false;
        }

        public async Task<bool> AddCategory(string categoryName)
        {
            var result = await ShopService.AddCategory(categoryName);
            if (result != 0)
            {
                DateTime currentDate = DateTime.Now;
                Category newCategory = new Category(result, categoryName, currentDate.ToString(), currentDate.ToString());
                _categoriesList.Add(newCategory);
                _newCategory.CategoryName = "";
                return true;
            }
            return false;
        }

        public async Task<bool> PerformSearch(string searchText)
        {
            if (CurCategory == null)
            {
                var results = await ShopService.SearchProductsByName(searchText);
                if (results != null)
                {
                    var (products, _) = results.Value;
                    _searchResultList.Clear();

                    foreach (var product in products)
                    {
                        _searchResultList.Add(product);
                    }
                    _originalResultList = new ObservableCollection<Product>(_searchResultList);
                    SearchResultVisibility = Visibility.Visible;
                    BackBtnVisibility = Visibility.Visible;
                    CategoryListVisibility = Visibility.Collapsed;
                    if (CurView == 0) CurView++;
                    return true;
                }
            }
            else if (CurCategory != null)
            {
                var results = await ShopService.SearchProductsOfCategoryByName(_curCategory.CategoryId, searchText);
                if (results != null)
                {
                    var (products, _) = results.Value;
                    _searchResultList.Clear();

                    foreach (var product in products)
                    {
                        _searchResultList.Add(product);
                    }
                    _originalResultList = new ObservableCollection<Product>(_searchResultList);
                    SearchResultVisibility = Visibility.Visible;
                    CategoryDetailVisibility = Visibility.Collapsed;
                    BackBtnVisibility = Visibility.Visible;
                    CategoryListVisibility = Visibility.Collapsed;
                    if (CurView == 1) CurView++;
                    return true;
                }

            }
            return false;
        }

        public async Task<bool> PerformFilter()
        {
            if (_originalResultList != null && _originalResultList.Any())
            {
                var filteredList = new ObservableCollection<Product>(
                    _originalResultList.Where(product => product.Price >= _priceFrom && product.Price <= _priceTo));

                SearchResultList.Clear();

                foreach (var product in filteredList)
                {
                    SearchResultList.Add(product);
                }
                return true;
            }
            else
            {
                var results = await ShopService.FilterProductsOfCategoryByPriceRange(CurCategory.CategoryId, _priceFrom, _priceTo);
                if (results != null)
                {
                    var (products, _) = results.Value;
                    _searchResultList.Clear();

                    foreach (var product in products)
                    {
                        _searchResultList.Add(product);
                    }
                    _originalResultList = new ObservableCollection<Product>(_searchResultList);
                    SearchResultVisibility = Visibility.Visible;
                    CategoryDetailVisibility = Visibility.Collapsed;
                    BackBtnVisibility = Visibility.Visible;
                    CategoryListVisibility = Visibility.Collapsed;
                    if (CurView == 1) CurView++;
                    return true;
                }
            }
            return false;
        }
    }
}