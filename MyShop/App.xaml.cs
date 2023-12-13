using Microsoft.Extensions.DependencyInjection;
using MyShop.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.Hosting;
using MyShop.ViewModels;

namespace MyShop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            //ShopService.InitializeClient();
        }
    }
}
