using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace YourNamespace.Controllers
{
    public class HelloController : Controller
    {
        // A GET method
        [HttpGet]
        [Route("index")]
        public string Index()
        {
            return "Hello World!";
        }

        [HttpGet]
        [Route("")]
        public JsonResult Example()
        {
            var AnonObject = new {
                         FirstName = "Raz",
                         LastName = "Aquato",
                         Age = 10
                     };
            return Json(AnonObject);
            // The Json method convert the object passed to it into JSON
            //return Json(34);
        }

        

        // Suppose we're working with the Human class we wrote in the previous chapter
        // [HttpGet]
        // [Route("displayhuman")]
        // public JsonResult DisplayHuman()
        // {
        //     return Json(new Human());
        // }


        
        // A POST method
        // [HttpPost]
        // [Route("")]
        // public IActionResult Other()
        // {
        //     // Return a view (We'll learn how soon!)
        // }

        // // Other code
        // [HttpGet]
        // [Route("template/{Name}")]
        // public IActionResult Method(string Name)
        // {
        //     // Method body
        // }
    }
}