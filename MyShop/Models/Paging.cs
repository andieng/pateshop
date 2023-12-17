using System;
using System.Windows.Media.Imaging;

namespace MyShop.Models
{
    public class Paging : BaseModel
    {
        private int _offset;
        private int _limit;
        private int _totalPages;
        private bool _isNext;
        private bool _isPre;

        public Paging(int offset, int limit, int totalPages, bool isNext, bool isPre)
        {
            _offset = offset;
            _limit = limit;
            _totalPages = totalPages;
            _isNext = isNext;
            _isPre = isPre;
        }

        public int Offset
        {
            get => _offset;
            set
            {
                _offset = value;
                OnPropertyChanged("Offset");
            }
        }

        public int Limit
        {
            get => _limit;
            set
            {
                _limit = value;
                OnPropertyChanged("Limit");
            }
        }

        public int TotalPages
        {
            get => _totalPages;
            set
            {
                _totalPages = value;
                OnPropertyChanged("TotalPages");
            }
        }

        public bool IsNext
        {
            get => _isNext;
            set
            {
                _isNext = value;
                OnPropertyChanged("IsNext");
            }
        }

        public bool IsPre
        {
            get => _isPre;
            set
            {
                _isPre = value;
                OnPropertyChanged("IsPre");
            }
        }
    }
}
