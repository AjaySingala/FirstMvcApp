using FirstMvcApp.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstMvcApp.Controllers
{
    // Controller Level Filter.
    //[MyCustomFilter]
    public class HomeController : Controller
    {
        // Action Level Filter.
        //[MyCustomFilter]
        public ActionResult Index()
        //public string Index()
        {
            Debug.WriteLine("Action: Home.Index");

            return View();
            //return "This is the Index Action of the Home Controller.";
        }

        public ActionResult About()
        {
            Debug.WriteLine("Action: Home.About");

            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.AnotherMessage = "This is just a sample message.";

            return View();
        }

        public ActionResult Blog()
        {
            ViewBag.Subject = "My First Blog";
            ViewBag.Body = "This is my first blog";
            ViewBag.Author = "Ajay Singala";
            ViewBag.CreatedOn = DateTime.Now;

            return View();
        }
    }
}