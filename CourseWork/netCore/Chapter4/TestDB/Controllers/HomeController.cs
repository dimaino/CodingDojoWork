using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TestDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbConnector _dbConnector;

        public HomeController(DbConnector connect)
        {
            _dbConnector = connect;
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            List<Dictionary<string, object>> AllUsers = _dbConnector.Query("SELECT * FROM quotes");
            ViewBag.THINGSANDSTUFF = AllUsers;
            return View();
        }
    }
}
