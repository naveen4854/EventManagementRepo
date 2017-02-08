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

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NewVenue()
        {
            return View();
        }

        public ActionResult Venue(int id)
        {
            var venue = _confManager.GetVenue(id);
            return View(venue);
        }

        [HttpPost]
        public ActionResult AddVenue(VenueDTO obj)
        {
            _confManager.AddVenue(obj);
            return RedirectToAction("AllVenues", "CMS");
        }

        public ActionResult UpdateVenue(VenueDTO obj)
        {
            var venue = _confManager.UpdateVenue(obj);
            return RedirectToAction("AllVenues", "CMS");
        }

        public ActionResult DeleteVenue(int id)
        {
            var venue = _confManager.DeleteVenue(id);
            return RedirectToAction("AllVenues", "CMS");
        }

        public ActionResult AllVenues()
        {
            var venues = _confManager.GetVenues();
            return View("AllVenues", venues);
        }

        public ActionResult NewConference()
        {
            ViewBag.Venues = _confManager.GetVenues();
            return View(new ConferenceDTO());
        }

        public ActionResult Conference(int id)
        {
            ViewBag.Venues = _confManager.GetVenues();
            var conf = _confManager.GetConference(id);
            return View(conf);
        }

        [HttpPost]
        public ActionResult AddConference(ConferenceDTO obj)
        {
            _confManager.AddConference(obj);
            return RedirectToAction("AllConferences", "CMS");
        }

        public ActionResult UpdateConference(ConferenceDTO obj)
        {
            var venue = _confManager.UpdateConference(obj);
            return RedirectToAction("AllConferences", "CMS");
        }

        public ActionResult DeleteConference(int id)
        {
            var venue = _confManager.DeleteConference(id);
            return RedirectToAction("AllConferences", "CMS");
        }


        public ActionResult AllConferences()
        {
            var confs = _confManager.GetConferences();
            return View("AllConferences", confs);
        }

        public ActionResult NewTrack()
        {
            ViewBag.Conferences = _confManager.GetConferences();
            return View();
        }

        public ActionResult Track(TrackDTO obj)
        {
            ViewBag.Conferences = _confManager.GetConferences();
            var track = _confManager.GetTrack(obj.Id);
            return View(track);
        }

        [HttpPost]
        public ActionResult AddTrack(TrackDTO obj)
        {
            var confId = _confManager.AddTrack(obj);
            //var tracks = _confManager.GetConferenceTracks(obj.ConferenceId);
            return RedirectToAction("AllTracks", "CMS", new { id = confId });
        }

        public ActionResult UpdateTrack(TrackDTO obj)
        {
            var track = _confManager.UpdateTrack(obj);
            return RedirectToAction("AllTracks", "CMS",new { id = obj.ConferenceId });
        }

        public ActionResult DeleteTrack(int id)
        {
            var track = _confManager.DeleteTrack(id);
            return RedirectToAction("AllTracks", "CMS", new { id = track.ConferenceId});
        }

        public ActionResult AllTracks(int? id)
        {
            var conferences = _confManager.GetConferences();

            if (conferences.Count > 0)
            {
                ViewBag.Conferences = conferences;
                var confId = id ?? conferences[0].Id;
                var tracks = _confManager.GetConferenceTracks(confId);
                return View("AllTracks", tracks);
            }
            else
                return RedirectToAction("NewConference", "CMS");
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
            var confDto = _confManager.GetConferenceTeam(obj.ConferenceId);
            return PartialView("AllConferenceTeams", confDto.Team);
        }

        public ActionResult AllConferenceTeams(int id)
        {
            var confDto = _confManager.GetConferenceTeam(id);
            return PartialView("AllConferenceTeams", confDto.Team);
        }

        public ActionResult ConferencePrograms()
        {
            ViewBag.Conferences = _confManager.GetConferences();
            return View();
        }

        [HttpPost]
        public ActionResult AddConferenceProgram(ProgramDTO obj)
        {
            _confManager.AddConferenceProgram(obj);
            var confDto = _confManager.GetAllConferencePrograms(obj.ConferenceId);
            return PartialView("AllConferencePrograms", confDto);
        }

        public ActionResult AllConferencePrograms(int id)
        {
            var confDto = _confManager.GetAllConferencePrograms(id);
            return PartialView("AllConferencePrograms", confDto);
        }

    }
}
