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
            ViewData["ConferenceId"] = id;
            var a = new ConferenceManager();
            return View(a.GetConference(id));
        }
        public ActionResult PartialHome(List<string> images)
        {
            return PartialView(images);
        }

        [Route("Conference/{id}/Team")]
        public ActionResult Team(int id)
        {
            var a = new ConferenceManager();
            return View(a.GetConferenceTeam(id));
        }

        [Route("Conference/{id}/Chair")]
        public ActionResult Chair(int id)
        {
            var a = new ConferenceManager();
            return View(a.GetConferenceChair(id));
        }
    }
}