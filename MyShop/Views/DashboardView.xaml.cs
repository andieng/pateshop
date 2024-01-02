using MyShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MyShop.Views
{
    public partial class DashboardView : UserControl
    {
        public DashboardView()
        {
            InitializeComponent();
        }

        public async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var dashboardViewModel = await DashboardViewModel.Create();
            DataContext = dashboardViewModel;
            orderAnalyticsYear.Text = DateTime.Now.Year.ToString();
        }
    }
}
