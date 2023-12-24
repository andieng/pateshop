using MyShop.Commands;
using MyShop.Models;
using MyShop.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;

namespace MyShop.ViewModels
{
    public class CustomersViewModel : BaseViewModel
    {
        private List<Customer> _customers;
        private Paging _paging;
        public List<Customer> Customers
        {
            get => _customers;
            set
            {
                    _customers = value;
                    OnPropertyChanged(nameof(Customers));  
            }
        }
        public Paging Paging
        {
            get => _paging;
            set
            {
                _paging = value;
                OnPropertyChanged(nameof(Paging));
            }
        }
        
        public BaseCommand OpenAddCustomerModelCommand { get; set; }
        public BaseCommand OpenUpdateCustomerModelCommand { get; set; }



        public BaseCommand GetCustomersCommand { get; set; }
        public BaseCommand DeleteCommand { get; set; }

        public CustomersViewModel()
        {
                        _customers = new List<Customer>();
            _paging = new Paging(0,5,0,false,false);
            initCommands();
            GetCustomers();
        }
        
        public void initCommands()
        {

            GetCustomersCommand = new CustomersCommand(this);
            OpenAddCustomerModelCommand = new OpenAddCustomerCommand();
            DeleteCommand = new DeleteCustomerCommand(this);
            OpenUpdateCustomerModelCommand = new OpenUpdateCustomerCommand();
        }
        public async Task GetCustomers()
        {
            var result = await ShopService.GetCustomersAsync(Paging.Limit, 0);
            (Customers, Paging) = result.Value;
        }


    }
}
