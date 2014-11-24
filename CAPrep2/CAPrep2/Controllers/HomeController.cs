using CAPrep2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CAPrep2.Controllers {
    public class HomeController : Controller {
        [HttpGet]
        public ActionResult Calculate() {
            return View(new Storage() { Redundancy = Redundancy.Geo, Size = 2});
        }

        [HttpPost]
        public ActionResult Calculate(Storage s) {
            if (ModelState.IsValid) {
                return RedirectToAction("Confirm", s);
            }
            return View(s);
        }

        public ActionResult Confirm(Storage s) {
            return View(s);
        }
    }
}