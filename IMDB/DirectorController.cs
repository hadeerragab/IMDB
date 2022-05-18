using IMDB.Data;
using IMDB.Data.services;
using IMDB.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IMDB.Controllers
{
    public class DirectorController : Controller
    {
        public readonly IDirectorServices _services;

        public DirectorController(IDirectorServices service)
        {
            _services = service;
        }

        public IActionResult Index()
        {
            var AllDirectors = _services.GetAll();
            return View(AllDirectors);
        }



        //create new Director 
        [HttpGet]
        public IActionResult CreateDirector()
        {
            return View();
        }

        [HttpPost]

        public IActionResult AddNewDirectorDataToDb([Bind("profilepicURL,Fname,Lname,age")] Director Director)
        {
            if (!ModelState.IsValid)
            {
                return View(Director);
            }


            _services.AddNew(Director);
            //_services.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //create new actor 


        //get data of one actor 

        public IActionResult GetOneDirectorData(int DirectorID)
        {
            var DirectorDetails = _services.GetByID(DirectorID);

            if (DirectorDetails == null) return View("empty");

            return View(DirectorDetails);
        }

        //get data of one actor 



        //update actor 
        // we will reuse GetOneActorData to update 

        public IActionResult UpDateDirectorData(int DirectorID)
        {
            var DirectorDetails = _services.GetByID(DirectorID);

            if (DirectorDetails == null) return View("empty");

            return View(DirectorDetails);
        }


        [HttpPost]

        public IActionResult UpDateDirectorDataToDb(int DirectorID, [Bind("ID,profilepicURL,Fname,Lname,age")] Director Director)
        {
            if (!ModelState.IsValid)
            {
                return View(Director);
            }

            _services.Update(DirectorID, Director);

            return RedirectToAction(nameof(Index));
        }
        //update actor 


        //Delete actor 


        public IActionResult DeleteDirector(int DirectorID)
        {
            var DirectorDetails = _services.GetByID(DirectorID);

            if (DirectorDetails == null) return View("empty");

            return View(DirectorDetails);
        }


        [HttpPost]

        public IActionResult DeleteConfirmed(int DirectorID, [Bind("ID,profilepicURL,Fname,Lname,age")] Director Director)
        {
            if (!ModelState.IsValid)
            {
                return View(Director);
            }

            _services.Delete(DirectorID, Director);

            return RedirectToAction(nameof(Index));
        }
        //Delete actor 
    }
}
