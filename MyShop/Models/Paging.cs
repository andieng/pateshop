using System;
using System.Windows.Media.Imaging;

namespace MyShop.Models
{
    public class Paging : BaseModel
    {
        private int _offset;
        private int _limit;
        private int _totalPages;
        private int _currentPage;
        private bool _isNext;
        private bool _isPre;

        public Paging(int offset, int limit, int totalPages, bool isNext, bool isPre)
        {
            _offset = offset;
            _limit = limit;
            _totalPages = totalPages;
            _isNext = isNext;
            _isPre = isPre;
            _currentPage = _limit == 0 ? 0 :(_offset + _limit) / _limit;
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

        public int CurrentPage
        {
            get => _currentPage;
            set
            {
                _currentPage = value;
                OnPropertyChanged("CurrentPage");
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
