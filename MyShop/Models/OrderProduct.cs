using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Models
{
    public class OrderProduct:BaseModel
    {

        private int _quantity;
        private decimal _productDiscountRate;
        private decimal _amount;
        private Product _product;

        public OrderProduct(int quantity, decimal productDiscountRate, decimal amount, Product product)
        {
            _productDiscountRate = productDiscountRate;
            _amount = amount;
            _quantity = quantity;
            _product = product;
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

        public decimal ProductDiscountRate
        {
            get => _productDiscountRate;
            set
            {
                _productDiscountRate = value;
                OnPropertyChanged("_productDiscountRate");
            }
        }

        public decimal Amount
        {
            get => _amount;
            set
            {
                _amount = value;
                OnPropertyChanged("Amount");
            }
        }

        public Product Product
        {
            get => _product;
            set
            {
                _product = value;
                OnPropertyChanged("Product");
            }
        }

    }
}
