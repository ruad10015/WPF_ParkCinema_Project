using Cinema_MVVM_PROJECT_WPF.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_MVVM_PROJECT_WPF.Services
{
    public class MovieService
    {
        public static dynamic Data { get; set; }
        public static dynamic SingleData { get; set; }
        public static List<Movie> GetMovies(string movie)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = new HttpResponseMessage();
            response = httpClient.GetAsync($@"http://www.omdbapi.com/?apikey=8c4eb5a6&s={movie}&plot=full%22").Result;
            var str = response.Content.ReadAsStringAsync().Result;
            Data = JsonConvert.DeserializeObject(str);

            List<Movie> movies = new List<Movie>();

            try
            {
                for (int i = 0; i < 10; i++)
                {

                    response = httpClient.GetAsync($@"http://www.omdbapi.com/?apikey=8c4eb5a6&t={Data.Search[i].Title}&plot=full").Result;
                    str = response.Content.ReadAsStringAsync().Result;
                    SingleData = JsonConvert.DeserializeObject(str);
                 
                    if (SingleData.Poster!="N/A")
                    {
                       var mymovie = new Movie
                        {
                            Genre = SingleData.Genre,
                            ImagePath = SingleData.Poster,
                            Name = SingleData.Title,
                            Rating = SingleData.imdbRating,
                            VideoID = SingleData.imdbID,
                            Actors=SingleData.Actors,
                            Description=SingleData.Plot,
                            Director=SingleData.Director,
                            Released=SingleData.Released
                           
                        };
                        movies.Add(mymovie);
                    }
                    else
                    {
                        var mymovie = new Movie
                        {
                            Genre = SingleData.Genre,
                            ImagePath = "/Images/noImage.jpg",
                            Name = SingleData.Title,
                            Rating = SingleData.imdbRating,
                            
                        };
                        movies.Add(mymovie);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return movies;
        }
    }
}
