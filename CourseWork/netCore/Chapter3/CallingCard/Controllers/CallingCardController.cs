using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace ConsoleApplication.Controllers
{
    public class CallingCardController : Controller
    {
        // [HttpGet]
        // [Route("")]
        // public string Index()
        // {
        //     return "ASDASD";
        // }
        // [HttpGet]
        // [Route("card/{FirstName}/{LastName}/{Age}/{FavColor}")]
        // public JsonResult CallingCard(string FirstName, string LastName, int Age, string FavColor)
        // {
        //     var AnonObject = new {
        //         FirstName = "Daniel",
        //         LastName = "Imaino",
        //         Age = 24,
        //         FavColor = "Red"
        //     };
        //     return Json(AnonObject);
        // }

        [HttpGet]
        [Route("card/{FirstName}/{LastName}/{Age}/{FavColor}")]
        public JsonResult CallCard(string FirstName, string LastName, int Age, string FavColor)
        {
            return Json(new {FirstName = FirstName, LastName = LastName, Age = Age, FavoriteColor = FavColor});
        }
    }
}