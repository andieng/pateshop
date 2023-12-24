using MyShop.Commands;
using MyShop.Models;
using MyShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MyShop.Views
{
    public partial class ProductsView : UserControl
    {
        public ProductsView()
        {
            InitializeComponent();
            DataContext = new ProductsViewModel();
        }

        private void PreviewMouseLeftBtnDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            var button = sender as Button;
            if (button != null)
            {
                var category = button.DataContext as Category;
                var command = button.Tag as BaseCommand;
                if (command != null && category != null)
                {
                    command.Execute(category);
                }
            }
        }

        private void InputCategoryName_MouseLeftBtnDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            if (sender is TextBox textBox)
            {
                textBox.Focus();
                textBox.SelectAll();
            }
        }

        private void AddCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            AddCategoryView addCategoryWindow = new AddCategoryView(DataContext);
            addCategoryWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            addCategoryWindow.ShowDialog();
        }
    }
}
