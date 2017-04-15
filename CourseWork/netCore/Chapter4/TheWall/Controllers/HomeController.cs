using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TheWall.Models;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace TheWall.Controllers
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
                string getUserByEmail = $"SELECT * FROM users WHERE email = '{email}'";
                List<Dictionary<string, object>> currentUser = _dbConnector.Query(getUserByEmail);
                string userEmail = null;
                User user = new User();
                if(currentUser.Count > 0)
                {
                    userEmail = (string)currentUser[0]["email"];
                    user = new User
                    {
                            email = (string)currentUser[0]["email"],
                            password = (string)currentUser[0]["password"]
                    };
                }
                if(userEmail != null)
                {
                    if(password == null)
                    {
                        errors.Add("Password cannot be empty.");
                    }
                    else
                    {
                        PasswordHasher<User> Hasher = new PasswordHasher<User>();
                        if(0 != Hasher.VerifyHashedPassword(user, (string)currentUser[0]["password"], password))
                        {
                            HttpContext.Session.SetInt32("CurrUserId", (int)currentUser[0]["id"]);
                            return RedirectToAction("Wall");
                        }
                        errors.Add("Password was incorrect.");
                    }
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
                string queryAddUser = $"INSERT into users (first_name, last_name, email, password, created_at, updated_at) VALUES ('{newUser.firstName}', '{newUser.lastName}', '{newUser.email}', '{newUser.password}', NOW(), NOW())";
                _dbConnector.Execute(queryAddUser);
                string queryGetAddedUser = "SELECT * FROM users ORDER BY id DESC LIMIT 1";
                List<Dictionary<string, object>> currentUser = _dbConnector.Query(queryGetAddedUser);
                HttpContext.Session.SetInt32("CurrUserId", (int)currentUser[0]["id"]);
                return RedirectToAction("Wall");
            }
            var errors = ModelState.Select(x => x.Value.Errors)
                           .Where(y=>y.Count>0)
                           .Select(z => z[0].ErrorMessage.ToString())
                           .ToList();
            TempData["error_list"] = errors;
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("wall")]
        public IActionResult Wall()
        {
            if(HttpContext.Session.GetInt32("CurrUserId") == null)
            {
                TempData["NoUser"] = "Error: Cannot get to this page without logging in!";
                return RedirectToAction("Index");
            }
            string getUserById = $"SELECT * FROM users WHERE id = {(int)HttpContext.Session.GetInt32("CurrUserId")}";
            ViewBag.currentUser = _dbConnector.Query(getUserById);
            string getAllMessages = $"select * from messages";
            ViewBag.allMessages = _dbConnector.Query(getAllMessages);
            string getAllComments = $"select * from comments";
            ViewBag.allComments = _dbConnector.Query(getAllComments);
            return View("Wall");
        }

        [HttpPost]
        [Route("addMessage")]
        public IActionResult AddMessage(string message)
        {
            string addMessageFromUser = $"INSERT INTO messages (user_id, messages, created_at, updated_at) VALUES ({(int)HttpContext.Session.GetInt32("CurrUserId")}, '{message}', Now(), Now())";
            _dbConnector.Execute(addMessageFromUser);
            return RedirectToAction("Wall");
        }

        [HttpPost]
        [Route("addComment/{id}")]
        public IActionResult AddComment(int id, string comment)
        {
            string addCommentFromUser = $"INSERT INTO comments (message_id, user_id, comment, created_at, updated_at) VALUES ({id}, {(int)HttpContext.Session.GetInt32("CurrUserId")}, '{comment}', Now(), Now())";
            //System.Console.WriteLine(addCommentFromUser);
            _dbConnector.Execute(addCommentFromUser);
            //HttpContext.Session.SetInt32("CurrMessageId", (int)addCommentFromUser[0]["id"]);
            return RedirectToAction("Wall");
        }

        [HttpPost]
        [Route("deleteMessage/{id}")]
        public IActionResult DeleteMessage(int id)
        {
            string DeleteComments = $"delete from comments where message_id = {id}";
            _dbConnector.Execute(DeleteComments);
            string DeleteMessages = $"delete from messages where messages.id = {id}";
            _dbConnector.Execute(DeleteMessages);
            return RedirectToAction("Wall");
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
