using Cinema_MVVM_PROJECT_WPF.Commands;
using Cinema_MVVM_PROJECT_WPF.Models;
using Cinema_MVVM_PROJECT_WPF.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Cinema_MVVM_PROJECT_WPF.ViewModels
{
    public class SingleMovieForShowViewModel : BaseViewModel
    {
        public WrapPanel ShowMoviesWrapPanel { get; set; }
        public RelayCommand RemoveMovieCommand { get; set; }

        private Movie movie;

        public Movie Movie
        {
            get { return movie; }
            set { movie = value; OnPropertyChanged(); }
        }
        public ObservableCollection<Movie> Movies { get; set; }

        public SingleMovieForShowViewModel()
        {
            RemoveMovieCommand = new RelayCommand(d =>
            {
                int index = 0;
                foreach (var item in ShowMoviesWrapPanel.Children)
                {
                    if (item is SingleMovieForShowUC uC)
                    {
                        if (uC.title_label.Content.ToString() == Movie.Name &&
                        uC.rating_label.Content.ToString() == Movie.Rating)
                            index = ShowMoviesWrapPanel.Children.IndexOf(uC);
                    }
                }
                ShowMoviesWrapPanel.Children.RemoveAt(index);
            });

        }


    }
}
