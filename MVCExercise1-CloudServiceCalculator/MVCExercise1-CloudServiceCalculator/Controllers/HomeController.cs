using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MVCExercise1_CloudServiceCalculator.Models;

namespace MVCExercise1_CloudServiceCalculator.Controllers {
    public class HomeController : Controller {
        [HttpGet]  
        public ActionResult Calculate() {
            ViewBag.InstanceSize = new SelectList(AzureService.SizeDescriptions);
            return View(new AzureService() { NumInstances = 2 });
        }

        [HttpPost]
        public ActionResult Calculate(AzureService service) {
            if (ModelState.IsValid) {
                return RedirectToAction("Confirm", service);
            }
            else {
                ViewBag.InstanceSize = new SelectList(AzureService.SizeDescriptions);
                return View(service);
            }
        }

        public ActionResult Confirm(AzureService service) {
            return View(service);
        }
    }
}