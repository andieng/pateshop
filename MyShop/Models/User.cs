using System;

namespace MyShop.Models
{
    public class User : BaseModel
    {
        private int _userId;
        private string _username;
        private string _name;

        public User(int userId, string username, string name)
        {
            _userId = userId;
            _username = username;
            _name = name;
        }

        public int UserId
        {
            get => _userId;
            set
            {
                _userId = value;
                OnPropertyChanged("UserId");
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged("Username");
            }
        }
    }
}
