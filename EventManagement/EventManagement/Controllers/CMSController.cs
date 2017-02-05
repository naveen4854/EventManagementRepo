﻿using EventManagement.BLL;
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