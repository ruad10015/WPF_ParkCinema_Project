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
    public class ShowMoviesViewModel:BaseViewModel
    {

        public WrapPanel WrapPanel { get; set; }
        public RelayCommand BackCommand { get; set; }

        public RelayCommand SearchCommand { get; set; }

        public TextBox TextBox { get; set; }

    
        public ShowMoviesViewModel()
        {
            BackPage = App.MyGrid.Children[0];
            BackCommand = new RelayCommand(d =>
            {
                App.MyGrid.Children.RemoveAt(0);
                App.MyGrid.Children.Add(BackPage);
            });

            SearchCommand = new RelayCommand((d) =>
            {
                foreach (var item in WrapPanel.Children)
                {
                    if (item is SingleMovieForShowUC uC)
                    {
                        if (uC.title_label.Content.ToString().ToLower().Contains(TextBox.Text.ToLower()))
                        {
                            uC.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            uC.Visibility = Visibility.Hidden;
                        }
                    }
                }
            });


        }
    }
}
