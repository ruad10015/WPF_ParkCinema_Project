using Cinema_MVVM_PROJECT_WPF.Commands;
using Cinema_MVVM_PROJECT_WPF.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Cinema_MVVM_PROJECT_WPF.ViewModels
{
    public class AdminHomeViewModel : BaseViewModel
    {
        public HistoryUC HistoryUC { get; set; }

        public HistoryViewModel HistoryViewModel { get; set; }
        public WrapPanel TicketsPanel { get; set; }
        public RelayCommand BackCommand { get; set; }

        public RelayCommand SearchMoviesCommand { get; set; }

        public RelayCommand ShowMoviesCommand { get; set; }

        public RelayCommand ArrangeMoviesCommand { get; set; }

        public WrapPanel ShowMoviesWrapPanel { get; set; }

        public WrapPanel UserHomeWrapPanel { get; set; }

        public RelayCommand PurchaseHistoryCommand { get; set; }

        public bool IsFirst { get; set; } = true;
        public AdminHomeViewModel()
        {
            BackPage = App.MyGrid.Children[0];
            var ShowView = new ShowMoviesUC();
            BackCommand = new RelayCommand(c =>
            {

                App.MyGrid.Children.RemoveAt(0);
                App.MyGrid.Children.Add(BackPage);

            });

            SearchMoviesCommand = new RelayCommand(c =>
            {
                var view = new SearchMovieUC();
                var viewModel = new SearchMovieViewModel();
                viewModel.WrapPanel = view.moviesPanel;
                viewModel.TextBox = view.movieTxtb;
                viewModel.ShowMoviesWrapPanel = ShowView.moviesPanel;
                viewModel.WebView = view.webView;
                viewModel.Trailer_Label = view.trailer_Label;

                view.DataContext = viewModel;
                App.MyGrid.Children.RemoveAt(0);
                App.MyGrid.Children.Add(view);
            });

            ShowMoviesCommand = new RelayCommand(c =>
            {
                var viewModel = new ShowMoviesViewModel();
                ShowView.DataContext = viewModel;

                viewModel.WrapPanel = ShowView.moviesPanel;
                App.MyGrid.Children.RemoveAt(0);
                App.MyGrid.Children.Add(ShowView);
            });

            ArrangeMoviesCommand = new RelayCommand(c =>
            {
                var viewModel = new ArrangeMovieViewModel();
                var view = new ArrangeMovieUC();

                var ticketView = new TicketUC();
                var ticketViewModel = new TicketUCViewModel();
                ticketView.DataContext = ticketViewModel;

                view.DataContext = viewModel;

                viewModel.TimePicker = view.timePicker.sfTimePicker;
                viewModel.TicketsPanel = TicketsPanel;
                viewModel.DatePicker = view.datePicker;
                viewModel.PriceTxtBox = view.priceTxtbox;
                viewModel.WrapPanel = ShowView.moviesPanel;
                viewModel.ComboBox = view.movieComboBox;
                viewModel.TicketViewModel = ticketViewModel;

                viewModel.UserHomeWrapPanel = UserHomeWrapPanel;


                App.MyGrid.Children.RemoveAt(0);
                App.MyGrid.Children.Add(view);
            });



           
            PurchaseHistoryCommand = new RelayCommand(d =>
            {
           
                App.MyGrid.Children.RemoveAt(0);
                App.MyGrid.Children.Add(HistoryUC);

            });

        }




    }
}
