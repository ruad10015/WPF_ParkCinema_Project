using Cinema_MVVM_PROJECT_WPF.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Cinema_MVVM_PROJECT_WPF.ViewModels
{
    public class HistoryViewModel : BaseViewModel
    {
        public RelayCommand BackCommand { get; set; }
        public WrapPanel TicketsPanel { get; set; }

        public HistoryViewModel()
        {

            //BackPage = App.MyGrid.Children[0];

            BackCommand = new RelayCommand(c =>
            {
                App.MyGrid.Children.RemoveAt(0);
                App.MyGrid.Children.Add(App.BackPage);
            });
        }
    }
}
