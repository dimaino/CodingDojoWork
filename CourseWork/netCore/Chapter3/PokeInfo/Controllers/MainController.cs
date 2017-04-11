using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace YourNamespace.Controllers
{
    public class MainController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpGet]
        [Route("/projects")]
        public IActionResult Project()
        {
            return View("projects");
        }

        [HttpGet]
        [Route("/contacts")]
        public IActionResult Contact()
        {
            return View("contact");
        }
    }
}