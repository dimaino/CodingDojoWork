using System;
using System.Collections.Generic;
using lostInTheWoods.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using lostInTheWoods.Factory; //Need to include reference to new Factory Namespace
namespace lostInTheWoods.Controllers
{
    public class HomeController : Controller
    {
        // private readonly TrailFactory trailFactory;
        // public HomeController(TrailFactory tf)
        // {
        //     //Instantiate a UserFactory object that is immutable (READONLY)
        //     //This establishes the initial DB connection for us.
        //     trailFactory = tf;
        // }

        // GET: /Home/
        private readonly TrailFactory trailFactory;
        public HomeController(TrailFactory traiLFactory)
        {
            //Instantiate a UserFactory object that is immutable (READONLY)
            //This establishes the initial DB connection for us.
            trailFactory = traiLFactory;
        }
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            //We can call upon the methods of the userFactory directly now.
            if(TempData["sort1"] != null)
            {
                ViewBag.trails = trailFactory.SortByLength();
            }
            else if(TempData["sort2"] != null)
            {
                ViewBag.trails = trailFactory.SortByElevationChange();
            }
            else
            {
                ViewBag.trails = trailFactory.FindAll();
            }
            
            return View();
        }

        [HttpGet]
        [Route("someNewTrail")]
        public IActionResult aNewTrail()
        {
            if(TempData["error_list"] != null)
            {
                ViewBag.errors = TempData["error_list"];
            }
            return View("newTrail");
        }

        [HttpPost]
        [Route("createNew")]
        public IActionResult addTrail(Trail trail)
        {
            if(ModelState.IsValid)
            {
                trailFactory.Add(trail);
            }
            var errors = ModelState.Select(x => x.Value.Errors)
                           .Where(y=>y.Count>0)
                           .Select(z => z[0].ErrorMessage.ToString())
                           .ToList();
            TempData["error_list"] = errors;
            return RedirectToAction("aNewTrail");
        }

        [HttpGet]
        [Route("trails/{id}")]
        public IActionResult seeTrail(int id)
        {
            ViewBag.currentTrail = trailFactory.FindByID(id);
            return View("trails");
        }

        [HttpGet]
        [Route("goHome")]
        public IActionResult GoHome()
        {
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("orderLength")]
        public IActionResult OrderLength()
        {
            TempData["sort1"] = true;
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("orderElevation")]
        public IActionResult OrderElevation()
        {
            TempData["sort2"] = true;
            return RedirectToAction("Index");
        }

    }
}