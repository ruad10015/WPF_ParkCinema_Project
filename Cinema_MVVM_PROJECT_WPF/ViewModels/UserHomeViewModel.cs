using Cinema_MVVM_PROJECT_WPF.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Cinema_MVVM_PROJECT_WPF.ViewModels.UserViewModels
{
    public class UserHomeViewModel : BaseViewModel
    {
        public WrapPanel UserHomeWrapPanel { get; set; }

        public RelayCommand BackCommand { get; set; }
        public UserHomeViewModel()
        {
            BackCommand = new RelayCommand(d =>
            {
                BackPage = App.BackPage;
                App.MyGrid.Children.RemoveAt(0);
                App.MyGrid.Children.Add(BackPage);
            });
        }
    }
}
