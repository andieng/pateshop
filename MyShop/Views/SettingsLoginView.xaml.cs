using MyShop.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace MyShop.Views
{
    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsLoginView : Window
    {
        public SettingsLoginView()
        {
            InitializeComponent();
            var settingsViewModel = new SettingsLoginViewModel();
            DataContext = settingsViewModel;
        }
    }

}
