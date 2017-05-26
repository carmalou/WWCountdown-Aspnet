using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebCountdownApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //string initialCountdown = TimeRemaining();
            string initialCountdown = "Wonder Woman is coming.";
            return View(model: initialCountdown);
        }
    }
}