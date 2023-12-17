using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace MyShop.Models
{
    public class Customer : BaseModel
    {
        private int _customerId;
        private string _customerName;
        private string _address;
        private string _phoneNumber;
        private string _email;
        private string _createdAt;
        private string _updatedAt;
        private string? _deletedAt;

        public Customer(int customerId, string customerName, string address, string phoneNumber,
            string email, string createdAt, string updatedAt, string? deletedAt)
        {
            _customerId = customerId;
            _customerName = customerName;
            _address = address;
            _phoneNumber = phoneNumber;
            _email = email;
            _createdAt = createdAt;
            _updatedAt = updatedAt;
            _deletedAt = deletedAt;
        }

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

        public string Address
        {
            get => _address;
            set
            {
                _address = value;
                OnPropertyChanged("Address");
            }
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
                OnPropertyChanged("PhoneNumber");
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged("Email");
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

        public string? DeletedAt
        {
            get => _deletedAt;
            set
            {
                _deletedAt = value;
                OnPropertyChanged("DeletedAt");
            }
        }
    }
}
