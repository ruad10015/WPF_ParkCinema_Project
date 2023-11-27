using Cinema_MVVM_PROJECT_WPF.Commands;
using Cinema_MVVM_PROJECT_WPF.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Cinema_MVVM_PROJECT_WPF.ViewModels
{
    public class AdminSignViewModel : BaseViewModel
    {

        public HistoryUC HistoryView { get; set; }
        public HistoryViewModel HistoryViewModel { get; set; }
        public WrapPanel TicketsPanel { get; set; }
        public WrapPanel UserHomeWrapPanel { get; set; }
        public RelayCommand BackCommand { get; set; }
        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; OnPropertyChanged(); }
        }
        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged(); }
        }
        public RelayCommand SignInCommand { get; set; }
        public AdminSignViewModel()
        {
            BackPage = App.MyGrid.Children[0];
            BackCommand = new RelayCommand(c =>
            {
                App.MyGrid.Children.RemoveAt(0);
                App.MyGrid.Children.Add(BackPage);
            });

            SignInCommand = new RelayCommand(c =>
            {
                if (Username == "admin" && Password == "admin")
                {                  
                    var view = new AdminHomeUC();
                    var viewModel = new AdminHomeViewModel();
                    viewModel.UserHomeWrapPanel = UserHomeWrapPanel;
                    viewModel.TicketsPanel=TicketsPanel;
                    viewModel.HistoryViewModel = HistoryViewModel;
                    viewModel.HistoryUC = HistoryView;
                    view.DataContext = viewModel;
                    App.MyGrid.Children.RemoveAt(0);
                    App.MyGrid.Children.Add(view);
                }
                else
                {
                    MessageBox.Show("Wrong username or password");
                }
            });
        }
    }
}
