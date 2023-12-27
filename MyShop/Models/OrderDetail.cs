using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.Json.Serialization;
using System.Windows;

namespace MyShop.Models
{
    public class OrderDetail : BaseModel
    {
        [JsonPropertyName("orderId")]
        private int _orderId;
        [JsonPropertyName("orderDiscountRate")]
        private double _orderDiscountRate;
        [JsonPropertyName("totalAmount")]
        private double _totalAmount;
        [JsonPropertyName("status")]
        private string _status;
        [JsonPropertyName("deliveryDate")]
        private DateTime? _deliveryDate;
        [JsonPropertyName("customer")]
        private Customer _customer;
        [JsonPropertyName("products")]
        private ObservableCollection<OrderProduct> _products;

        public OrderDetail(int orderId, double orderDiscountRate, double totalAmount, string status, DateTime? deliveryDate,  Customer customer, ObservableCollection<OrderProduct> products)
        {
            _orderId = orderId;
            _orderDiscountRate = orderDiscountRate;
            _totalAmount = totalAmount;
            _status = "Shipped";
            MessageBox.Show(_status);
            _deliveryDate = deliveryDate;
            _customer = customer;
            _products = products;
        }

        public int OrderId
        {
            get => _orderId;
            set
            {
                _orderId = value;
                OnPropertyChanged(nameof(OrderId));
            }
        }

        public double OrderDiscountRate
        {
            get => _orderDiscountRate;
            set
            {
                _orderDiscountRate = value;
                OnPropertyChanged(nameof(OrderDiscountRate));
            }
        }

        public double TotalAmount
        {
            get => _totalAmount;
            set
            {
                _totalAmount = value;
                OnPropertyChanged(nameof(TotalAmount));
            }
        }

        public string Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged(nameof(Status));
            }
        }

        public DateTime? DeliveryDate
        {
            get => _deliveryDate;
            set
            {
                _deliveryDate = value;
                OnPropertyChanged(nameof(DeliveryDate));
            }
        }

        [JsonPropertyName("customer")]
        public Customer Customer
        {
            get => _customer;
            set
            {
                _customer = value;
                OnPropertyChanged(nameof(Customer));
            }
        }
        [JsonPropertyName("products")]
        public ObservableCollection<OrderProduct> Products
        {
            get => _products;
            set
            {
                _products = value;
                OnPropertyChanged(nameof(Products));
            }
        }
    }
}
