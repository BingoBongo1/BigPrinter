using BigPrinter.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using BigPrinter.View;

namespace BigPrinter.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private Page currentPage;
              
        public Page CurrentPage
        {
            get => currentPage;
            set
            {
                currentPage = value;
                SignalChanged();
            }
        }               
          
        public MainViewModel()
        {
            CurrentPage = new ClaimPage();

        }
    }
}
