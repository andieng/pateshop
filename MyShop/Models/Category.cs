using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Text.Json.Serialization;

namespace MyShop.Models
{
    public class Category : BaseModel
    {
        private int _categoryId;
        private string _categoryName;
        private string _createdAt;
        private string _updatedAt;
        private DateTime _createdDateTime;
        private DateTime _updatedDateTime;
        private Visibility _inputCategoryNameVisibility = Visibility.Collapsed;
        private Visibility _categoryNameVisibility = Visibility.Visible;
        private string _oldCategoryName;

        [JsonConstructor]
        public Category(int categoryId, string categoryName, string createdAt, string updatedAt)
        {
            _categoryId = categoryId;
            _categoryName = categoryName;
            _createdAt = createdAt;
            _updatedAt = updatedAt;
            _createdDateTime = DateTime.Parse(createdAt);
            _updatedDateTime = DateTime.Parse(updatedAt);
            _oldCategoryName = categoryName;
        }

        public Category(string categoryName)
        {
            _categoryName = categoryName;
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

        public DateTime CreatedDateTime
        {
            get => _createdDateTime;
            set
            {
                _createdDateTime = value;
                OnPropertyChanged("CreatedDateTime");
            }
        }

        public DateTime UpdatedDateTime
        {
            get => _updatedDateTime;
            set
            {
                _updatedDateTime = value;
                OnPropertyChanged("UpdatedDateTime");
            }
        }

        public Visibility CategoryNameVisibility
        {
            get => _categoryNameVisibility;
            set
            {
                _categoryNameVisibility = value;
                OnPropertyChanged("CategoryNameVisibility");
            }
        }
        public Visibility InputCategoryNameVisibility
        {
            get => _inputCategoryNameVisibility;
            set
            {
                _inputCategoryNameVisibility = value;
                OnPropertyChanged("InputCategoryNameVisibility");
            }
        }

        public string OldCategoryName
        {
            get => _oldCategoryName;
            set
            {
                _oldCategoryName = value;
                OnPropertyChanged(nameof(OldCategoryName));
            }
        }
    }
}
