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
        private ObservableCollection<Customer> _customers;
        private Paging _paging;
        private string _textSearch;
        public ObservableCollection<Customer> Customers
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
        public string TextSearch
        {
            get => _textSearch;
            set
            {
                _textSearch = value;
                OnPropertyChanged(nameof(TextSearch));
            }
        }

        public BaseCommand OpenAddCustomerModelCommand { get; set; }
        public BaseCommand OpenUpdateCustomerModelCommand { get; set; }
        public BaseCommand SearchCommand { get; set; }



        public BaseCommand GetCustomersCommand { get; set; }
        public BaseCommand DeleteCommand { get; set; }

        public CustomersViewModel()
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;
            int limit = Int32.Parse(settings["ItemsPerPage_Customers"].Value);
            _customers = new ObservableCollection<Customer>();
            _paging = new Paging(0,limit,0,false,false);
            initCommands();
            GetCustomers();
        }
        
        public void initCommands()
        {
            GetCustomersCommand = new CustomersCommand(this);
            OpenAddCustomerModelCommand = new OpenAddCustomerCommand();
            DeleteCommand = new DeleteCustomerCommand(this);
            OpenUpdateCustomerModelCommand = new OpenUpdateCustomerCommand();
            SearchCommand = new SearchCustomerCommand(this);
        }
        public async Task GetCustomers()
        {
            var result = await ShopService.GetCustomersAsync(Paging.Limit, 0);
            Customers = new ObservableCollection<Customer>(result.Value.Item1);
            Paging = result.Value.Item2;

        }


    }
}
