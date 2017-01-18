using EventManagement.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventManagement.Controllers
{
    public class ConferenceController : Controller
    {
        public ActionResult Home(int id)
        {
            var a = new ConferenceManager();
            return View(a.GetConference(id));
        }
        public ActionResult PartialHome(List<string> images)
        {
            return PartialView(images);
        }
    }
}