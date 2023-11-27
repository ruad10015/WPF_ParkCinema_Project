using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_MVVM_PROJECT_WPF.Models
{
    public class Movie
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Rating { get; set; }
        public string ImagePath { get; set; }
        public string VideoID { get; set; }
        public string Description { get; set; }
        public string Released { get; set; }
        public string Actors { get; set; }
        public string Director { get; set; }
    }
}
