using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using MyShop.Services;
using MyShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace MyShop.Commands
{
    public class CreateReportProductCommand : BaseCommand
    {
        private readonly ReportsViewModel _reportsViewModel;

        public CreateReportProductCommand(ReportsViewModel reportsViewModel)
        {
            _reportsViewModel = reportsViewModel;
        }

        public override async void Execute(object parameter)
        {
            int categoryId = _reportsViewModel.Category.CategoryId;
            var option = _reportsViewModel.OptionProduct.Split(": ")[1];
            var SoldValues = new List<int>();
            List<string> xLabels = new List<string>();
            var data = new List<object>();
            if (option == "Daily")
            {
                var startDate = _reportsViewModel.StartDate;
                var endDate = _reportsViewModel.EndDate;
           
                var year = _reportsViewModel.Year;
                //call api
                data = await ShopService.ReportProductDaily(categoryId,startDate, endDate);
            }
            else if (option == "Monthly")
            {
                var year = _reportsViewModel.Year;
                //call api
                data = await ShopService.ReportProductMonthly(categoryId,year);
            }
            else if (option == "Yearly")
            {
                //call api
               data = await ShopService.ReportProductYearly(categoryId);
            }
            foreach (var item in data)
            {
                var jsonElement = (JsonElement)item; // Convert to JsonElement

                var value = Convert.ToInt32(jsonElement.GetProperty("total_quantity_sold").GetString());
                var name = jsonElement.GetProperty("product_name").GetString();

                SoldValues.Add(value);
                xLabels.Add(name);
            }
            //set x
            _reportsViewModel.XAxes = new Axis[]
               {
            new Axis
            {
                Labels = xLabels,
                TextSize = 12
            }
               };
            //set chart

            _reportsViewModel.Profit_RevenueSeries = new ISeries[]
            {
                    new ColumnSeries<int>
                    {
                        Values = SoldValues
                    }
            };
        }
    }
}
