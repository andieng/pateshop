using MyShop.Commands;
using System;
using System.Collections.ObjectModel;
using System.Configuration;

namespace MyShop.ViewModels
{
    public class MainViewModel : BaseViewModel
    {

        public MainViewModel()
        {
            
            //_tabs.Add(new ViewModel());

            initCommands();
        }

        public BaseCommand OpenSettingsCommand { get; set; }
        public void initCommands()
        {
            //OpenSettingsCommand = new OpenSettingsLoginCommand(this);
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
