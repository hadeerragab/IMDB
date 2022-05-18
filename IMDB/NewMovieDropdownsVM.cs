using IMDB.Models;
using System.Collections.Generic;


namespace IMDB.Data.ViewModels
{
    public class NewMovieDropdownsVM
    {
        public NewMovieDropdownsVM()
        {
            Directors = new List<Director>();
           
            Actors = new List<Actor>();

            Movies = new List<Movie>();
        }

        public List<Director> Directors { get; set; }
       
        public List<Actor> Actors { get; set; }

        public List<Movie> Movies { get; set; }
    }
}
