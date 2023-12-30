using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MyShop.Models
{
    public class TopSellingProduct : BaseModel
    {
        private int _lineNumber;
        private int _productId;
        private string _productImage;
        private string _productName;
        private double _price;
        private int _totalSold;
        private ImageSource _productImageSource;

        public TopSellingProduct(int productId, string productImage, string productName, double price, int totalSold)
        {
            _productId = productId;
            _productImage = productImage;
            _productName = productName;
            _price = price;
            _totalSold = totalSold;
            _productImageSource = new BitmapImage(new Uri($"../Resources/Products/{productImage}", UriKind.Relative));
        }

        public int LineNumber
        {
            get => _lineNumber;
            set
            {
                _lineNumber = value;
                OnPropertyChanged("LineNumber");
            }
        }

        public int ProductId
        {
            get => _productId;
            set
            {
                _productId = value;
                OnPropertyChanged("ProductId");
            }
        }

        public string ProductImage
        {
            get => _productImage;
            set
            {
                _productImage = value;
                _productImageSource = new BitmapImage(new Uri($"../Resources/Products/{value}", UriKind.Relative));
                OnPropertyChanged("ProductImage");
            }
        }

        public ImageSource ProductImageSource { get => _productImageSource; }

        public string ProductName
        {
            get => _productName;
            set
            {
                _productName = value;
                OnPropertyChanged("ProductName");
            }
        }

        public double Price
        {
            get => _price;
            set
            {
                _price = value;
                OnPropertyChanged("Price");
            }
        }

        public int TotalSold
        {
            get => _totalSold;
            set
            {
                _totalSold = value;
                OnPropertyChanged("TotalSold");
            }
        }
    }
}
