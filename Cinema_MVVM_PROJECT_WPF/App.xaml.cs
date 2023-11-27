using Cinema_MVVM_PROJECT_WPF.FileHelpers;
using Cinema_MVVM_PROJECT_WPF.ViewModels;
using Cinema_MVVM_PROJECT_WPF.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Cinema_MVVM_PROJECT_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Grid MyGrid;
        public static UIElement BackPage;
        public static Image Image;

        public App()
        {
            Global.Button_session_1 = new ObservableCollection<Button>();
            Global.Button_session_2 = new ObservableCollection<Button>();
            Global.Button_session_3 = new ObservableCollection<Button>();

        }

    }
}
