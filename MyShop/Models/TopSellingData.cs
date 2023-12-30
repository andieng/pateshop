using System;
using System.Collections.Generic;
using System.Windows.Documents;
using System.Windows.Media.Imaging;

namespace MyShop.Models
{
    public class TopSellingData : BaseModel
    {
        private List<TopSellingProduct> _products;
        private int _month;
        private int _year;

        public TopSellingData(List<TopSellingProduct> products, int month, int year)
        {
            _products = products;
            _month = month;
            _year = year;
        }

        public List<TopSellingProduct> Products
        {
            get => _products;
            set
            {
                _products = value;
                OnPropertyChanged("Products");
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
