using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Cinema_MVVM_PROJECT_WPF.FileHelpers
{
    public class Global
    {
        public static ObservableCollection<Button> Button_session_1 { get; set; }
        public static ObservableCollection<Button> Button_session_2 { get; set; }
        public static ObservableCollection<Button> Button_session_3 { get; set; }
    }
}
