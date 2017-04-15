using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BankAccounts.Models;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace BankAccounts.Controllers
{
    public class RegisterController : Controller
    {
        private MasterContext _context;
 
        public RegisterController(MasterContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        [ResponseCache(NoStore =true, Location =ResponseCacheLocation.None)]
        public IActionResult Index()
        {
            if(TempData["error_list"] != null)
            {
                ViewBag.errors = TempData["error_list"];
            }
            return View("Index");
        }

        [HttpGet]
        [Route("goToLogin")]
        [ResponseCache(NoStore =true, Location =ResponseCacheLocation.None)]
        public IActionResult goToLogin()
        {
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        [Route("registerUser")]
        [ResponseCache(NoStore =true, Location =ResponseCacheLocation.None)]
        public IActionResult registerUser(RegisterViewModel model)
        {
            List<string> errors = new List<string>();
            if(ModelState.IsValid)
            {
                List<Users> allUsers = _context.Users.Where(users => users.Email == model.Email).ToList();
                PasswordHasher<Users> Hasher = new PasswordHasher<Users>();
                
                if(allUsers.Count < 1)
                {
                    Users newUser = new Users
                    {
                        First_Name = model.First_Name,
                        Last_Name = model.Last_Name,
                        Email = model.Email,
                        Password = model.Password,
                        created_at = DateTime.Now,
                        updated_at = DateTime.Now
                    };
                    newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
                    _context.Users.Add(newUser);
                    _context.SaveChanges();

                    Users currentUser = _context.Users.SingleOrDefault(user => user.Email == model.Email);
                    HttpContext.Session.SetInt32("CurrUserId", (int)currentUser.id);
                    return RedirectToAction("Index", "Bank");
                }
                errors.Add("Email already exists in the Database.");
            }
            else
            {
                errors = ModelState.Select(x => x.Value.Errors)
                           .Where(y=>y.Count>0)
                           .Select(z => z[0].ErrorMessage.ToString())
                           .ToList();
            }
            TempData["error_list"] = errors;
            return RedirectToAction("Index");
        }
    }
}
