using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using MyShop.Commands;
using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Collections.Generic;
using System.Security.RightsManagement;
using System.Windows;
using MyShop.Services;
using System.Threading.Tasks;
using MyShop.Models;

namespace MyShop.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
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

        private int _numCustomers;
        private int _numOrders;
        private double _revenue;
        private double _profit;
        private int _month;
        private int _year;
        private List<CountData> _orderAnalytics;
        private List<TopSellingProduct> _topSellingProducts;

        public List<TopSellingProduct> TopSellingProducts
        {
            get => _topSellingProducts;
            set
            {
                _topSellingProducts = value;
                OnPropertyChanged("TopSellingProducts");
            }
        }

        public int NumCustomers
        {
            get => _numCustomers;
            set
            {
                _numCustomers = value;
                OnPropertyChanged("NumCustomers");
            }
        }

        public int NumOrders
        {
            get => _numOrders;
            set
            {
                _numOrders = value;
                OnPropertyChanged("NumOrders");
            }
        }

        public double Revenue
        {
            get => _revenue;
            set
            {
                _revenue = value;
                OnPropertyChanged("Revenue");
            }
        }

        public double Profit
        {
            get => _profit;
            set
            {
                _profit = value;
                OnPropertyChanged("Profit");
            }
        }

        public int Month
        {
            get => _month;
            set
            {
                _month = value;
                OnPropertyChanged("Month");
            }
        }

        public int Year
        {
            get => _year;
            set
            {
                _year = value;
                OnPropertyChanged("Year");
            }
        }

        public List<CountData> OrderAnalytics
        {
            get => _orderAnalytics;
            set
            {
                _orderAnalytics = value;
                OnPropertyChanged("OrderAnalytics");
            }
        }

        public static async Task<DashboardViewModel> Create()
        {
            DashboardViewModel vm = new DashboardViewModel();
            await vm.LoadData();
            return vm;
        }

        private DashboardViewModel() { }

        private async Task LoadData()
        {
            //DateTime now = DateTime.Now;
            //Month = now.Month;
            //Year = now.Year;
            Month = 12;
            Year = 2023;
            var countCustomersData = await ShopService.CountCustomersInMonth(Month, Year);
            var countOrdersData = await ShopService.CountOrdersInMonth(Month, Year);
            var reportData = await ShopService.GetReportData(Month, Year);
            var topSellingData = await ShopService.GetTopSellingProducts(Month, Year);
            var orderAnalytics = await ShopService.GetOrderAnalytics(Year);

            if (countCustomersData != null)
            {
                NumCustomers = countCustomersData.Count;
            }
            if (countOrdersData != null)
            {
                NumOrders = countOrdersData.Count;
            }
            if (reportData != null)
            {
                Revenue = reportData.Revenue;
                Profit = reportData.Profit;
            }
            if (topSellingData != null)
            {
                TopSellingProducts = topSellingData.Products;
                for (var i = 0; i < TopSellingProducts.Count; i++)
                {
                    TopSellingProducts[i].LineNumber = i + 1;
                }
            }
            if (orderAnalytics != null)
            {
                OrderAnalytics = orderAnalytics;
                foreach (var item in orderAnalytics)
                {
                    OrderChartValues.Add(new OrderChartValue
                    {
                        MonthIndex = item.Month - 1,
                        TotalOrdersInMonth = item.Count
                    });
                }
            }
        }
    }
}
