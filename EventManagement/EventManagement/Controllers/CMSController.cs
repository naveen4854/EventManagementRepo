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

        #region Venue
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

        #endregion Venue

        #region Conference

        public ActionResult NewConference()
        {
            ViewBag.Venues = _confManager.GetVenues();
            return View(new ConferenceDTO { StartDt = DateTime.Now.Date,EndDt = DateTime.Now.Date.AddDays(3)});
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

        #endregion Conference

        #region Track

        public ActionResult NewTrack()
        {
            ViewBag.Conferences = _confManager.GetConferences();
            return View();
        }

        public ActionResult Track(int id)
        {
            ViewBag.Conferences = _confManager.GetConferences();
            var track = _confManager.GetTrack(id);
            return View(track);
        }

        [HttpPost]
        public ActionResult AddTrack(TrackDTO obj)
        {
            _confManager.AddTrack(obj);
            var tracks = _confManager.GetConferenceTracks(obj.ConferenceId);
            return PartialView("AllTracks", tracks);
        }

        [HttpPost]
        public ActionResult UpdateTrack(TrackDTO obj)
        {
            _confManager.UpdateTrack(obj);
            var tracks = _confManager.GetConferenceTracks(obj.ConferenceId);
            return PartialView("AllTracks", tracks);
        }

        public ActionResult DeleteTrack(int id)
        {
            _confManager.DeleteTrack(id);
            return RedirectToAction("AllTracks", "CMS");
        }

        public ActionResult AllTracks(int? confid)
        {
            var confs = _confManager.GetConferences();
            ViewBag.Conferences = _confManager.GetConferences();
            if (confs.Count > 0)
            {
                if (confid == null)
                {
                    ViewBag.ConfId = confs.FirstOrDefault().Id;
                    var tracks = _confManager.GetConferenceTracks(confs.FirstOrDefault().Id);
                    return View("AllTracks", tracks);
                }
                else
                {
                    ViewBag.ConfId = confid.Value;
                    var tracks = _confManager.GetConferenceTracks(confid.Value);
                    if (tracks.Count > 0)
                        return View("AllTracks", tracks);
                    else
                        return RedirectToAction("AddTrack", "CMS", new { id = confid.Value });
                }
                
            }
            else
                return RedirectToAction("AddConference", "CMS");
        }

        #endregion Track

        #region images


        public ActionResult NewImage()
        {
            ViewBag.Conferences = _confManager.GetConferences();
            return View();
        }

        //public ActionResult Image(int id)
        //{
        //    ViewBag.Conferences = _confManager.GetConferences();
        //    var Image = _confManager.GetImage(id);
        //    return View(Image);
        //}

        [HttpPost]
        public ActionResult AddConferenceImages(ConferenceDTO obj)
        {
            _confManager.AddConferenceImages(obj);
            var confDto = _confManager.GetConferenceImages(obj.Id);
            return PartialView("AllConferenceImages", confDto);
        }

        //[HttpPost]
        //public ActionResult UpdateImage(ImageDTO obj)
        //{
        //    _confManager.UpdateImage(obj);
        //    var Images = _confManager.GetConferenceImages(obj.ConferenceId);
        //    return PartialView("AllImages", Images);
        //}

        public ActionResult DeleteConferenceImage(int id)
        {
            _confManager.DeleteConferenceImage(id);
            return RedirectToAction("AllImages", "CMS");
        }

        public ActionResult AllImages(int? confid)
        {
            var confs = _confManager.GetConferences();
            ViewBag.Conferences = _confManager.GetConferences();
            if (confs.Count > 0)
            {
                if (confid == null)
                {
                    ViewBag.ConfId = confs.FirstOrDefault().Id;
                    var Images = _confManager.GetConferenceImagesDTO(confs.FirstOrDefault().Id);
                    return View("AllImages", Images);
                }
                else
                {
                    ViewBag.ConfId = confid.Value;
                    var conf = _confManager.GetConferenceImagesDTO(confid.Value);
                    if (conf.Count() > 0)
                        return View("AllImages", conf);
                    else
                        return RedirectToAction("AddImage", "CMS", new { id = confid.Value });
                }

            }
            else
                return RedirectToAction("AddConference", "CMS");
        }

        #endregion images

        #region team

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
        #endregion team

        #region program

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
        #endregion images

    }
}
