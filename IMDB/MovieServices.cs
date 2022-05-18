using IMDB.Data.Base;
using IMDB.Data.ViewModels;
using IMDB.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace IMDB.Data.services
{
    public class MovieServices : EntityBaseRepository<Movie>, IMoviesServices
    {
        private readonly AppDbContext _context;
        public MovieServices(AppDbContext context) : base(context)
        {
            _context = context;
        }

      
        public void AddNewMovie(NewMovieVM data)
        {
            var newMovie = new Movie()
            {
                name = data.Name,
               
                imageURL = data.ImageURL,
               
                dirictorID = data.DirectorId
            };
             _context.Movies.Add(newMovie);
             _context.SaveChanges();


            //Add Movie Actors
            foreach (var actorId in data.ActorIds)
            {
                var newActorMovie = new Actor_make_Movie()
                {
                    MovieId = newMovie.ID,
                    ActorId = actorId
                };
                _context.Actors_Movies.Add(newActorMovie);
            }
             _context.SaveChanges();
        }

        public Movie GetMovieByID(int MovieID)
        {
            var movieDetails = _context.Movies
               .Include(D => D.Director )
               .Include(am => am.Actors_Movies).ThenInclude(a => a.Actor)
               .FirstOrDefault(n => n.ID == MovieID);

            return movieDetails;
        }

        public NewMovieDropdownsVM GetNewMovieDropdownsValues()
        {
            var response = new NewMovieDropdownsVM();

                response.Actors =  _context.Actors.OrderBy(n => n.Fname).ToList();
                response.Directors =  _context.Directors.OrderBy(n => n.Fname).ToList();

            return response;
        }

        public void UpDateMovie(NewMovieVM data)
        {
            var dbMovie =  _context.Movies.FirstOrDefault(n => n.ID == data.Id);

            if (dbMovie != null)
            {

                dbMovie.name = data.Name;

                dbMovie.imageURL = data.ImageURL;

                dbMovie.dirictorID = data.DirectorId;
               
               // _context.Movies.Add(newMovie);
                _context.SaveChanges();
            }

            //Remove existing actors
            var existingActorsDb = _context.Actors_Movies.Where(n => n.MovieId == data.Id).ToList();
            _context.Actors_Movies.RemoveRange(existingActorsDb);
            _context.SaveChanges();


            ////Add Movie Actors
            foreach (var actorId in data.ActorIds)
            {
                var newActorMovie = new Actor_make_Movie()
                {
                    MovieId = data.Id,
                    ActorId = actorId
                };
                _context.Actors_Movies.Add(newActorMovie);
            }
            _context.SaveChanges();

        }

        

    }
}
