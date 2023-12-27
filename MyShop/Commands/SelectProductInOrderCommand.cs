using MyShop.Models;
using MyShop.Services;
using MyShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Commands
{
    public class SelectProductInOrderCommand:BaseCommand
    {
        private AddOrderViewModel _addOrderViewModel;

        public SelectProductInOrderCommand(AddOrderViewModel addOrderViewModel)
        {
            _addOrderViewModel = addOrderViewModel;

        }

        public override async void Execute(object parameter)
        {
            if (parameter is Product product)
            {
                int productId = product.ProductId;// set the productId to the value you're working with

                // Check if a product with the same productId already exists
                OrderProduct existingProduct = _addOrderViewModel.OrderDetail.Products.FirstOrDefault(p => p.Product.ProductId == productId);

                if (existingProduct != null)
                {
                    // Product with the same productId already exists, remove it
                    _addOrderViewModel.OrderDetail.Products.Remove(existingProduct);
                }
                else
                {
                    // Product with the same productId doesn't exist, add a new OrderProduct
                    OrderProduct temp = new OrderProduct(1, 0, (decimal)product.Price, product);
                    _addOrderViewModel.OrderDetail.Products.Add(temp);
                }

            }
        }
    }
}
