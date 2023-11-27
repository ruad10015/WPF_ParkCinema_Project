using Cinema_MVVM_PROJECT_WPF.Commands;
using Cinema_MVVM_PROJECT_WPF.FileHelpers;
using Cinema_MVVM_PROJECT_WPF.Models;
using Cinema_MVVM_PROJECT_WPF.Views.UserControls;
using Cinema_MVVM_PROJECT_WPF.Views.UserUCs;
using Microsoft.Web.WebView2.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using static System.Resources.ResXFileRef;

namespace Cinema_MVVM_PROJECT_WPF.ViewModels.UserViewModels
{
    public class UserBuyViewModel : BaseViewModel
    {

        public Label Price_Label { get; set; }

        private double sumPrice;

        public double SumPrice
        {
            get { return sumPrice; }
            set { sumPrice = value; OnPropertyChanged(); }
        }


        private double price;

        public double Price
        {
            get { return price; }
            set { price = value; OnPropertyChanged(); }
        }


        public WrapPanel TicketsPanel { get; set; }

        private string time;

        public string SelectedTime
        {
            get { return time; }
            set { time = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Button> Buttons { get; set; }
        public ObservableCollection<Button> Buttons_session_1 { get; set; }
        public ObservableCollection<Button> Buttons_session_2 { get; set; }
        public ObservableCollection<Button> Buttons_session_3 { get; set; }


        public Button Button { get; set; }
        public WebView2 WebViewTrailer { get; set; }

        private Movie movie;

        public Movie Movie
        {
            get { return movie; }
            set { movie = value; OnPropertyChanged(); }
        }

        public StackPanel BuyStackPanel { get; set; }

        public StackPanel SeatStackPanel { get; set; }

        public RelayCommand BuyCommand { get; set; }
        public RelayCommand WatchCommand { get; set; }
        public RelayCommand EndCommand { get; set; }
        public RelayCommand ClickCommand { get; set; }
        public RelayCommand CompletePurchaseCommand { get; set; }

        public RelayCommand SelectedTimeCommand { get; set; }
        public ObservableCollection<string> TimeList { get; set; }

        public RelayCommand BackCommand { get; set; }

        private TicketItem ticket;

        public TicketItem Ticket
        {
            get { return ticket; }
            set { ticket = value; OnPropertyChanged(); }
        }

        private void ChangeSeatColor(StackPanel stackPanel)
        {
            foreach (var item in stackPanel.Children)
            {
                if (item is StackPanel sP)
                {
                    foreach (var seat in sP.Children)
                    {
                        if (seat is Button button)
                        {
                            var converter = new System.Windows.Media.BrushConverter();
                            button.Background = (Brush)converter.ConvertFromString("#1F1F2B");
                        }
                    }
                }
            }
        }

        public UserBuyViewModel()
        {
            TimeList = new ObservableCollection<string>();
            Buttons = new ObservableCollection<Button>();
            Buttons_session_1 = new ObservableCollection<Button>();
            Buttons_session_2 = new ObservableCollection<Button>();
            Buttons_session_3 = new ObservableCollection<Button>();
            WatchCommand = new RelayCommand(d =>
            {
                Button.Visibility = System.Windows.Visibility.Visible;
                WebViewTrailer.Visibility = System.Windows.Visibility.Visible;
                WebViewTrailer.CoreWebView2.Navigate($"https://www.imdb.com/title/{Movie.VideoID}/");
            });

            EndCommand = new RelayCommand(d =>
            {
                Button.Visibility = System.Windows.Visibility.Hidden;
                WebViewTrailer.CoreWebView2.Navigate($"https://www.microsoft.com");
                WebViewTrailer.Visibility = System.Windows.Visibility.Hidden;
            });


            BuyCommand = new RelayCommand(d =>
            {
                ChangeSeatColor(SeatStackPanel);
                var converter = new System.Windows.Media.BrushConverter();
                BuyStackPanel.Background = (Brush)converter.ConvertFromString("#0F0F1B");
                SeatStackPanel.Visibility = System.Windows.Visibility.Visible;

            });

            ClickCommand = new RelayCommand(d =>
            {
                var button = d as Button;
                var converter = new System.Windows.Media.BrushConverter();
                var brush_dark = (Brush)converter.ConvertFromString("#FF1F1F2B");
                var brush_white = (Brush)converter.ConvertFromString("#FFFFFF");
                if (button.Background.ToString() == brush_dark.ToString())
                    button.Background = Brushes.White;
                else
                    button.Background = (Brush)converter.ConvertFromString("#1F1F2B");

            });


            SelectedTimeCommand = new RelayCommand(d =>
            {
                var time = d as string;
                SelectedTime = time;
                if (SelectedTime == TimeList[0])
                {
                    Buttons = Global.Button_session_1;
                }
                else if (SelectedTime == TimeList[1])
                {
                    Buttons = Global.Button_session_2;
                }
                else if (SelectedTime == TimeList[2])
                {
                    Buttons = Global.Button_session_3;
                }
            });

            BackCommand = new RelayCommand(d =>
            {
                SeatStackPanel.Visibility = System.Windows.Visibility.Hidden;
                SelectedTime = null;
                var converter = new System.Windows.Media.BrushConverter();
                var brush_dark = (Brush)converter.ConvertFromString("#292F36");
                BuyStackPanel.Background = brush_dark;
            });

            CompletePurchaseCommand = new RelayCommand(d =>
            {
                var place = new Place();
                Price = 0;
                SumPrice = 0;
                foreach (var item in SeatStackPanel.Children)
                {
                    foreach (var item2 in SeatStackPanel.Children)
                    {
                        if (item2 is StackPanel sP)
                        {
                            foreach (var seat in sP.Children)
                            {
                                if (seat is Button button)
                                {
                                    if (button.Background == Brushes.White)
                                    {
                                        button.Background = Brushes.Red;
                                        char number = ' ';
                                        var s = button.Parent as StackPanel;
                                        number = s.Name[s.Name.Length - 1];
                                        var seatNumber = button.Name[button.Name.Length - 1];
                                        place = new Place()
                                        {
                                            Row = number.ToString(),
                                            SeatNumber = seatNumber.ToString()
                                        };
                                        Price = Ticket.Price + Convert.ToDouble(number.ToString());
                                        SumPrice += Price;
                                        TicketItem ticketItem = new TicketItem()
                                        {
                                            Guid = Guid.NewGuid(),
                                            DateTime = Ticket.DateTime,
                                            Movie = Ticket.Movie,
                                            Time = SelectedTime,
                                            Place = place,
                                            Price = Price
                                        };
                                        var uc = new TicketUC();
                                        var viewModel = new TicketUCViewModel();
                                        uc.DataContext = viewModel;

                                        viewModel.Ticket = ticketItem;
                                        viewModel.Movie = Movie;
                                        viewModel.Place = place;
                                        uc.Height = 450;
                                        uc.Width = 260;
                                        uc.Margin = new System.Windows.Thickness(10, 100, 10, 10);
                                        TicketsPanel.Children.Add(uc);
                                    }
                                }
                            }
                        }
                    }
                }

                    foreach (var item in Global.Button_session_1)
                    {
                        if (item.Background == Brushes.White)
                        {
                            item.Background = Brushes.Red;
                        }
                    }

            }

            );


        }

    }
}
