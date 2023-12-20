using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Models
{
    public class Product : BaseModel
    {
        private int _productId;
        private string _productName;
        private string _productSKU;
        private int _categoryId;
        private string _description;
        private int _quantity;
        private float _price;
        private float _cost;
        private string _image;
        private float _size;
        private string _color;
        private string _createdAt;
        private string _updatedAt;
        private DateTime _createdDateTime;
        private DateTime _updatedDateTime;

        public Product(int productId, string productName, string createdAt, string updatedAt)
        {
            _productId = productId;
            _productName = productName;
            _createdAt = createdAt;
            _updatedAt = updatedAt;
            _createdDateTime = DateTime.Parse(createdAt);
            _updatedDateTime = DateTime.Parse(updatedAt);
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

        public string ProductName
        {
            get => _productName;
            set
            {
                _productName = value;
                OnPropertyChanged("ProductName");
            }
        }

        public string ProductSKU
        {
            get => _productSKU;
            set
            {
                _productSKU = value;
                OnPropertyChanged("ProductSKU");
            }
        }

        public int CategoryId
        {
            get => _categoryId;
            set
            {
                _categoryId = value;
                OnPropertyChanged("CategoryId");
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        public int Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                OnPropertyChanged("Quantity");
            }
        }

        public float Price
        {
            get => _price;
            set
            {
                _price = value;
                OnPropertyChanged("Price");
            }
        }

        public float Cost
        {
            get => _cost;
            set
            {
                _cost = value;
                OnPropertyChanged("Cost");
            }
        }

        public string Image
        {
            get => _image;
            set
            {
                _image = value;
                OnPropertyChanged("Image");
            }
        }

        public float Size
        {
            get => _size;
            set
            {
                _size = value;
                OnPropertyChanged("Size");
            }
        }

        public string Color
        {
            get => _color;
            set
            {
                _color = value;
                OnPropertyChanged("Color");
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

        public DateTime CreatedDateTime
        {
            get => _createdDateTime;
            set
            {
                _createdDateTime = value;
                OnPropertyChanged("CreatedDateTime");
            }
        }

        public DateTime UpdatedDateTime
        {
            get => _updatedDateTime;
            set
            {
                _updatedDateTime = value;
                OnPropertyChanged("UpdatedDateTime");
            }
        }
    }
}
