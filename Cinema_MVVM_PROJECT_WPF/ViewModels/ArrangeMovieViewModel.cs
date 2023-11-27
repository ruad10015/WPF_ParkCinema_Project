using Cinema_MVVM_PROJECT_WPF.Commands;
using Cinema_MVVM_PROJECT_WPF.FileHelpers;
using Cinema_MVVM_PROJECT_WPF.Models;
using Cinema_MVVM_PROJECT_WPF.ViewModels.UserViewModels;
using Cinema_MVVM_PROJECT_WPF.Views.UserControls;
using Cinema_MVVM_PROJECT_WPF.Views.UserUCs;
using MaterialDesignThemes.Wpf;
using Syncfusion.Windows.Controls.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Cinema_MVVM_PROJECT_WPF.ViewModels
{
    public class ArrangeMovieViewModel : BaseViewModel
    {
        public WrapPanel TicketsPanel { get; set; }
        public ObservableCollection<string> MovieTimeList { get; set; }

        private double totalVolume;

        public double TotalVolume
        {
            get { return totalVolume; }
            set { totalVolume = value; OnPropertyChanged(); }
        }



        private string imagePath;

        public string ImagePath
        {
            get { return imagePath; }
            set { imagePath = value; OnPropertyChanged(); }
        }


        private TicketUCViewModel ticketViewModel;

        public TicketUCViewModel TicketViewModel
        {
            get { return ticketViewModel; }
            set { ticketViewModel = value; OnPropertyChanged(); }
        }

        private TicketItem ticket;

        public TicketItem Ticket
        {
            get { return ticket; }
            set { ticket = value; }
        }

        public WrapPanel UserHomeWrapPanel { get; set; }
        public ComboBox ComboBox { get; set; }
        public WrapPanel WrapPanel { get; set; }
        public DatePicker DatePicker { get; set; }
        public SfTimePicker TimePicker { get; set; }

        public RelayCommand SelectedCommand { get; set; }
        public RelayCommand PlusCommand { get; set; }

        public RelayCommand MinusCommand { get; set; }

        public RelayCommand ConfirmCommand { get; set; }

        private int count;

        public int Count
        {
            get { return count; }
            set { count = value; OnPropertyChanged(); }
        }

        public TextBox PriceTxtBox { get; set; }

        private double price;

        public double Price
        {
            get { return price; }
            set { price = value; OnPropertyChanged(); }
        }

        public RelayCommand DoneCommand { get; set; }

        public RelayCommand BackCommand { get; set; }

        public RelayCommand GetMoviesCommand { get; set; }

        public ObservableCollection<Movie> Movies { get; set; }


        private Movie movie;

        public Movie SelectedMovie
        {
            get { return movie; }
            set { movie = value; OnPropertyChanged(); }

        }

        private ObservableCollection<Movie> GetMovies()
        {
            foreach (var item in WrapPanel.Children)
            {
                if (item is SingleMovieForShowUC uC)
                {
                    Movie movie = new Movie();
                    movie.Name = uC.title_label.Content.ToString();
                    movie.Genre = uC.genre_label.Content.ToString();
                    movie.Rating = uC.rating_label.Content.ToString();
                    movie.ImagePath = uC.image.Source.ToString();
                    movie.Description = uC.description_label.Content.ToString();
                    movie.Actors = uC.actors_label.Content.ToString();
                    movie.Director = uC.director_label.Content.ToString();
                    movie.Released = uC.released_label.Content.ToString();
                    movie.VideoID = uC.videoID_label.Content.ToString();
                    Movies.Add(movie);
                }
            }
            return Movies;
        }
        public ArrangeMovieViewModel()
        {
            ImagePath = "/Images/cross.png";
            Movies = new ObservableCollection<Movie>();
            BackPage = App.MyGrid.Children[0];

            BackCommand = new RelayCommand(c =>
            {
                App.MyGrid.Children.RemoveAt(0);
                App.MyGrid.Children.Add(BackPage);
            });


            GetMoviesCommand = new RelayCommand(d =>
            {

                if (WrapPanel.Children.Count != 0)
                {
                    Movies = GetMovies();
                    MessageBox.Show("Movies successfully added\nCheck movie box again!");
                }
                else
                {
                    MessageBox.Show("No movies exist in movie list!");
                }

            });


            SelectedCommand = new RelayCommand(d =>
            {
                var selectedMovie = d as Movie;
                SelectedMovie = selectedMovie;
                TicketViewModel.Movie = SelectedMovie;
            });

            PlusCommand = new RelayCommand(d =>
            {
                if (Count <= 30)
                    Count++;
            });

            MinusCommand = new RelayCommand(d =>
            {
                if (Count > 0)
                {
                    Count--;
                }
            });



            ConfirmCommand = new RelayCommand(d =>
            {

                var place = new Place
                {
                    Row = "X",
                    SeatNumber = "X"
                };

                bool isParsed = Double.TryParse(PriceTxtBox.Text, out double price);
                DateTime dt = DateTime.Parse(TimePicker.Value.ToString());

                var time = dt.ToString("h:mm tt");

                MovieTimeList = new ObservableCollection<string>();
                MovieTimeList.Add(time);

                if (TimePicker.Value.ToString() != "20:45" && DatePicker.SelectedDate != null
                && Count != 0 && SelectedMovie != null)
                {

                    if (isParsed)
                    {
                        var ticket = new TicketItem()
                        {
                            Count = Count,
                            Guid = Guid.NewGuid(),
                            Movie = SelectedMovie,
                            DateTime = DatePicker.SelectedDate,
                            TimeList = MovieTimeList,
                            Place = place,
                            Price = price
                        };
                        TicketViewModel.Ticket = ticket;
                        TicketViewModel.Place = place;
                        TicketViewModel.Movie = SelectedMovie;
                        ImagePath = "/Images/tick.png";
                        TotalVolume = Count * price;
                        Ticket = ticket;
                    }
                    else
                    {
                        MessageBox.Show("Enter valid price value!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Fill all fields", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }


            });

            DoneCommand = new RelayCommand(d =>
            {
                var userHomeUC = new UserHomeUC();
                var userHomeViewModel = new UserHomeViewModel();
                userHomeViewModel.UserHomeWrapPanel = userHomeUC.moviesPanel;
                userHomeUC.DataContext = userHomeViewModel;

                var userBuyUC = new UserBuyUC();
                var userBuyViewModel = new UserBuyViewModel();

                userBuyViewModel.Button = userBuyUC.end_button;
                userBuyViewModel.WebViewTrailer = userBuyUC.webView;
                userBuyViewModel.Movie = Ticket.Movie;
                userBuyViewModel.Ticket = Ticket;
                userBuyViewModel.SeatStackPanel = userBuyUC.seat_Stack_Panel;
                userBuyViewModel.TimeList = MovieTimeList;
                userBuyViewModel.BuyStackPanel = userBuyUC.buy_Stack_Panel;
                userBuyViewModel.TicketsPanel = TicketsPanel;
                userBuyViewModel.Price_Label = userBuyUC.price_Label;
                foreach (var item in userBuyUC.seat_Stack_Panel.Children)
                {
                    if (item is StackPanel sP)
                    {
                        foreach (var seat in sP.Children)
                        {
                            if (seat is Button button)
                            {
                                if (button.Width == 20)
                                {
                                    userBuyViewModel.Buttons.Add(button);
                                    Global.Button_session_1.Add(button);
                                    Global.Button_session_2.Add(button);
                                    Global.Button_session_3.Add(button);
                                }
                            }
                        }
                    }
                }
               

                userBuyUC.DataContext = userBuyViewModel;
                userBuyUC.Width = 1000;
                userBuyUC.Height = 450;
                userBuyUC.Margin = new System.Windows.Thickness(0, 40, 10, 0);
                MessageBox.Show("Movie Added to User Panel");
                UserHomeWrapPanel.Children.Add(userBuyUC);

            });

        }

    }
}
