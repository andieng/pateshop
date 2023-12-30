using MyShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MyShop.Views
{
    public partial class AddCategoryView : Window
    {
        public AddCategoryView(object dataContext)
        {
            InitializeComponent();
            DataContext = dataContext;
        }

        private void AddCategoryClick(object sender, RoutedEventArgs e)
        {
            Window currentWindow = Window.GetWindow(this);
            currentWindow?.Close();
            if (DataContext is ProductsViewModel productsViewModel)
            {
                productsViewModel.LoadCategories();
            }
        }
    }
}
