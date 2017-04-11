using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace YourNamespace.Controllers
{
    public class MainController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.Errors = new List<string>();
            return View("index");
        }


        [HttpPost]
        [Route("sumbitContactForm")]
        public IActionResult SumbitContactForm(string myName, string myLocation, string myLanguage, string myComment)
        {
            ViewBag.Errors = new List<string>();
            if(myName == null)
            {
                ViewBag.Errors.Add("No Name");
            }
            if(myLocation == null)
            {
                ViewBag.Errors.Add("No Location");
            }
            if(myLanguage == null)
            {
                ViewBag.Errors.Add("No Language");
            }
            if(myComment == null)
            {
                ViewBag.myComment = "";
            }
            if(ViewBag.Errors.Count > 0)
            {
                return View("index");
            }
            ViewBag.myName = myName;
            ViewBag.myLocation = myLocation;
            ViewBag.myLanguage = myLanguage;
            ViewBag.myComment = myComment;
            return View("contact");
        }

        [HttpGet]
        [Route("thing")]

        public IActionResult backToIndex()
        {
            
            return RedirectToAction("Index");
        }

    }
}