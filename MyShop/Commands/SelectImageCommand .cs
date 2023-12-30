using Microsoft.Win32;
using MyShop.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyShop.Commands
{
    public class SelectImageCommand : BaseCommand
    {
        private readonly ProductsViewModel _productsViewModel;

        public SelectImageCommand(ProductsViewModel productsViewModel)
        {
            _productsViewModel = productsViewModel;
        }
        public override void Execute(object parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                _productsViewModel.SelectedImg = openFileDialog.FileName;
            }
        }
    }
}
