using Microsoft.WindowsAzure.ServiceRuntime;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CA3_SampleWork.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            String message;

            try {
                // read setting using Service Runtime API
                message = RoleEnvironment.GetConfigurationSettingValue("GreetingString");

                // write information trace message to trace listeners
                Trace.TraceInformation(message + "*****************");
            }
            catch (Exception e) {
                message = e.ToString();
                Trace.TraceInformation(e.ToString() + "*****************");
            }

            ViewBag.Message = message;
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