using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using MyShop.Commands;
using MyShop.Models;
using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using static MyShop.ViewModels.DashboardViewModel;
using LiveCharts.Wpf;
using LiveCharts;
using Axis = LiveChartsCore.SkiaSharpView.Axis;
using System.Collections.Generic;
using MyShop.Services;
using System.Threading.Tasks;

namespace MyShop.ViewModels
{
    public class ReportsViewModel : BaseViewModel
    {
        private string _option;
        private int _year;
        private int _month;
        private DateTime _startDate = new DateTime(2023,1,1);
        private DateTime _endDate = DateTime.Now;
        private List<Category> _categories;
        private Category _category;
        private string _optionProduct;


        private Axis[] _xAxes { get; set; }
        public List<Category> Categories
        {
            get => _categories;
            set
            {
                _categories = value;
                OnPropertyChanged("Categories");
            }
        }
        public Category Category
        {
            get => _category;
            set
            {
                _category = value;
                OnPropertyChanged("Category");
            }
        }
        private ISeries[] _profit_RevenueSeries { get; set; }
        public ISeries[] Profit_RevenueSeries
        {
            get => _profit_RevenueSeries;
            set
            {
                _profit_RevenueSeries = value;
                OnPropertyChanged(nameof(Profit_RevenueSeries));
            }
        }
        public Axis[] XAxes
        {
            get => _xAxes;
            set
            {
                _xAxes = value;
                OnPropertyChanged(nameof(XAxes));
            }
        }


        public string Option
        {
            get => _option;
            set
            {
                _option = value;
                OnPropertyChanged("Option");
            }
        }
        public string OptionProduct
        {
            get => _optionProduct;
            set
            {
                _optionProduct = value;
                OnPropertyChanged("OptionProduct");
            }
        }
        public int Year
        {
            get => _year;
            set
            {
                _year = value;
                OnPropertyChanged("Year");
            }
        }

        public int Month
        {
            get => _month;
            set
            {
                _month = value;
                OnPropertyChanged("Month");
            }

        }

        public Array YearValues => new int[] { 2022, 2023 };

        public DateTime EndDate
        {
            get => _endDate;
            set
            {
                _endDate = value;
                OnPropertyChanged("EndDate");
            }
        }
        
        public DateTime StartDate
        {
            get => _startDate;
            set
            {
                _startDate = value;
                OnPropertyChanged("StartDate");
            }
        }
   



       

        public Axis[] YAxes { get; set; } =
        {
            new Axis
            {
                TextSize = 12,
            }
        };
        public List<string> CategoryNames { get; set; }
        public BaseCommand CreateReportCommand { get; set; }
        public BaseCommand CreateReportProductCommand { get; set; }

        public ReportsViewModel()
        {

            loadData();
            initCommands();
        }

        public async Task loadData()
        {
            var data = await ShopService.GetAllCategories();
            Categories =data.Value.Item1;
            CategoryNames = Categories.Select(item => item.CategoryName).ToList();
        }

        public void initCommands()
        {
            CreateReportCommand = new CreateRevenue_ProfitReportCommand(this);
            CreateReportProductCommand = new CreateReportProductCommand(this);
        }
    }
}
