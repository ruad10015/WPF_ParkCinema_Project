using Cinema_MVVM_PROJECT_WPF.Commands;
using Cinema_MVVM_PROJECT_WPF.Models;
using Cinema_MVVM_PROJECT_WPF.Services;
using Cinema_MVVM_PROJECT_WPF.Views.UserControls;
using Microsoft.Web.WebView2.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Cinema_MVVM_PROJECT_WPF.ViewModels
{
    public class SearchMovieViewModel : BaseViewModel
    {
        public Label Trailer_Label { get; set; }
        public WebView2 WebView { get; set; }
        public WrapPanel WrapPanel { get; set; }
        public WrapPanel ShowMoviesWrapPanel { get; set; }
        public TextBox TextBox { get; set; }
        public RelayCommand SearchMovieCommand { get; set; }
        public RelayCommand BackCommand { get; set; }
        public List<Movie> Movies { get; set; }

        private void RegulateUCBackgroundColor(double rating, ref Label label)
        {
            if (rating >= 7)
            {
                label.Background = Brushes.Green;
            }
            else if(rating>=4 && rating < 7)
            {
                label.Background = Brushes.Orange;
            }
            else
            {
                label.Background = Brushes.Red;
            }
        }
        public SearchMovieViewModel()
        {
            BackPage = App.MyGrid.Children[0];
            BackCommand = new RelayCommand(c =>
            {
                App.MyGrid.Children.RemoveAt(0);
                App.MyGrid.Children.Add(BackPage);
            });

            SearchMovieCommand = new RelayCommand(c =>
            {
                Movies = new List<Movie>();
                Movies = MovieService.GetMovies(TextBox.Text);
                if (WrapPanel.Children.Count != 0)
                {
                    WrapPanel.Children.Clear();
                }
                if (Movies != null)
                {
                    for (int i = 0; i < Movies.Count; i++)
                    {

                        var viewModel = new SingleMovieUCViewModel()
                        {
                            Movie = Movies[i]
                        };
                        var uc = new SingleMovieUC();
                        viewModel.ShowMoviesWrapPanel = ShowMoviesWrapPanel;
                        viewModel.WebView = WebView;
                        viewModel.Label = Trailer_Label;
                        uc.DataContext = viewModel;
                        uc.Width = 250;
                        uc.Height = 350;
                        uc.Margin = new System.Windows.Thickness(10, 40, 10, 10);
  
                        WrapPanel.Children.Add(uc);
                    }
                }

            });
        }
    }
}
