using MyShop.Commands;
using MyShop.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;

namespace MyShop.ViewModels
{
    public class AddCustomerViewModel: BaseModalViewModel
    {
        private string _customerName;
        private string _address;
        private string _phoneNumber;
        private string _email;


        public string CustomerName
        {
            get => _customerName;
            set
            {
                _customerName = value;
                OnPropertyChanged("CustomerId");
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
        public BaseCommand AddCustomerCommand { get; set; }
        public BaseCommand CancelCommand { get; set; }

        public AddCustomerViewModel()
        {
            InitCommands();
        }

        public void InitCommands()
        {
            AddCustomerCommand = new AddCustomerCommand(this);
            //CancelCommand = new CancelCommand(this);
        }

    }
}
