using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab1_Welcome.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            ViewBag.TodaysDateTime = DateTime.Now;
            ViewBag.TimeZone = TimeZone.CurrentTimeZone.StandardName; 
            return View();
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}