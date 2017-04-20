using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Http;
using WeddingPlanning.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WeddingPlanning.Controllers
{
    public class WeddingController : Controller
    {
        private MasterContext _context;
 
        public WeddingController(MasterContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("weddings")]
        [ResponseCache(NoStore =true, Location =ResponseCacheLocation.None)]
        public IActionResult Index()
        {
            if(HttpContext.Session.GetInt32("CurrUserId") != null)
            {
                List<Wedding> allWedding = _context.Wedding.ToList();
                User currentUser = _context.User.SingleOrDefault(user => user.id == (int)HttpContext.Session.GetInt32("CurrUserId"));
                List<Guest> allGuest = _context.Guest.ToList();
                ViewBag.AllWeddings = allWedding;
                ViewBag.loggedInUser = currentUser;
                ViewBag.AllGuests = allGuest;

                // Go Through all weddings and find if should DELETE, RSVP or UNRSVP
                // if yours DELETE if user RSVP'd (user_id = current user && user_id == wedding_id)

                return View("Index");
            }
            else
            {
                TempData["error_list"] = new List<string>() {"Can not get to the page without logging in!"};
                return RedirectToAction("Index", "LoginReg");
            }
        }

        [HttpGet]
        [Route("weddingPage")]
        public IActionResult WeddingPage()
        {
            List<string> allUsers = _context.User.Where(name => name.id != (int)HttpContext.Session.GetInt32("CurrUserId")).Select(name => name.First_Name).ToList();
            //List<int> allUsersInt = _context.User.Where(name => name.id != (int)HttpContext.Session.GetInt32("CurrUserId")).Select(name => name.id).ToList();
            List<string> currentUser = _context.User.Where(name => name.id == (int)HttpContext.Session.GetInt32("CurrUserId")).Select(name => name.First_Name).ToList();
            
            //List<Wedding> allWedding = _context.Wedding.Except(w => w.user_id == ).ToList();

            ViewBag.allUsers = new SelectList(allUsers);
            
            
            ViewBag.loggedInUser = new SelectList(currentUser);

            if(TempData["error_list"] != null)
            {
                ViewBag.errors = TempData["error_list"];
            }
            return View("newWedding");
        }

        [HttpPost]
        [Route("createWedding")]
        public IActionResult CreateWedding(WeddingViewModel model)
        {
            if(ModelState.IsValid)
            {  
                Wedding newWedding = new Wedding
                {
                    Groom_Name = model.Groom_Name,
                    Bride_Name = model.Bride_Name,
                    Wedding_Date = model.Wedding_Date,
                    user_id = (int)HttpContext.Session.GetInt32("CurrUserId"),
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now
                };
                _context.Wedding.Add(newWedding);
                _context.SaveChanges();
                return RedirectToAction("weddingPage");
            }
            List<string> errors = ModelState.Select(x => x.Value.Errors)
                           .Where(y=>y.Count>0)
                           .Select(z => z[0].ErrorMessage.ToString())
                           .ToList();
            TempData["error_list"] = errors;
            return RedirectToAction("weddingPage");
        }

        [HttpGet]
        [Route("showCurrentWedding/{id}")]
        public IActionResult ShowCurrentWedding(int id)
        {
            Wedding currentWedding = _context.Wedding.SingleOrDefault(wed => wed.id == id);
            ViewBag.currWedding = currentWedding;
            List<Wedding> wedding = _context.Wedding.Include(w => w.WeddingGuest).ThenInclude(g => g.Wedding).Where(wed => wed.id == id).ToList();
            ViewBag.weddingGuests = wedding;
            return View("showWedding");
        }

        [HttpPost]
        [Route("rsvp/{id}")]
        public IActionResult tryRSVP(int id)
        {
            List<Guest> thing1 = _context.Guest.Where(g => (g.user_id == (int)HttpContext.Session.GetInt32("CurrUserId")) && (g.wedding_id == id)).ToList();
            if(thing1.Count < 1)
            {
                User currentUser = _context.User.SingleOrDefault(user => user.id == (int)HttpContext.Session.GetInt32("CurrUserId"));
                Wedding currentWedding = _context.Wedding.SingleOrDefault(wed => wed.id == id);
                Guest newGuest = new Guest
                {
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now
                };
                currentUser.UserGuest.Add(newGuest);
                currentWedding.WeddingGuest.Add(newGuest);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("deleteWedding/{id}")]
        public IActionResult DeleteWedding(int id)
        {
            Wedding currentWedding = _context.Wedding.SingleOrDefault(wed => wed.id == id);
            _context.Wedding.Remove(currentWedding);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("logout")]
        [ResponseCache(NoStore =true, Location =ResponseCacheLocation.None)]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "LoginReg");
        }
    }
}