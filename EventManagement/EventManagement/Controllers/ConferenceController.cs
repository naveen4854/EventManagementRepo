using EventManagement.BLL;
using EventManagement.DataModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Hosting;
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

        [Route("Conference/{id}/Program/")]
        public ActionResult Program(int id)
        {
            ViewData["ConferenceId"] = id;
            return View(_confManager.GetConferencePeriod(id));
        }

        [Route("Conference/{id}/Program/{day}")]
        public ActionResult PartialProgram(int id, int day)
        {
            ViewData["ConferenceId"] = id;
            return PartialView(_confManager.GetConferencePrograms(id, day));
        }

        [Route("Conference/{id}/Abstract/{prgId}")]
        public ActionResult PartialAbstract(int id, int prgId)
        {
            try
            {
                ViewData["ConferenceId"] = id;
                var a = _confManager.GetAbstract(id, prgId);
                return PartialView("PartialAbstract", a);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        [Route("Conference/{id}/download/")]
        public ActionResult getfile(int id)
        {
            ViewData["ConferenceId"] = id;
            var fileName = _confManager.GetConferenceBrochure(id);
            if (!string.IsNullOrEmpty(fileName))
            {
                DirectoryInfo dirInfo = new DirectoryInfo(HostingEnvironment.MapPath("~/Content/downloads/confbrouchers"));
                return File(dirInfo.FullName + @"\" + fileName, "application / docx", "brochure.docx");
            }
            else
            {
                return RedirectToAction("Index","Error");
            }
        }

        [Route("Conference/{id}/Tracks/")]
        public ActionResult Tracks(int id)
        {
            ViewData["ConferenceId"] = id;
            return View(_confManager.GetConferenceTracks(id));
        }

        [Route("Conference/PartialAbstractSubmit/")]
        [HttpPost]
        public ActionResult PartialAbstractSubmit(TrackDTO[] tracks)
        {
            return PartialView();
        }
    }
}