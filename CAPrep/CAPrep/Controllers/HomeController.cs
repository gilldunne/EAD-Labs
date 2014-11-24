using CAPrep.Models;
using System.Web.Mvc;


namespace CAPrep.Controllers {
    public class HomeController : Controller {
        [HttpGet]
        public ActionResult Calculate() {
            return View(new CloudService() { Size = Size.Medium, NumInstances = 2 });
        }

        [HttpPost]
        public ActionResult Calculate(CloudService cs) {
            if (ModelState.IsValid) {
                return RedirectToAction("Confirm", cs);
            }
            return View(cs);
        }

        public ActionResult Confirm(CloudService cs) {
            return View(cs);
        }
    }
}