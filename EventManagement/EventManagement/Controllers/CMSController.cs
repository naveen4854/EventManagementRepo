using EventManagement.BLL;
using EventManagement.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventManagement.Controllers
{
    public class CMSController : Controller
    {
        private ConferenceManager _confManager;
        public CMSController()
        {
            _confManager = new ConferenceManager();
        }

        public ActionResult Index() {
            return View();
        }

        public ActionResult Venues()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddVenue(VenueDTO obj)
        {
            _confManager.AddVenue(obj);
            return RedirectToAction("AllVenues", "CMS");
        }

        public ActionResult AllVenues()
        {
            var venues = _confManager.GetVenues();
            return PartialView("AllVenues", venues);
        }

        public ActionResult Conferences()
        {
            ViewBag.Venues = _confManager.GetVenues();
            return View(new ConferenceDTO());
        }

        [HttpPost]
        public ActionResult AddConference(ConferenceDTO obj)
        {
            _confManager.AddConference(obj);
            return RedirectToAction("AllConferences", "CMS");
        }

        public ActionResult AllConferences()
        {
            var confs = _confManager.GetConferences();
            return PartialView("AllConferences", confs);
        }

        public ActionResult Tracks()
        {
            ViewBag.Conferences = _confManager.GetConferences();
            return View();
        }

        [HttpPost]
        public ActionResult AddTrack(TrackDTO obj)
        {
            _confManager.AddTrack(obj);
            var tracks = _confManager.GetConferenceTracks(obj.ConferenceId);
            return PartialView("AllTracks", tracks);
        }

        public ActionResult AllTracks(int id)
        {
            var tracks = _confManager.GetConferenceTracks(id);
            return PartialView("AllTracks", tracks);
        }

        public ActionResult ConferenceImages()
        {
            ViewBag.Conferences = _confManager.GetConferences();
            return View();
        }

        [HttpPost]
        public ActionResult AddConferenceImages(ConferenceDTO obj)
        {
            _confManager.AddConferenceImages(obj);
            var confDto = _confManager.GetConferenceImages(obj.Id);
            return PartialView("AllConferenceImages", confDto);
        }

        public ActionResult AllConferenceImages(int id)
        {
            var confDto = _confManager.GetConferenceImages(id);
            return PartialView("AllConferenceImages", confDto);
        }

        public ActionResult ConferenceTeams()
        {
            ViewBag.Conferences = _confManager.GetConferences();
            return View();
        }

        [HttpPost]
        public ActionResult AddConferenceTeam(ConferenceTeamDTO obj)
        {
            _confManager.AddConferenceTeam(obj);
            return View();
        }

        public ActionResult ConferencePrograms()
        {
            ViewBag.Conferences = _confManager.GetConferences();
            return View();
        }

        [HttpPost]
        public ActionResult AddConferenceProgram(ProgramDTO obj)
        {
            return View();
        }
        // GET: CMS/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CMS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CMS/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CMS/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CMS/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CMS/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CMS/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
