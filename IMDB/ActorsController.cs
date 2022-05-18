using IMDB.Data;
using IMDB.Data.services;
using IMDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IMDB.Controllers
{
    public class ActorsController : Controller
    {
        public readonly IActorServices _services;

        public ActorsController(IActorServices service)
        {
            _services = service;
        }

        public IActionResult Index()
        {
            var All_Actors = _services.GetAll();
            return View(All_Actors);
        }

        //create new actor 
        [HttpGet]
        public IActionResult CreateActor()
        {
            return View();
        }

        [HttpPost]

        public IActionResult AddNewActorDataToDb([Bind("profilepicURL,Fname,Lname,age")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }


            _services.AddNew(actor);
            
            return RedirectToAction(nameof(Index));
        }

        //create new actor 


        //get data of one actor 

        public IActionResult GetOneActorData(int ActorID)
        {
            var ActorDetails = _services.GetActorByID(ActorID);

            if (ActorDetails == null) return View("empty");

            return View(ActorDetails);
        }

        //get data of one actor 




        //update actor 
        // we will reuse GetOneActorData to update 

        public IActionResult UpDateOneActorData(int ActorID)
        {
            var ActorDetails = _services.GetByID(ActorID);

            if (ActorDetails == null) return View("empty");

            return View(ActorDetails);
        }


        [HttpPost]

        public IActionResult UpDateActorDataToDb(int ActorID,[Bind("ID,profilepicURL,Fname,Lname,age")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            
            _services.Update(ActorID ,actor);
           
            return RedirectToAction(nameof(Index));
        }
        //update actor 



        //Delete actor 
        

        public IActionResult DeleteActor(int ActorID)
        {
            var ActorDetails = _services.GetByID(ActorID);

            if (ActorDetails == null) return View("empty");

            return View(ActorDetails);
        }


        [HttpPost]

        public IActionResult DeleteConfirmed(int ActorID, [Bind("ID,profilepicURL,Fname,Lname,age")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }

            _services.Delete(ActorID, actor);

            return RedirectToAction(nameof(Index));
        }
        //Delete actor 


        
    }

}
