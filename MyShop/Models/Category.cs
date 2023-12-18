using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Models
{
    public class Category : BaseModel
    {
        private int _categoryId;
        private string _categoryName;
        private string _createdAt;
        private string _updatedAt;

        public Category(int categoryId, string categoryName, string createdAt, string updatedAt)
        {
            _categoryId = categoryId;
            _categoryName = categoryName;
            _createdAt = createdAt;
            _updatedAt = updatedAt;
        }

        public int CategoryId
        {
            get => _categoryId;
            set
            {
                _categoryId = value;
                OnPropertyChanged("CategoryId");
            }
        }

        public string CategoryName
        {
            get => _categoryName;
            set
            {
                _categoryName = value;
                OnPropertyChanged("CategoryName");
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
    }
}
