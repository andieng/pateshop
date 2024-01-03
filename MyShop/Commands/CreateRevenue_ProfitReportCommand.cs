using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using MyShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShop.Services;
using System.Text.Json;

namespace MyShop.Commands
{
    public class CreateRevenue_ProfitReportCommand:BaseCommand
    {
        private readonly ReportsViewModel _reportsViewModel;

        public CreateRevenue_ProfitReportCommand(ReportsViewModel reportsViewModel)
        {
            _reportsViewModel = reportsViewModel;
        }

        public override async void Execute(object parameter)
        {
            var option = _reportsViewModel.Option.Split(": ")[1];
            var ProfitValues = new List<double>();
            var RevenueValues = new List<double>();
            List<string> xLabels = new List<string>();
            if (option == "Daily")
            {
                var startDate = _reportsViewModel.StartDate;
                var endDate = _reportsViewModel.EndDate;
                //call api
                var data = await ShopService.ReportProfitRevenueDaily(startDate,endDate);
                if (data != null)
                {
                    foreach (var item in data)
                    {
                        var jsonElement = (JsonElement)item; // Convert to JsonElement

                        var profit = Convert.ToDouble(jsonElement.GetProperty("profit").GetString());
                        var revenue = Convert.ToDouble(jsonElement.GetProperty("revenue").GetString());
                        var name = jsonElement.GetProperty("date").GetString();
                        ProfitValues.Add(profit);
                        RevenueValues.Add(revenue);
                        xLabels.Add(name);
                    }
                }
               
            }
            else if(option == "Monthly")
            {
                var year = _reportsViewModel.Year;
                //call api
                var data = await ShopService.ReportProfitRevenueMonthly(year);
                if (data != null)
                {
                    foreach (var item in data)
                    {
                        var jsonElement = (JsonElement)item; // Convert to JsonElement

                        var profit = Convert.ToDouble(jsonElement.GetProperty("profit").GetString());
                        var revenue = Convert.ToDouble(jsonElement.GetProperty("revenue").GetString());

                        ProfitValues.Add(profit);
                        RevenueValues.Add(revenue);
                    }
                }
                xLabels = new List<string> { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };

            } 
            else if( option == "Yearly")
            {
                //call api
                var data = await ShopService.ReportProfitRevenueYearly();
                if(data!=null) { 
                foreach (var item in data)
                {
                    var jsonElement = (JsonElement)item; // Convert to JsonElement

                    var profit = Convert.ToDouble(jsonElement.GetProperty("profit").GetString());
                    var revenue = Convert.ToDouble(jsonElement.GetProperty("revenue").GetString());
                    var yearString = Convert.ToString(jsonElement.GetProperty("year").GetString());

                    ProfitValues.Add(profit);
                    RevenueValues.Add(revenue);
                    xLabels.Add(yearString);
                }
                }
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
                    new ColumnSeries<double>
                    {
                        Values = ProfitValues,
                        Name = "Profit"
                    },
                    new ColumnSeries<double>
                    {
                        Values = RevenueValues,
                        Name = "Revenue"

                    },
            };
        }
    }
}
