using EventManagement.BLL;
using EventManagement.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventManagement.Controllers
{
    public class ConferenceController : Controller
    {
        private ConferenceManager _confManager;
        public ConferenceController()
        {
            _confManager = new ConferenceManager();
        }
        public ActionResult Home(int id)
        {
            ViewData["ConferenceId"] = id;
            return View(_confManager.GetConference(id));
        }
        public ActionResult PartialHome(List<string> images)
        {
            return PartialView(images);
        }

        [Route("Conference/{id}/Team")]
        public ActionResult Team(int id)
        {
            ViewData["ConferenceId"] = id;
            return View(_confManager.GetConferenceTeam(id));
        }

        [Route("Conference/{id}/Chair")]
        public ActionResult Chair(int id)
        {
            ViewData["ConferenceId"] = id;
            return View(_confManager.GetConferenceChair(id));
        }

        public ActionResult PartialVenue(VenueDTO venue)
        {
            return PartialView(venue);
        }

        [Route("Conference/{id}/Program/{day}")]
        public ActionResult Program(int id, int day)
        {
            ViewData["ConferenceId"] = id;
            return View(_confManager.GetConferenceProgram(id));
        }
    }
}