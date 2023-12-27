using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Commands
{
    public class SelectImageCommand : BaseCommand
    {
        public override void Execute(object parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                string resourcesDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources");
                string productsDirectory = Path.Combine(resourcesDirectory, "Products");

                string selectedImagePath = openFileDialog.FileName;
                string fileName = Path.GetFileName(selectedImagePath);
                string destinationFilePath = Path.Combine(productsDirectory, fileName);

                File.Copy(selectedImagePath, destinationFilePath, true);

            }
        }
    }
}
