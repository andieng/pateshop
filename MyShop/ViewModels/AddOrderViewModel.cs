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
    internal class AddOrderViewModel:BaseModalViewModel
    {
        private List<Customer> _customers;
        private List<Product> _products;
        private Customer _selectedCustomer;


        public List<Customer> Customers
        {
            get => _customers;
            set
            {
                _customers = value;
                OnPropertyChanged("Customers");
            }
        }

        public Customer SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value;
                OnPropertyChanged("SelectedCustomer");
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
        public List<string> CustomerNames { get; set; }
        public BaseCommand AddOrderProductCommand { get; set; }
        public AddOrderViewModel()
        {
            _customers = new List<Customer>();
            loadData();
            InitCommands();
        }

        public async Task loadData()
        {
            var data = await ShopService.GetCustomersAsync();
            var products = await ShopService.GetProductsAsync();
            Customers = data.Value.Item1;
            CustomerNames = Customers.Select(item => item.CustomerName).ToList();
            Products = products.Value.Item1;
        }
        public void InitCommands()
        {
            // AddCustomerCommand = new AddCustomerCommand(this);
            //CancelCommand = new CancelCommand(this);
            AddOrderProductCommand = new AddOrderProductCommand();
        }
    }
}
