using System.Linq;
using WeddingPlanner.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Controllers
{
    public class WeddingController : Controller {
        private WeddingPlannerContext _context;
    
        public WeddingController(WeddingPlannerContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("dashboard")]
        public IActionResult Index()
        {
            if(HttpContext.Session.GetInt32("CurrUserId") != null)
            {
                User CurrentUser = _context.Users.SingleOrDefault(person => person.id == (int)HttpContext.Session.GetInt32("CurrUserId"));
                ViewBag.User = CurrentUser;            
                List<Wedding> AllWeddings = _context.Weddings.Include(guests => guests.Guests).ThenInclude(guests => guests.User).OrderBy(wedding => wedding.Wedding_Date).ToList();
                ViewBag.AllWeddings = AllWeddings;     
                return View("Dashboard");
            }
            TempData["error_list"] = new List<string>() {"You need to login to get to this Page."};
            return RedirectToAction("Index", "LoginReg");
        }

        [HttpGet]
        [Route("wedding/{id}")]
        public IActionResult WeddingId(int id)
        {
        Wedding CurrentWedding = _context.Weddings.Where(WeddingId => WeddingId.id == id).Include(guests => guests.Guests).ThenInclude(guest => guest.User).SingleOrDefault();
        ViewBag.CurrentWedding = CurrentWedding;
            return View("Wedding");
        }


        [HttpGet]
        [Route("new-wedding")]
        public IActionResult NewWedding()
        {
            if(TempData["Errors"] != null)
            {
                ViewBag.Errors = TempData["Errors"];
            }
            return View("NewWedding");
        }

        [HttpPost]
        [Route("add-wedding")]
        [ValidateAntiForgeryToken]
        public IActionResult AddWedding(WeddingViewModel model)
        {
            List<string> allErrors = new List <string>();
            User CurrentUser = _context.Users.SingleOrDefault(person => person.id == (int)HttpContext.Session.GetInt32("CurrUserId"));
            if (ModelState.IsValid)
            {
                Wedding newWedding = new Wedding
                {
                    Wedder1_Name = model.Wedder1_Name,
                    Wedder2_Name = model.Wedder2_Name,
                    Wedding_Date = (DateTime)model.Wedding_Date,
                    Wedding_Address = model.Wedding_Address,
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now,
                    user_id = CurrentUser.id
                };
                _context.Add(newWedding);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            List<string> errors = ModelState.Select(x => x.Value.Errors)
                           .Where(y=>y.Count>0)
                           .Select(z => z[0].ErrorMessage.ToString())
                           .ToList();
            foreach(var i in errors)
            {
                System.Console.WriteLine(i);
            }
            TempData["Errors"] = errors;
            return RedirectToAction("NewWedding");
        }

        [HttpGet]
        [Route("rsvp/{id}")]
        public IActionResult RSVP(int id) 
        {
            int CurrentUser = (int)HttpContext.Session.GetInt32("CurrUserId");
            Guest AddRSVP = new Guest
            {
                wedding_id = id,
                user_id = CurrentUser
            };
            _context.Add(AddRSVP);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }    

        [HttpGet]
        [Route("unrsvp/{id}")]
        public IActionResult unRSVP(int id)
        {
            int CurrentUser = (int)HttpContext.Session.GetInt32("CurrUserId");
            Guest UnRsvp = _context.Guests.Where(user => user.user_id == CurrentUser).Where(wedding => wedding.wedding_id == id).SingleOrDefault();
            _context.Remove(UnRsvp);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }    

        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            List<Guest> RemoveGuests = _context.Guests.Where(wedding => wedding.wedding_id == id).ToList();
            foreach (var Rsvp in RemoveGuests)
            {
                _context.Remove(Rsvp);
            }
            _context.SaveChanges();
            int CurrentUser = (int)HttpContext.Session.GetInt32("CurrUserId");
            Wedding RemoveWedding = _context.Weddings.Where(user => user.user_id == CurrentUser).Where(wedding => wedding.id == id).SingleOrDefault();
            _context.Remove(RemoveWedding);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }    

        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "LoginReg");        
        }
    }
}
