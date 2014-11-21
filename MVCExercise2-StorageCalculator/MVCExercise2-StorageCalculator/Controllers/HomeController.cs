using MVCExercise2_StorageCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCExercise2_StorageCalculator.Controllers {
    public class HomeController : Controller {
        [HttpGet]
        public ActionResult Calculate() {
            return View(new Storage{Redundancy=Redundancy.Geo});
        }
        [HttpPost]
        public ActionResult Calculate(Storage s) {
            if (ModelState.IsValid) {
                return RedirectToAction("Confirm", s);
            }
            else {
                return View("Calculate");
            }
        }

        public ActionResult Confirm(Storage s) {
            return View(s);
        }
    }
}