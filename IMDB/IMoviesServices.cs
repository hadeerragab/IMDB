using IMDB.Data.Base;
using IMDB.Data.ViewModels;
using IMDB.Models;
using System.Threading.Tasks;

namespace IMDB.Data.services
{
    public interface IMoviesServices : IEntityBaseRepository<Movie>
    {
        Movie GetMovieByID(int MovieID);
        NewMovieDropdownsVM GetNewMovieDropdownsValues();
        void AddNewMovie(NewMovieVM data);
        void UpDateMovie(NewMovieVM data);
       
    }
}
