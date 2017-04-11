using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ConsoleApplication.Controllers
{
    public class MainController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            // Create Dojodachi!!!
            if(HttpContext.Session.GetObjectFromJson<Dojoachi>("achi") == null)
            {
                HttpContext.Session.SetObjectAsJson("achi", new Dojoachi());
            }

            ViewBag.achi = HttpContext.Session.GetObjectFromJson<Dojoachi>("achi");
            ViewBag.ratingTheOwner = "Your new achi is here ;)";
            ViewBag.theLoop = "notLosing";
            ViewBag.theFeelsOfAchi = "";
            return View("index");
        }

        // [HttpPost]
        // [Route("actions")]
        // public IActionResult PerformAction(string action)
        // {
        //     Dojoachi danielAchiLOL = HttpContext.Session.GetObjectFromJson<Dojoachi>("achi");
        //     Random RandObject = new Random();
        //     ViewBag.theLoop = "notLosing";
        //     switch(action)
        //     {
        //         case "Feed":
        //             if(danielAchiLOL.meals > 0){
        //                 danielAchiLOL.meals -= 1;
        //                 if(RandObject.Next(0, 4) > 0)
        //                 {
        //                     danielAchiLOL.fullness += RandObject.Next(5, 11);
        //                     ViewBag.theFeelsOfAchi = "/images/HappyDog.gif";
        //                     //ViewBag.theFeelsOfAchi = Url.Content("~images/HappyDog.gif");
        //                     //ViewBag.theFeelsOfAchi = ":)";
        //                     ViewBag.ratingTheOwner = "Liked the meal!";
        //                 }
        //                 else
        //                 {
        //                     ViewBag.theFeelsOfAchi = "/images/SickDog.jpg";
        //                     //ViewBag.theFeelsOfAchi = Url.Content("~images/SickDog.jpg");
        //                     //ViewBag.theFeelsOfAchi = ":(";
        //                     ViewBag.ratingTheOwner = "Didn't like the meal!";
        //                 }
        //             }
        //             else
        //             {
        //                 ViewBag.theFeelsOfAchi = ":(";
        //                 ViewBag.ratingTheOwner = "No food, go to the store!";
        //             }
        //             break;
        //         case "Play":
        //             if(danielAchiLOL.energy > 4)
        //             {
        //                 danielAchiLOL.energy -= 5;
        //                 if(RandObject.Next(0, 4) > 0)
        //                 {
        //                     danielAchiLOL.happiness += RandObject.Next(5, 11);
        //                     ViewBag.theFeelsOfAchi = ":)";
        //                     ViewBag.ratingTheOwner = "Your achi happiness went up!";
        //                 }
        //                 else
        //                 {
        //                     ViewBag.theFeelsOfAchi = ":(";
        //                     ViewBag.ratingTheOwner = "Achi didn't have fun!";
        //                 }
        //             }
        //             else
        //             {
        //                 ViewBag.theFeelsOfAchi = ":(";
        //                 ViewBag.ratingTheOwner = "Achi needs sleep, you son of a gun!";
        //             }

        //             break;
        //         case "Work":
        //             if(danielAchiLOL.energy > 4)
        //             {
        //                 danielAchiLOL.energy -= 5;
        //                 danielAchiLOL.meals += RandObject.Next(1, 4);
        //                 ViewBag.theFeelsOfAchi = ":)";
        //                 ViewBag.ratingTheOwner = "Achi has more food because you are the provider of the achi, because achi can't work duh!";
        //             }
        //             else
        //             {
        //                 ViewBag.theFeelsOfAchi = ":(";
        //                 ViewBag.ratingTheOwner = "Achi needs sleep, you son of a gun!";
        //             }
        //             break;
        //         case "Sleep":
        //             danielAchiLOL.energy += 15;
        //             danielAchiLOL.fullness -= 5;
        //             danielAchiLOL.happiness -= 5;
        //             ViewBag.theFeelsOfAchi = ":)";
        //             ViewBag.ratingTheOwner = "Achi slept well!";
        //             break;
        //         default:
        //             ViewBag.theFeelsOfAchi = "Winner winner chicken dinner!";
        //             ViewBag.ratingTheOwner = "Yup wasn't expecting this ;D";
        //             break;

        //     }
        //     if(danielAchiLOL.fullness < 1 || danielAchiLOL.happiness < 1)
        //     {
        //         ViewBag.theFeelsOfAchi = "Achi died you are a terrible owner! X~[";
        //         ViewBag.ratingTheOwner = "Don't get another animal!";
        //         ViewBag.theLoop = "Losing";
        //     }
        //     else if(danielAchiLOL.fullness > 99 && danielAchiLOL.happiness > 99)
        //     {
        //         ViewBag.theFeelsOfAchi = "XDDDDDDDDDDDDDDDDDD XXXXXXXXXDDDDDDDDDDDDDDDDDDDDD";
        //         ViewBag.ratingTheOwner = "Congrads you can take care of a dog";
        //         ViewBag.theLoop = "Losing";
        //     }
        //     HttpContext.Session.SetObjectAsJson("achi", danielAchiLOL);
        //     ViewBag.achi = danielAchiLOL;
        //     return View("index");
        // }


        // [HttpGet]
        // [Route("")]
        // public JsonResult Index()
        // {
        //     // Create Dojodachi!!!
        //     if(HttpContext.Session.GetObjectFromJson<Dojoachi>("achi") == null)
        //     {
        //         HttpContext.Session.SetObjectAsJson("achi", new Dojoachi());
        //     }
        //     var someObject = new {
        //         theDogachi = HttpContext.Session.GetObjectFromJson<Dojoachi>("achi"),
        //         achiStatus = ":D",
        //         loopStatus = "Losing",
        //         ownerStatus = "NOOB"
        //     };
        //     return Json(someObject);
        // }

        [HttpPost]
        [Route("actions")]
        public JsonResult Thing(string action)
        {
            Dojoachi danielAchiLOL = HttpContext.Session.GetObjectFromJson<Dojoachi>("achi");
            var someObject = new {
                achiFullness = danielAchiLOL.fullness,
                achiHappiness = danielAchiLOL.happiness,
                achiMeals = danielAchiLOL.meals,
                achiEnergy = danielAchiLOL.energy,
                achiStatus = ":D",
                loopStatus = "Losing",
                ownerStatus = "NOOB"
            };
            return Json(someObject);
        }

        [HttpGet]
        [Route("reset")]
        public IActionResult Reset()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }

    // to allow viewbag to use objects!
    public static class SessionExtensions
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
 
