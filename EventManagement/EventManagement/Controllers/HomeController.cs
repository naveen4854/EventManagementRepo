using EventManagement.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventManagement.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PartialConferences()
        {
            ConferenceManager a = new ConferenceManager();
            var c = a.GetConferences();
            return PartialView(c);
        }
    }
}