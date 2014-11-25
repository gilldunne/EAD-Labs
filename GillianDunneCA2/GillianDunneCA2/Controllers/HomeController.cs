// Gillian Dunne - X00094469

using GillianDunneCA2.Models;
using System.Web.Mvc;

namespace GillianDunneCA2.Controllers {
    public class HomeController : Controller {
        [HttpGet]
        public ActionResult Calculate() {
            return View(new Toll() { CarType = CarType.Car, Tag = false});
        }

        [HttpPost] 
        public ActionResult Calculate(Toll toll) {
            return View(toll);
        }
    }
}