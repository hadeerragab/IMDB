using IMDB.Data;
using IMDB.Data.services;
using IMDB.Data.ViewModels;
using IMDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IMDB.Controllers
{
    public class MoviesController : Controller
    {
       

        public readonly IMoviesServices _services;

        public MoviesController(IMoviesServices service)
        {
            _services = service;
        }

        public IActionResult Index()
        {
            var All_Movies = _services.GetAll(n=> n.Director);
            return View(All_Movies);
        } 
        
        public IActionResult Filter(string searchString)
        {
            var All_Movies = _services.GetAll(n=> n.Director);

            if (!string.IsNullOrEmpty(searchString))
            {
                //var filteredResult = allMovies.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();

                var filteredResultNew = All_Movies.Where(n => string.Equals(n.name, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return View("Index", filteredResultNew);
            }

            return View("Index", All_Movies);
        }

        

        //get data of one Movie 

        public IActionResult GetOneMovieData(int MovieID)
        {
            var MovieDetails = _services.GetMovieByID(MovieID);

            if (MovieDetails == null) return View("empty");

            return View(MovieDetails);
        }

        //get data of one Movie 




        //Get : create movie

        public IActionResult CreateMovie()
        {
            var movieDropdownsData =  _services.GetNewMovieDropdownsValues();

            ViewBag.Director = new SelectList(movieDropdownsData.Directors, "ID", "Fname");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "ID", "Fname");

            return View();
            
        }

        //public IActionResult AddNewMovieDataToDb()
        //{
        //    return View();
        //}

        [HttpPost]
        public IActionResult AddNewMovieDataToDb(NewMovieVM movie)
        {
            if (!ModelState.IsValid)
            {
               

                var movieDropdownsData = _services.GetNewMovieDropdownsValues();

                ViewBag.Director = new SelectList(movieDropdownsData.Directors, "ID", "Fname");
                ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "ID", "Fname");

                return View(movie);
            }

            _services.AddNewMovie(movie);
            return RedirectToAction(nameof(Index));
        }


        //Get : create movie



        //Get : Update movie

        public IActionResult UpDateMovie(int MovieID)
        {
            var movieDetails =  _services.GetMovieByID(MovieID);
            if (movieDetails == null) return View("NotFound");

            var response = new NewMovieVM();


            response.Id = movieDetails.ID;
            response.Name = movieDetails.name;
            response.ImageURL = movieDetails.imageURL;
            response.DirectorId = movieDetails.dirictorID;
            response.ActorIds = movieDetails.Actors_Movies.Select(n => n.ActorId).ToList();
            

            var movieDropdownsData = _services.GetNewMovieDropdownsValues();

            ViewBag.Director = new SelectList(movieDropdownsData.Directors, "ID", "Fname");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "ID", "Fname");

            return View(response);

        }


        [HttpPost]
        public IActionResult UpDateMovieToDb(int MovieID,  NewMovieVM movie)
        {
            //if (MovieID != movie.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {


                var movieDropdownsData = _services.GetNewMovieDropdownsValues();

                ViewBag.Director = new SelectList(movieDropdownsData.Directors, "ID", "Fname");
                ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "ID", "Fname");

                return View(movie);
            }

            _services.UpDateMovie(movie);
            return RedirectToAction(nameof(Index));
        }

        //public IActionResult UpDateMovieToDb()
        //{
        //    return View();
        //}


    }
}
