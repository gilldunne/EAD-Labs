using CA3_Practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CA3_Practice.Controllers {
    public class HomeController : Controller {
        [HttpGet]
        public ActionResult Calculate() {
            return View(new Toll() { VehicleType = VehicleType.Car, HasTag = false });
        }

        [HttpPost]
        public ActionResult Calculate(Toll t) {
            return View(t);
        }     
    }
}