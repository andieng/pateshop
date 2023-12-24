using MyShop.Commands;
using MyShop.Models;
using MyShop.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows;

namespace MyShop.ViewModels
{
    public class OrdersViewModel : BaseViewModel
    {

        private List<Order> _orders;
        private Visibility _backBtnVisibility = Visibility.Hidden;
        private Visibility _orderVisibility = Visibility.Visible;
        private Visibility _orderDetailVisibility;

        public List<Order> Orders
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

        public BaseCommand GetOrdersCommand { get; set; }
        public BaseCommand OpenAddOrderCommand { get; set; }
        public BaseCommand SelectCommand { get; set; } 
        public OrdersViewModel()
        {
            _orders = new List<Order>();
            _paging = new Paging(0,5,0,false,false);
            _orderDetailVisibility = Visibility.Hidden;
            initCommands();
            LoadOrders();
        }

        public void initCommands()
        {
            GetOrdersCommand = new OrdersPagingCommand(this);
            OpenAddOrderCommand = new OpenAddOrderCommand();
            SelectCommand = new SelectOrderCommand(this);
        }
        public async Task LoadOrders()
        {
            var result = await ShopService.GetOrdersAsync(Paging.Limit,0);
            (Orders,Paging) = result.Value;
        }
    }
}