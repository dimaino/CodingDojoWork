using System;
using System.Collections.Generic;
using System.Linq;
using WeddingPlanner.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WeddingPlanner.Controllers
{
    public class LoginRegController : Controller {
        public static WeddingPlannerContext _context;
    
        public LoginRegController(WeddingPlannerContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.Errors = TempData["error_list"];
            HttpContext.Session.Clear();
            return View("LoginReg");
        }

        [HttpPost]
        [Route("loginOrregister")]
        [ValidateAntiForgeryToken]
        public IActionResult LoginRegister(CombinedLoginAndRegViewModel model)
        {
            if(model.Login != null)
            {
                Login(model.Login);
            }
            else if(model.Register != null)
            {
                Register(model.Register);
            }
            ViewBag.thing = TempData["error_list"];
            int count = 0;
            foreach(var i in ViewBag.thing)
            {
                count++;
            }
            if(count == 0)
            {
                return RedirectToAction("Index", "Wedding");
            }
            return RedirectToAction("Index");
        }

        public void Register(RegisterViewModel model)
        {
            List<string> errors = new List<string>();
            if(ModelState.IsValid)
            {
                List<User> allUsers = _context.Users.Where(users => users.Email == model.Email).ToList();
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                
                if(allUsers.Count < 1)
                {
                    User newUser = new User
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

                    User currentUser = _context.Users.SingleOrDefault(user => user.Email == model.Email);
                    HttpContext.Session.SetInt32("CurrUserId", (int)currentUser.id);
                }
                else
                {
                    errors.Add("Email already exists in the Database.");
                }
            }
            else
            {
                errors = ModelState.Select(x => x.Value.Errors)
                           .Where(y=>y.Count>0)
                           .Select(z => z[0].ErrorMessage.ToString())
                           .ToList();
            }
            TempData["error_list"] = errors;
        }

        public void Login(LoginViewModel model)
        {
            bool userCheck = true;
            bool passwordCheck = true;
            if(ModelState.IsValid)
            {
                User currentUser = _context.Users.SingleOrDefault(user => user.Email == model.Email);
                if(currentUser != null && currentUser.Email.Equals(model.Email))
                {
                    PasswordHasher<User> Hasher = new PasswordHasher<User>();
                    if(0 != Hasher.VerifyHashedPassword(currentUser, currentUser.Password, model.Password))
                    {
                        HttpContext.Session.SetInt32("CurrUserId", (int)currentUser.id);

                    }
                    else
                    {
                        passwordCheck = false;
                    }
                }
                else
                {
                    userCheck = false;
                }
            }
            List<string> errors = ModelState.Select(x => x.Value.Errors)
                           .Where(y=>y.Count>0)
                           .Select(z => z[0].ErrorMessage.ToString())
                           .ToList();
            if(userCheck == false)
            {
                errors.Add("User doesn't exist is the Database.");
            }
            if(passwordCheck == false)
            {
                errors.Add("Password was incorrect.");
            }
            TempData["error_list"] = errors;
        }
    }
}
