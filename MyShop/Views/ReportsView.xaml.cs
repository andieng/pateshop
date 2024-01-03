using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MyShop.Views
{
    public partial class ReportsView : UserControl
    {
        public ReportsView()
        {
            InitializeComponent();
        }

        private void ComboBoxOptions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (OptionsCombobox.SelectedItem.ToString())
            {
                case "System.Windows.Controls.ComboBoxItem: Daily":
                    MonthlyOptions.Visibility = Visibility.Hidden;
                    DailyOptions.Visibility = Visibility.Visible;
                    break;
                case "System.Windows.Controls.ComboBoxItem: Monthly":
                    DailyOptions.Visibility = Visibility.Hidden;
                    MonthlyOptions.Visibility = Visibility.Visible;
                    break;
                case "System.Windows.Controls.ComboBoxItem: Yearly":
                    DailyOptions.Visibility = Visibility.Hidden;
                    MonthlyOptions.Visibility = Visibility.Hidden;
                    break;
                default:
                    break;
            }
        }

        private void OptionsProductCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (OptionsProductCombobox.SelectedItem.ToString())
            {
                case "System.Windows.Controls.ComboBoxItem: Daily":
                    MonthlyProductOptions.Visibility = Visibility.Hidden;
                    DailyProductOptions.Visibility = Visibility.Visible;
                    break;
                case "System.Windows.Controls.ComboBoxItem: Monthly":
                    DailyProductOptions.Visibility = Visibility.Hidden;
                    MonthlyProductOptions.Visibility = Visibility.Visible;
                    break;
                case "System.Windows.Controls.ComboBoxItem: Yearly":
                    DailyProductOptions.Visibility = Visibility.Hidden;
                    MonthlyProductOptions.Visibility = Visibility.Hidden;
                    break;
                default:
                    break;
            }
        }
    }
}
