using System;
using System.Windows.Media.Imaging;

namespace MyShop.Models
{
    public class CountData : BaseModel
    {
        private int _count;
        private int _month;
        private int _year;

        public CountData(int count, int month, int year)
        {
            _count = count;
            _month = month;
            _year = year;
        }

        public int Count
        {
            get => _count;
            set
            {
                _count = value;
                OnPropertyChanged("Count");
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
