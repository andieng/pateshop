using MyShop.Commands;
using MyShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.ViewModels
{
    public class UpdateCustomerViewModel:BaseModalViewModel
    {
        private int _customerId;
        private string _customerName;
        private string _address;
        private string _phoneNumber;
        private string _email;

        public int CustomerId
        {
            get => _customerId;
            set
            {
                _customerId = value;
                OnPropertyChanged("CustomerId");
            }
        }
        public string CustomerName
        {
            get => _customerName;
            set
            {
                _customerName = value;
                OnPropertyChanged("CustomerName");
            }
        }
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }
        public string Address
        {
            get => _address;
            set
            {
                _address = value;
                OnPropertyChanged(nameof(Address));
            }
        }
        public BaseCommand UpdateCustomerCommand { get; set; }
        public BaseCommand CancelCommand { get; set; }

        public UpdateCustomerViewModel(Customer customer)
        {
            CustomerId = customer.CustomerId;
            PhoneNumber = customer.PhoneNumber;
            Address = customer.Address; 
            Email = customer.Email;
            CustomerName   = customer.CustomerName;
            InitCommands();
        }

        public void InitCommands()
        {
            
            UpdateCustomerCommand = new UpdateCustomerCommand(this);
        }
    }
}
