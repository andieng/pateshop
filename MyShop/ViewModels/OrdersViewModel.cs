using MyShop.Commands;
using MyShop.Models;
using MyShop.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MyShop.ViewModels
{
    public class OrdersViewModel : BaseViewModel
    {

        private ObservableCollection<Order> _orders;
        private Visibility _orderVisibility = Visibility.Visible;
        private Visibility _orderDetailVisibility;
        private DateTime _startOrderDate;
        private DateTime _endOrderDate;

        public enum OrderStatus
        {
            Shipped,
            Processing,
            Completed
        }

        public List<string> OrderStatusValues => Enum.GetNames(typeof(OrderStatus)).ToList();


        public ObservableCollection<Order> Orders
        {
            get => _orders;
            set
            {
                _orders = value;
                OnPropertyChanged(nameof(Orders));

            }
        }

        private Paging _paging;
        public Paging Paging
        {
            get => _paging;
            set
            {
                _paging = value;
                OnPropertyChanged(nameof(Paging));
            }
        }
        private OrderDetail _orderDetail;
        public OrderDetail OrderDetail
        {
            get => _orderDetail;
            set
            {
                _orderDetail = value;
                OnPropertyChanged(nameof(OrderDetail));
            }
        }

        public Visibility OrderDetailVisibility
        {
            get => _orderDetailVisibility;
            set
            {
                _orderDetailVisibility = value;
                OnPropertyChanged("OrderDetailVisibility");
            }
        }
        public Visibility OrderVisibility
        {
            get => _orderVisibility;
            set
            {
                _orderVisibility = value;
                OnPropertyChanged("OrderVisibility");
            }
        }

        public DateTime StartOrderDate
        {
            get => _startOrderDate;
            set
            {
                _startOrderDate = DateTime.ParseExact(value.ToString("MM/dd/yyyy"), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                OnPropertyChanged("StartOrderDate");
            }
        }

        public DateTime EndOrderDate
        {
            get => _endOrderDate;
            set
            {
                _endOrderDate = DateTime.ParseExact(value.ToString("MM/dd/yyyy"), "MM/dd/yyyy", CultureInfo.InvariantCulture); ;
                OnPropertyChanged("EndOrderDate");
            }
        }

        public BaseCommand GetOrdersCommand { get; set; }
        public BaseCommand OpenAddOrderCommand { get; set; }
        public BaseCommand SelectCommand { get; set; }
        public BaseCommand BackCommand { get; set; }
        public BaseCommand UpdateCommand { get; set; }
        public BaseCommand DeleteOrderCommand { get; set; }
        public BaseCommand FilterOrderCommand { get; set; }

        public OrdersViewModel()
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;
            int limit = Int32.Parse(settings["ItemsPerPage_Orders"].Value);
            _orderDetail = new OrderDetail(0, 0, 0, "", new DateTime(), null, null);
            _orders = new ObservableCollection<Order>();
            _paging = new Paging(0,limit,0,false,false);
             _startOrderDate = new DateTime(2023, 1, 1);
            _endOrderDate = DateTime.Now;
            _orderDetailVisibility = Visibility.Hidden;
            initCommands();
            LoadOrders();
        }

        public void initCommands()
        {
            GetOrdersCommand = new OrdersPagingCommand(this);
            OpenAddOrderCommand = new OpenAddOrderCommand();
            SelectCommand = new SelectOrderCommand(this);
            BackCommand = new BackOrderCommand(this);
            UpdateCommand = new UpdateOrderDetailCommand(this);
            DeleteOrderCommand = new DeleteOrderCommand(this);
            FilterOrderCommand = new FilterOrdersCommand(this);
        }
        public async Task LoadOrders()
        {
            var result = await ShopService.GetOrdersAsync(Paging.Limit,0);
            Orders = new ObservableCollection<Order>(result.Value.Item1);
            Paging = result.Value.Item2;
        }

    }
}
