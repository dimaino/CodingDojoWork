using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserDashboard.Models;
using System.Collections.Generic;
using System.Linq;

namespace UserDashboard.Controllers
{
    public class NewController : Controller
    {
        private static MasterContext _context;
    
        public NewController(MasterContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("dashboard")]
        public IActionResult Index()
        {
            if(HttpContext.Session.GetInt32("CurrUserId") != null)
            {
                User CurrentUser = _context.User.SingleOrDefault(person => person.id == (int)HttpContext.Session.GetInt32("CurrUserId"));
                ViewBag.CurrentUser = CurrentUser;
                ViewBag.allUsers = _context.User.ToList();          
                return View("Index");
            }
            TempData["error_list"] = new List<string>() {"You need to login to get to this Page."};
            return RedirectToAction("Index", "LoginRegistration");
        }

        [HttpGet]
        [Route("newUser")]
        public IActionResult NewUser()
        {
            if(HttpContext.Session.GetInt32("CurrUserId") != null)
            {
                return View("NewUser");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("addUser")]
        public IActionResult AddUser(RegistrationViewModel model, User newUser)// read in a model plus a user do all validations
        {
            
            return RedirectToAction("NewUser");
        }

        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "LoginRegistration");
        }
    }
}