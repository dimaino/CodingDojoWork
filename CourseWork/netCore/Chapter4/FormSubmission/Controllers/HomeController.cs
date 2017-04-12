using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FormSubmission.Models;
using System.Linq;

namespace FormSubmission.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            if(TempData["WOOT"] != null)
            {
                ViewBag.errors = TempData["WOOT"];
            }
            
            return View();
        }

        [HttpPost]
        [Route("formSubmission")]
        public IActionResult formSub(string firstName, string lastName, int age, string email, string password)
        {
            User newUser = new User
            {
                firstName = firstName,
                lastName = lastName,
                age = age,
                email = email,
                password = password
            };
            TryValidateModel(newUser);
            List<string> str1 = new List<string>();
            foreach(var i in  ModelState.Values)
            {
                if(i.Errors.Count > 0)
                {
                    str1.Add(i.Errors[0].ErrorMessage.ToString());
                }
            }
            if(str1.Count < 1)
            {
                return View("success");
            }
            TempData["WOOT"] = str1;
            return RedirectToAction("Index");
        }

    }
}
