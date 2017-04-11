using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DbConnection;

namespace Quoting_Dojo.Controllers
{
    public class HomeController : Controller
    {
        
        // Other code
        [HttpGet]
        [Route("")]
        public IActionResult Index(List<string> errors)
        {
            ViewBag.ErrorList = errors;
            return View("index");
        }

        [HttpGet]
        [Route("quotes")]
        public IActionResult skipToQuote()
        {
            List<Dictionary<string, object>> AllQuotes = DbConnector.Query("SELECT * FROM quotes");
            List<User> u = new List<User>();
            foreach(var i in AllQuotes)
            {
                System.Console.WriteLine(i["quote"]);
                u.Add(new User((int)i["id"], (string)i["user"], (string)i["quote"], (DateTime)i["created_at"], (DateTime)i["updated_at"]));
            }
            ViewBag.users = u;
            return View("quotePage");
        }

        [HttpPost]
        [Route("quotes")]
        public IActionResult addQuote(string name, string quote)
        {
            List<string> errors = new List<string>();
            if(name == null)
            {
                errors.Add("ADD A DAMN NAME, BISH\n");
            }
            if(quote == null)
            {
                errors.Add("ADD A DAMN QUOTE, BISH\n");
            }
            if(errors.Count > 0)
            {
                return RedirectToAction("Index", new {errors});
            }
            string str = $"INSERT INTO quotes (user, quote, created_at, updated_at) VALUES ('{name}', '{quote}', Now(), Now())";
            System.Console.WriteLine(str);
            DbConnector.Execute(str);
            List<Dictionary<string, object>> AllQuotes = DbConnector.Query("SELECT * FROM quotes");
            List<User> u = new List<User>();
            foreach(var i in AllQuotes)
            {
                System.Console.WriteLine(i["quote"]);
                u.Add(new User((int)i["id"], (string)i["user"], (string)i["quote"], (DateTime)i["created_at"], (DateTime)i["updated_at"]));
            }
            ViewBag.users = u;
            

            return View("quotePage");
        }
    }
}
