using Cinema_MVVM_PROJECT_WPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_MVVM_PROJECT_WPF.ViewModels
{
    public class TicketUCViewModel:BaseViewModel
    {

        private Movie movie;

        public Movie Movie
        {
            get { return movie; }
            set { movie = value; OnPropertyChanged(); }
        }

        private TicketItem ticket;

        public TicketItem Ticket
        {
            get { return ticket; }
            set { ticket = value; OnPropertyChanged(); }
        }


        private Place place;

        public Place Place
        {
            get { return place; }
            set { place = value; OnPropertyChanged(); }
        }

        public TicketUCViewModel()
        {
           
        }

    }
}
