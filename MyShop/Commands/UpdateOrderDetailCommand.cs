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
    public class UpdateOrderDetailCommand: BaseCommand
    {
        private OrdersViewModel _ordersCustomerViewModel;

        public UpdateOrderDetailCommand(OrdersViewModel ordersViewModel)
        {
            _ordersCustomerViewModel = ordersViewModel;
        }

        public override async void Execute(object parameter)
        {
            dynamic data = new
            {
                orderDiscountRate = _ordersCustomerViewModel.OrderDetail.OrderDiscountRate,
                status = _ordersCustomerViewModel.OrderDetail.Status,
                deliveryDate = _ordersCustomerViewModel.OrderDetail.DeliveryDate.ToString(),
                products = _ordersCustomerViewModel.OrderDetail.Products
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
                await ShopService.UpdateOrder(data, _ordersCustomerViewModel.OrderDetail.OrderId);
            }
            await ShopService.GetOrderDetailAsync(_ordersCustomerViewModel.OrderDetail.OrderId);

        }
    }
}
