using MyShop.Commands;
using MyShop.Models;
using MyShop.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Windows.Data.Xml.Dom;

namespace MyShop.ViewModels
{
    public class AddOrderViewModel:BaseModalViewModel
    {
        private List<Customer> _customers;
        private List<Product> _products;
        private Customer _selectedCustomer;
        private OrderDetail _orderDetail;

        public enum OrderStatus
        {
            Shipped,
            Processing,
            Completed
        }

        public Array OrderStatusValues => Enum.GetValues(typeof(OrderStatus));
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

        public OrderDetail OrderDetail
        {
            get => _orderDetail;
            set
            {
                _orderDetail = value;
                OnPropertyChanged("OrderDetail");
            }
        }
        public List<string> CustomerNames { get; set; }
        public BaseCommand AddOrderProductCommand { get; set; }
        public BaseCommand SelectProduct { get; set; }
        public BaseCommand AddOrder { get; set; }


        public AddOrderViewModel()
        {
            _customers = new List<Customer>();
            _orderDetail = new OrderDetail(0, 0, 0, "Shipping", DateTime.Today, null, new ObservableCollection<OrderProduct>());
            loadData();
            InitCommands();
        }

        public async Task loadData()
        {

            var data = await ShopService.GetCustomersAsync();
            var products = await ShopService.GetProductsAsync();
            Products = products.Value.Item1;
            Customers = data.Value.Item1;
            CustomerNames = Customers.Select(item => item.CustomerName).ToList();
        }
        public void InitCommands()
        {
            SelectProduct = new SelectProductInOrderCommand(this);
            AddOrder = new AddOrderCommand(this);
        }
    }
}
