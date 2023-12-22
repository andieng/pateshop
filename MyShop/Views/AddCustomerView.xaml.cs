using MyShop.ViewModels;
using System.Windows;

namespace MyShop.Views
{
    /// <summary>
    /// Interaction logic for AddCustomerView.xaml
    /// </summary>
    public partial class AddCustomerView : Window
    {
        public AddCustomerView()
        {
            InitializeComponent();

            var addCustomerViewModel = new AddCustomerViewModel();
            DataContext = addCustomerViewModel;
        }
    }
}
