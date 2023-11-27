using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_MVVM_PROJECT_WPF.Models
{
    public class TicketItem
    {
        public Guid Guid { get; set; }
        public Movie Movie { get; set; }
        public Place Place { get; set; }
        public DateTime? DateTime { get; set; }
        public ObservableCollection<string> TimeList { get; set; }

        public string Time { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public string Hall { get; set; }
    }
}
