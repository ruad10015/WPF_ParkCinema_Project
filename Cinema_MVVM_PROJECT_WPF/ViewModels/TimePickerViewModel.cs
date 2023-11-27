using Cinema_MVVM_PROJECT_WPF.Commands;
using Cinema_MVVM_PROJECT_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Cinema_MVVM_PROJECT_WPF.ViewModels
{
    public class TimePickerViewModel:BaseViewModel
    {
        private DateTime? time;

        public DateTime? Time
        {
            get { return time; }
            set { time = value; OnPropertyChanged(); }
        }

        public RelayCommand ValueChangedCommand { get; set; }

        public TimePickerViewModel()
        {
            ValueChangedCommand = new RelayCommand(d =>
            {
                MessageBox.Show("Value Changed");
                var selectedTime=d as DateTime?;
                Time = selectedTime.Value;               
            });
        }
    }
}
