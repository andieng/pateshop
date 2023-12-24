using MyShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Data;

namespace MyShop.Views
{
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            var tabControl = sender as TabControl;

            if (tabControl != null)
            {
                var index = tabControl.SelectedIndex;
                if (index == 0) 
                { 
                    dashboardTimeStackPanel.Visibility = Visibility.Visible;
                    dashboardTimeTextBlock.Text = DateTime.Now.ToString(@"MM\/yyyy");
                }
                else    
                { 
                    dashboardTimeStackPanel.Visibility = Visibility.Collapsed; 
                }
            }
        }
    }
}
