using Cinema_MVVM_PROJECT_WPF.Commands;
using Cinema_MVVM_PROJECT_WPF.Models;
using Cinema_MVVM_PROJECT_WPF.Views.UserControls;
using Microsoft.Web.WebView2.Wpf;
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
    public class SingleMovieUCViewModel : BaseViewModel
    {

        public Label Label { get; set; }
        public WebView2 WebView { get; set; }
        public WrapPanel ShowMoviesWrapPanel { get; set; }

        private Movie movie;

        public Movie Movie
        {
            get { return movie; }
            set { movie = value; OnPropertyChanged(); }
        }


        public RelayCommand AddMovieCommand { get; set; }

        public RelayCommand TrailerCommand { get; set; }
        //public RelayCommand StopTrailerCommand { get; set; }
        public SingleMovieUCViewModel()
        {

            AddMovieCommand = new RelayCommand(c =>
            {
                var singleMovieForShowUC = new SingleMovieForShowUC();
                var viewModel = new SingleMovieForShowViewModel();
                singleMovieForShowUC.DataContext = viewModel;

                viewModel.ShowMoviesWrapPanel = ShowMoviesWrapPanel;
                viewModel.Movie = Movie;

                singleMovieForShowUC.Height = 350;
                singleMovieForShowUC.Width = 250;
                singleMovieForShowUC.Margin = new System.Windows.Thickness(10, 60, 10, 10);
                ShowMoviesWrapPanel.Children.Add(singleMovieForShowUC);

                MessageBox.Show($"{Movie.Name} added successfully");
            });

            TrailerCommand = new RelayCommand(c =>
            {
                Label.Visibility = Visibility.Visible;
                WebView.Visibility = Visibility.Visible;
                WebView.CoreWebView2.Navigate($"https://www.imdb.com/title/{Movie.VideoID}/");
            });

            //StopTrailerCommand = new RelayCommand(c =>
            //{
            //    Label.Visibility = Visibility.Hidden;
            //    WebView.Visibility = Visibility.Hidden;
            //});
        }

    }
}
