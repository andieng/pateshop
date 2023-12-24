using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MyShop.Models
{
    public class OrderDetail : BaseModel
    {
        private int _orderId;
        private double _orderDiscountRate;
        private double _totalAmount;
        private string _status;
        private DateTime _deliveryDate;
        private DateTime _orderDate;
        [JsonPropertyName("customer")]
        private object _customer;
        [JsonPropertyName("products")]
        private List<OrderProduct> _products;

        public OrderDetail(int orderId, double orderDiscountRate, double totalAmount, string status, DateTime deliveryDate, DateTime orderDate, object customer, List<OrderProduct> products)
        {
            _orderId = orderId;
            _orderDiscountRate = orderDiscountRate;
            _totalAmount = totalAmount;
            _status = status;
            _deliveryDate = deliveryDate;
            _orderDate = orderDate;
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

        public DateTime DeliveryDate
        {
            get => _deliveryDate;
            set
            {
                _deliveryDate = value;
                OnPropertyChanged(nameof(DeliveryDate));
            }
        }

        public DateTime OrderDate
        {
            get => _orderDate;
            set
            {
                _orderDate = value;
                OnPropertyChanged(nameof(OrderDate));
            }
        }
        [JsonPropertyName("customer")]
        public object Customer
        {
            get => _customer;
            set
            {
                _customer = value;
                OnPropertyChanged(nameof(Customer));
            }
        }
        [JsonPropertyName("products")]
        public List<OrderProduct> Products
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
