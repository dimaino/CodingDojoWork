using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections;

namespace YourNamespace.Controllers
{
    public class MainController : Controller
    {
        // [HttpGet]
        // [Route("")]
        // public IActionResult Index()
        // {
        //     Random rand = new Random();
        //     string values = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        //     char[] StringChars = new char[14];
        //     for(int i = 0; i < StringChars.Length; i++)
        //     {
        //         StringChars[i] = values[rand.Next(values.Length)];
        //     }
            
            
        //     int? Count = HttpContext.Session.GetInt32("TimesClicked");
        //     if(Count == null)
        //     {
        //         Count = 0;
        //     }
        //     Count++;
        //     HttpContext.Session.SetInt32("TimesClicked", (int)Count);
        //     ViewBag.outputString = new String(StringChars); 
        //     ViewBag.count = Count; 
        //     return View("index");
        // }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("index");
        }

        [HttpGet]
        [Route("hey")]
        public JsonResult thinga()
        {
            Random rand = new Random();
            string values = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            char[] StringChars = new char[14];
            for(int i = 0; i < StringChars.Length; i++)
            {
                StringChars[i] = values[rand.Next(values.Length)];
            }
            
            
            int? Count = HttpContext.Session.GetInt32("TimesClicked");
            if(Count == null)
            {
                Count = 0;
            }
            Count++;
            HttpContext.Session.SetInt32("TimesClicked", (int)Count);
            //ViewBag.outputString = new String(StringChars); 
            //ViewBag.count = Count;

            var someObject = new {
                count = Count,
                someString = StringChars,
            };
            return Json(someObject);
        }



        [HttpGet]
        [Route("thing")]
        public IActionResult thing()
        {
            return RedirectToAction("Index");
        }
    }
}