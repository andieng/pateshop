using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyShop.ViewModels
{
    public class BaseModalViewModel : BaseViewModel
    {
        public void Close(Window window)
        {
            if (window != null)
            {
                window.Close();
            }
        }
    }
}
