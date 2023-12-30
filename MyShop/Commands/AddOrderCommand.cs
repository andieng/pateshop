using MyShop.Models;
using MyShop.Services;
using MyShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyShop.Commands
{
    public class AddOrderCommand:BaseCommand
    {
        private AddOrderViewModel _addOrderViewModel;

        public AddOrderCommand(AddOrderViewModel addOrderViewModel)
        {
            _addOrderViewModel = addOrderViewModel;
        }

        public override async void Execute(object parameter)
        {
            object data = new
            {
                orderDiscountRate = _addOrderViewModel.OrderDetail.OrderDiscountRate,
                deliveryDate = _addOrderViewModel.OrderDetail.DeliveryDate.ToString(),
                status = _addOrderViewModel.OrderDetail.Status,
                customerId = _addOrderViewModel.OrderDetail.Customer.CustomerId,
                products = _addOrderViewModel.OrderDetail.Products
                .Select(item => new
                {
                    productId = item.Product.ProductId,
                    quantity = item.Quantity,
                    productDiscountRate = item.ProductDiscountRate
                })
                .ToList()

            };
            if (data != null)
            {
                await ShopService.AddOrder(data);
            }
            
            _addOrderViewModel.Close((Window)parameter);
        }
    }
}
