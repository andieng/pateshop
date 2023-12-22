using MyShop.Commands;
using MyShop.Models;
using MyShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.ViewModels
{
    public class AddOrderProductViewModel: BaseModalViewModel
    {
        private List<Product> _products;
        private OrderProduct _selectedProduct;


        public OrderProduct SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                OnPropertyChanged("SelectedProduct");
            }
        }

        public List<Product> Products
        {
            get => _products;
            set
            {
                _products = value;
                OnPropertyChanged("Products");
            }
        }
        public AddOrderProductViewModel()
        {
            _products = new List<Product>();
            loadData();
            InitCommands();
        }

        public async Task loadData()
        {
            var products = await ShopService.GetProductsAsync();
            Products = products.Value.Item1;
        }
        public void InitCommands()
        {
            // AddCustomerCommand = new AddCustomerCommand(this);
            //CancelCommand = new CancelCommand(this);
        }
    }
}
