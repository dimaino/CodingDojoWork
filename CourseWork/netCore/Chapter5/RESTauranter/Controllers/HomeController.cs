using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RESTauranter.Models;
using System.Linq;

namespace RESTauranter.Controllers
{
    public class HomeController : Controller
    {
        private RestContext _context;
 
        public HomeController(RestContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            if(TempData["error_list"] != null)
            {
                ViewBag.errors = TempData["error_list"];
            }
            return View("Index");
        }

        [HttpGet]
        [Route("reviews")]
        public IActionResult showReviews()
        {
            List<Reviews> AllReviews = _context.Reviews.OrderByDescending(aReview => aReview.created_at).ToList();
            ViewBag.allReviews = AllReviews;
            return View("Reviews");
        }

        [HttpPost]
        [Route("addReviews")]
        public IActionResult addReviews(ReviewViewModel model)
        {
            List<string> errors = new List<string>();
            if(DateTime.Now >= model.Date_Visited && ModelState.IsValid)
            {
                Reviews newReview = new Reviews
                {
                    Reviewer_Name = model.Reviewer_Name,
                    Restaurant_Name = model.Restaurant_Name,
                    Review = model.Review,
                    Date_Visited = model.Date_Visited,
                    Stars = model.Stars,
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now
                };
                _context.Reviews.Add(newReview);
                _context.SaveChanges();
                return RedirectToAction("showReviews");
            }
            else
            {
                errors = ModelState.Select(x => x.Value.Errors)
                           .Where(y=>y.Count>0)
                           .Select(z => z[0].ErrorMessage.ToString())
                           .ToList();
            }
            if(DateTime.Now <= model.Date_Visited)
            {
                errors.Add("Cannot be in the future!");
            }

            TempData["error_list"] = errors;
            return RedirectToAction("Index");
        }
    }
}
