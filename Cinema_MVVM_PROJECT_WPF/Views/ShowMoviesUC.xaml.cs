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

namespace Cinema_MVVM_PROJECT_WPF.Views.UserControls
{
    /// <summary>
    /// Interaction logic for ShowMoviesUC.xaml
    /// </summary>
    public partial class ShowMoviesUC : UserControl
    {
        public ShowMoviesUC()
        {
            InitializeComponent();
        }

        private void movieTxtb_GotFocus(object sender, RoutedEventArgs e)
        {
            var textbox = sender as TextBox;
            textbox.Text = "";
        }
    }
}
