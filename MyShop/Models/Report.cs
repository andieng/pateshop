using System;
using System.Windows.Media.Imaging;

namespace MyShop.Models
{
    public class Report : BaseModel
    {
        private double _revenue;
        private double _cost;
        private double _profit;
        private int _month;
        private int _year;

        public Report(double revenue, double cost, double profit, int month, int year)
        {
            _revenue = revenue;
            _cost = cost;
            _profit = profit;
            _month = month;
            _year = year;
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

        public double Cost
        {
            get => _cost;
            set
            {
                _cost = value;
                OnPropertyChanged("Cost");
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
    }
}
