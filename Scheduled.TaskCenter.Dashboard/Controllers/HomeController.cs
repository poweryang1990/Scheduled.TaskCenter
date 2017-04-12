using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Scheduled.TaskCenter.Dashboard.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           return Redirect("/jobs");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}