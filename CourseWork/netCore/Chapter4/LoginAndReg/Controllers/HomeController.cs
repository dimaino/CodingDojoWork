using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using LoginAndReg.Models;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace LoginAndReg.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbConnector _dbConnector;

        public HomeController(DbConnector connect)
        {
            _dbConnector = connect;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            List<Dictionary<string, object>> AllUsers = _dbConnector.Query("SELECT * FROM users");
            ViewBag.allUsers = AllUsers;
            if(TempData["error_list"] != null)
            {
                ViewBag.errors = TempData["error_list"];
            }
            if(TempData["NoUser"] != null)
            {
                ViewBag.noUser = TempData["NoUser"];
            }
            HttpContext.Session.Clear();
            return View("Index");
        }

        [HttpPost]
        [Route("loginProcess")]
        public IActionResult LoginProcess(string email, string password)
        {
            List<string> errors = new List<string>();
            if(email != null)
            {
                string getUserByEmail = $"SELECT * FROM users WHERE Email = '{email}'";
                List<Dictionary<string, object>> currentUser = _dbConnector.Query(getUserByEmail);
                string userEmail = null;
                User user = new User();
                if(currentUser.Count > 0)
                {
                    userEmail = (string)currentUser[0]["Email"];
                    user = new User
                    {
                            email = (string)currentUser[0]["Email"],
                            password = (string)currentUser[0]["Password"]
                    };
                }
                if(userEmail != null)
                {
                    PasswordHasher<User> Hasher = new PasswordHasher<User>();
                    if(0 != Hasher.VerifyHashedPassword(user, (string)currentUser[0]["Password"], password))
                    {
                        HttpContext.Session.SetInt32("CurrUserId", (int)currentUser[0]["id"]);
                        return RedirectToAction("Success");
                    }
                    errors.Add("Password was incorrect.");
                }
                if(errors.Count < 1)
                {
                    errors.Add("That email is not in the database.");
                }
            }
            if(errors.Count < 1)
            {
                errors.Add("Email cannot be empty.");
            }
            TempData["error_list"] = errors;
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("registerProcess")]
        public IActionResult RegisterProcess(User newUser)
        {
            if(ModelState.IsValid)
            {
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                newUser.password = Hasher.HashPassword(newUser, newUser.password);
                string queryAddUser = $"INSERT into users (First_Name, Last_Name, Email, Password, Password_Confirmation, created_at, updated_at) VALUES ('{newUser.firstName}', '{newUser.lastName}', '{newUser.email}', '{newUser.password}', '{newUser.passwordConfirmation}', NOW(), NOW())";
                _dbConnector.Execute(queryAddUser);
                string queryGetAddedUser = "SELECT * FROM users ORDER BY id DESC LIMIT 1";
                List<Dictionary<string, object>> currentUser = _dbConnector.Query(queryGetAddedUser);
                HttpContext.Session.SetInt32("CurrUserId", (int)currentUser[0]["id"]);
                return RedirectToAction("Success");
            }
            var errors = ModelState.Select(x => x.Value.Errors)
                           .Where(y=>y.Count>0)
                           .Select(z => z[0].ErrorMessage.ToString())
                           .ToList();
            TempData["error_list"] = errors;
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("success")]
        public IActionResult Success()
        {
            if(HttpContext.Session.GetInt32("CurrUserId") == null)
            {
                TempData["NoUser"] = "Error: Cannot get to this page without logging in!";
                return RedirectToAction("Index");
            }
            string getUserById = $"SELECT * FROM users WHERE id = {(int)HttpContext.Session.GetInt32("CurrUserId")}";
            ViewBag.currentUser = _dbConnector.Query(getUserById);
            return View("Success");
        }

        [HttpPost]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
