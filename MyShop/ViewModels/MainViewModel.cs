using MyShop.Commands;
using MyShop.Models;
using MyShop.Services;
using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows;

namespace MyShop.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public User User { get; private set; }

        public MainViewModel(User user)
        {
            User = user;
            initCommands();
        }

        public BaseCommand OpenSettingsCommand { get; set; }
        public BaseCommand LogoutCommand { get; set; }
        public void initCommands()
        {
            LogoutCommand = new LogoutCommand(this);
        }

        public async Task<bool> Logout()
        {
            return await ShopService.LogoutAsync();
        }

        public void OpenSettings()
        {
            //Window settings = new SettingsView();
            //var settingsVM = new SettingsViewModel();
            //settingsVM.PropertyChanged += (s, e) =>
            //{
            //    string? strItemsPerPage = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
            //                    .AppSettings.Settings["itemsPerPage"].Value;
            //    if (strItemsPerPage != null)
            //    {
            //        int newItemsPerPage = int.Parse(strItemsPerPage);
            //        if (newItemsPerPage == _itemsPerPage)
            //        {
            //            return;
            //        }

            //        _itemsPerPage = newItemsPerPage;
            //        _currentPage = 1;
            //        UpdateBookList();

            //        OnPropertyChanged("ItemsPerPage");
            //        OnPropertyChanged("CurrentPage");
            //    }
            //};
            //settings.DataContext = settingsVM;
            //settings.ShowDialog();
        }
    }
}
