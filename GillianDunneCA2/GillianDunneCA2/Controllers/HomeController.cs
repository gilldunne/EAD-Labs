// Gillian Dunne - X00094469

using GillianDunneCA2.Models;
using System.Web.Mvc;

namespace GillianDunneCA2.Controllers {
    public class HomeController : Controller {
        // Create a view for calculations, setting defauls to Car and no tag present
        [HttpGet]
        public ActionResult Calculate() {
            return View(new Toll() { VehicleType = VehicleType.Car, Tag = false});
        }

        // Display the cost once the calculate button is pressed
        [HttpPost] 
        public ActionResult Calculate(Toll toll) {
            return View(toll);
        }
    }
}