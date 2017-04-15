using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankAccounts.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BankAccounts.Controllers
{
    public class LoginController : Controller
    {
        private MasterContext _context;
 
        public LoginController(MasterContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("login")]
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
        [Route("goToRegister")]
        [ResponseCache(NoStore =true, Location =ResponseCacheLocation.None)]
        public IActionResult goToLogin()
        {
            return RedirectToAction("Index", "Register");
        }

        [HttpPost]
        [Route("loginUser")]
        [ResponseCache(NoStore =true, Location =ResponseCacheLocation.None)]
        public IActionResult loginUser(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                Users currentUser = _context.Users.SingleOrDefault(user => user.Email == model.Email);
                if(currentUser != null && currentUser.Email == model.Email)
                {
                    System.Console.WriteLine("HEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE");
                    PasswordHasher<Users> Hasher = new PasswordHasher<Users>();
                    if(0 != Hasher.VerifyHashedPassword(currentUser, currentUser.Password, model.Password))
                    {
                        HttpContext.Session.SetInt32("CurrUserId", (int)currentUser.id);
                        
                        return RedirectToAction("Index", "Bank");
                    }
                }
                return RedirectToAction("Index", "Bank");
            }
            List<string> errors = ModelState.Select(x => x.Value.Errors)
                           .Where(y=>y.Count>0)
                           .Select(z => z[0].ErrorMessage.ToString())
                           .ToList();
            TempData["error_list"] = errors;
            return RedirectToAction("Index");
        }
    }
}
