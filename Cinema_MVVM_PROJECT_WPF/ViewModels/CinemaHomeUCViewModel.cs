using Cinema_MVVM_PROJECT_WPF.Commands;
using Cinema_MVVM_PROJECT_WPF.ViewModels.UserViewModels;
using Cinema_MVVM_PROJECT_WPF.Views.UserControls;
using Cinema_MVVM_PROJECT_WPF.Views.UserUCs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Cinema_MVVM_PROJECT_WPF.ViewModels
{
    public class CinemaHomeUCViewModel : BaseViewModel
    {
        public WrapPanel TicketsPanel { get; set; }
        public WrapPanel UserHomeWrapPanel { get; set; }
        public RelayCommand AdminCommand { get; set; }

        public HistoryViewModel HistoryViewModel { get; set; }

        public HistoryUC HistoryUC { get; set; }
        public RelayCommand UserCommand { get; set; }

        public CinemaHomeUCViewModel()
        {
            var userHomeUC = new UserHomeUC();
            var userHomeViewModel = new UserHomeViewModel();
            userHomeUC.DataContext = userHomeViewModel;
            AdminCommand = new RelayCommand(c =>
            {
                var uc = new AdminSignUpUC();
                var viewModel = new AdminSignViewModel();
                viewModel.UserHomeWrapPanel = userHomeUC.moviesPanel;
                viewModel.HistoryView = HistoryUC;
                viewModel.HistoryViewModel = HistoryViewModel;
                uc.DataContext = viewModel;
                viewModel.TicketsPanel = TicketsPanel;
                App.MyGrid.Children.RemoveAt(0);
                App.MyGrid.Children.Add(uc);
            });

            UserCommand = new RelayCommand(c =>
            {

                App.MyGrid.Children.RemoveAt(0);
                App.MyGrid.Children.Add(userHomeUC);
            });

        }
    }
}
