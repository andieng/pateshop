using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using MyShop.Commands;
using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Collections.Generic;
using System.Security.RightsManagement;
using System.Windows;

namespace MyShop.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        public class Order
        {
            public int Id { get; set; }
            public Customer Customer { get; set; }
            public double OrderDiscountRate { get; set; }
            public string Status { get; set; }
            public double TotalAmount { get; set; }
            public DateTime? DeliveryDate { get; set; }
            public DateTime OrderDate { get; set; }
            public DateTime UpdatedDateTime { get; set; }
        }

        public Order[] Orders = new Order[]
        {
            new Order { Status = "Ordered", UpdatedDateTime = new DateTime(2023,12,5) },
            new Order { Status = "Cancelled", UpdatedDateTime = new DateTime(2023,11,2) },
            new Order { Status = "Delivered", UpdatedDateTime = new DateTime(2023,4,1) },

            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,1,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,1,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,1,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,2,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,2,3) },
                        new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,1,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,1,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,1,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,2,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,2,3) },
                        new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,1,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,1,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,1,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,2,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,2,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,3,7) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,4,2) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,4,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,5,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,6,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,7,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,7,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,8,3) },
                        new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,6,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,7,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,7,3) },
                        new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,6,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,7,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,7,3) },
                        new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,6,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,7,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,7,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,8,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,8,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,8,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,8,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,9,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,9,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,9,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,9,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,9,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,10,2) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,10,23) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,11,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,11,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,12,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,5,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,6,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,7,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,7,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,8,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,8,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,9,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,9,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,9,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,9,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,9,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,10,2) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,10,23) },
                        new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,7,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,7,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,8,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,8,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,9,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,9,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,9,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,9,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,9,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,10,2) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,10,23) },
                        new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,7,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,7,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,8,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,8,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,9,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,9,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,9,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,9,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,9,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,10,2) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,10,23) },

            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,11,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,11,3) },
            new Order { Status = "Completed", UpdatedDateTime = new DateTime(2023,12,3) },


        };

        public class OrderChartValue
        {
            public int TotalOrdersInMonth { get; set; }
            public int MonthIndex { get; set; }
        }

        public static List<OrderChartValue> OrderChartValues = new List<OrderChartValue>();

        public ISeries[] OrderSeries { get; set; }
            = new ISeries[]
            {
                new LineSeries<OrderChartValue>
                {
                    Values = OrderChartValues,
                    Mapping = (orderChartValue, i)  =>
                        new (orderChartValue.MonthIndex, orderChartValue.TotalOrdersInMonth)
                }
            };
        public Axis[] XAxes { get; set; } =
        {
            new Axis
            {
                Labels = new string[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" },
                TextSize = 12,
            }
        };
        public Axis[] YAxes { get; set; } =
        {
            new Axis
            {
                TextSize = 12,
            }
        };

        public class Customer
        {
            public int CustomerId { get; set; }
            public string CustomerName { get; set; }
            public string CustomerAddress { get; set; }
            public string CustomerPhoneNumber { get; set; }
            public string CustomerEmail { get; set; }
        }

        private ObservableCollection<Order> _recentOrders = new ObservableCollection<Order>();

        public ObservableCollection<Order> RecentOrders
        {
            get => _recentOrders;
            set
            {
                _recentOrders = value;
                OnPropertyChanged("RecentOrders");
            }
        }

        public DashboardViewModel()
        {
            for (var i = 0; i < 12; i++)
            {
                int month = i + 1;
                OrderChartValues.Add(new OrderChartValue
                {
                    MonthIndex = i,
                    TotalOrdersInMonth = 0
                });
                foreach(var order in Orders)
                {
                    if (order.UpdatedDateTime.Month == month && order.Status == "Completed")
                    {
                        OrderChartValues[i].TotalOrdersInMonth += 1;
                    }
                }
            }

            RecentOrders.Add(new Order
            {
                Id = 1,
                Customer = new Customer
                {
                    CustomerId = 1,
                    CustomerName = "Jane Smith",
                    CustomerAddress = "456 Oak St, Townsville",
                    CustomerPhoneNumber = "987-654-3210",
                    CustomerEmail = "jane.smith@email.com"
                },
                OrderDiscountRate = 0.2,
                Status = "Processing",
                TotalAmount = 1320,
                DeliveryDate = null,
                OrderDate = new DateTime(2023, 12, 18),
            });
            RecentOrders.Add(new Order
            {
                Id = 2,
                Customer = new Customer
                {
                    CustomerId = 2,
                    CustomerName = "Alice Johnson",
                    CustomerAddress = "456 Oak St, Townsville",
                    CustomerPhoneNumber = "987-654-3210",
                    CustomerEmail = "jane.smith@email.com"
                },
                OrderDiscountRate = 0,
                Status = "Shipped",
                TotalAmount = 1220,
                DeliveryDate = null,
                OrderDate = new DateTime(2023, 12, 19),
            });
            RecentOrders.Add(
            new Order
            {
                Id = 3,
                Customer = new Customer
                {
                    CustomerId = 3,
                    CustomerName = "Bob Wilson",
                    CustomerAddress = "456 Oak St, Townsville",
                    CustomerPhoneNumber = "987-654-3210",
                    CustomerEmail = "jane.smith@email.com"
                },
                OrderDiscountRate = 0,
                Status = "Processing",
                TotalAmount = 320,
                DeliveryDate = null,
                OrderDate = new DateTime(2023, 12, 21),
            });
            RecentOrders.Add(
new Order
{
    Id = 3,
    Customer = new Customer
    {
        CustomerId = 3,
        CustomerName = "Bob Wilson",
        CustomerAddress = "456 Oak St, Townsville",
        CustomerPhoneNumber = "987-654-3210",
        CustomerEmail = "jane.smith@email.com"
    },
    OrderDiscountRate = 0,
    Status = "Processing",
    TotalAmount = 320,
    DeliveryDate = null,
    OrderDate = new DateTime(2023, 12, 21),
});
            RecentOrders.Add(
new Order
{
    Id = 3,
    Customer = new Customer
    {
        CustomerId = 3,
        CustomerName = "Bob Wilson",
        CustomerAddress = "456 Oak St, Townsville",
        CustomerPhoneNumber = "987-654-3210",
        CustomerEmail = "jane.smith@email.com"
    },
    OrderDiscountRate = 0,
    Status = "Processing",
    TotalAmount = 320,
    DeliveryDate = null,
    OrderDate = new DateTime(2023, 12, 21),
});
            RecentOrders.Add(
new Order
{
Id = 3,
Customer = new Customer
{
CustomerId = 3,
CustomerName = "Bob Wilson",
CustomerAddress = "456 Oak St, Townsville",
CustomerPhoneNumber = "987-654-3210",
CustomerEmail = "jane.smith@email.com"
},
OrderDiscountRate = 0,
Status = "Processing",
TotalAmount = 320,
DeliveryDate = null,
OrderDate = new DateTime(2023, 12, 21),
});
            //MessageBox.Show(RecentOrders[0].Customer.CustomerName);
            initCommands();
        }

        public void initCommands()
        {
            
        }

        private static string GetAbbreviatedMonthName(int monthNumber)
        {
            switch(monthNumber)
            {
                case 1:
                    return "Jan";
                case 2:
                    return "Feb";
                case 3:
                    return "Mar";
                case 4:
                    return "Apr";
                case 5:
                    return "May";
                case 6:
                    return "Jun";
                case 7:
                    return "Jul";
                case 8:
                    return "Aug";
                case 9:
                    return "Sep";
                case 10:
                    return "Oct";
                case 11:
                    return "Nov";
                case 12:
                    return "Dec";
                default:
                    return "";
            }
        }
    }
}
