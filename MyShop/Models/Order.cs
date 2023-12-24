using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Models
{
    public class Order: BaseModel
    {
            private int _orderId;
            private string _customerName;
            private string _orderDiscountRate;
            private string _totalAmount;
            private string _status;
        private string _deliveryDate;
        private string _orderDate;
            private string _createdAt;
            private string _updatedAt;

            public Order(int orderId, string customerName, string orderDiscountRate, string totalAmount,
                string status, string createdAt, string updatedAt, string deliveryDate, string orderDate)
            {
                _orderId = orderId;
                _customerName = customerName;
            _orderDiscountRate = orderDiscountRate;
            _totalAmount = totalAmount;
            _status = status;
            _deliveryDate = deliveryDate;
            _orderDate = orderDate;
                _createdAt = createdAt;
                _updatedAt = updatedAt;
            }

            public int OrderId
            {
                get => _orderId;
                set
                {
                    _orderId = value;
                    OnPropertyChanged("OrderId");
                }
            }

            public string CustomerName
            {
                get => _customerName;
                set
                {
                    _customerName = value;
                    OnPropertyChanged("CustomerName");
                }
            }

            public string Status
            {
                get => _status;
                set
                {
                    _status = value;
                    OnPropertyChanged("Status");
                }
            }

            public string DeliveryDate
            {
                get => _deliveryDate;
                set
                {
                    _deliveryDate = value;
                    OnPropertyChanged("DeliveryDate");
                }
            }

            public string OrderDate
            {
                get => _orderDate;
                set
                {
                    _orderDate = value;
                    OnPropertyChanged("OrderDate");
                }
            }

            public string CreatedAt
            {
                get => _createdAt;
                set
                {
                    _createdAt = value;
                    OnPropertyChanged("CreatedAt");
                }
            }

            public string UpdatedAt
            {
                get => _updatedAt;
                set
                {
                    _updatedAt = value;
                    OnPropertyChanged("UpdatedAt");
                }
            }

            public string TotalAmount
            {
                get => _totalAmount;
                set
                {
                    _totalAmount = value;
                    OnPropertyChanged("TotalAmount");
                }
            }

        public string OrderDiscountRate
        {
            get => _orderDiscountRate;
            set
            {
                _orderDiscountRate = value;
                OnPropertyChanged("OrderDiscountRate");
            }
        }
    }
    }



