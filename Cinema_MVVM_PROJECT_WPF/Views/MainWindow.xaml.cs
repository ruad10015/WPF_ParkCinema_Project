using Cinema_MVVM_PROJECT_WPF.ViewModels;
using Cinema_MVVM_PROJECT_WPF.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cinema_MVVM_PROJECT_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var viewModel = new MainViewModel();
            App.MyGrid = myGrid;
            var homeUC = new CinemaHomeUC();
            var homeUCviewModel = new CinemaHomeUCViewModel();
            homeUC.DataContext = homeUCviewModel;

            var historyView = new HistoryUC();
            var historyViewModel = new HistoryViewModel();
            historyView.DataContext = historyViewModel;
            homeUCviewModel.TicketsPanel = historyView.ticketsPanel;
            homeUCviewModel.HistoryUC = historyView;
            homeUCviewModel.HistoryViewModel = historyViewModel;
            App.MyGrid.Children.Add(homeUC);
            App.BackPage = App.MyGrid.Children[0];

            this.DataContext = viewModel;
        }
    }
}
