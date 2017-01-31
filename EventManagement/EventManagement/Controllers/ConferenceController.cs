using EventManagement.BLL;
using EventManagement.DataModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
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
                return RedirectToAction("Index", "Error");
            }
        }

        [Route("Conference/{id}/Tracks/")]
        public ActionResult Tracks(int id)
        {
            ViewData["ConferenceId"] = id;
            return View(_confManager.GetConferenceTracks(id));
        }

        [Route("Conference/AbstractSubmit/")]
        public ActionResult AbstractSubmit(IEnumerable<TrackDTO> tracks, int id)
        {
            ViewData["ConferenceId"] = id;
            var c = new AbstractSubmitModel
            {
                Titles = _confManager.GetTitles(),
                Categories = _confManager.GetCategories(),
                Countries = _confManager.GetCountries(),
                Tracks = tracks
            };
            return PartialView("PartialAbstractSubmit", c);
        }


        [Route("Conference/Submit/")]
        [HttpPost]
        public ActionResult AbstractSubmit(AbstractSubmitDTO obj)
        {
            //if (obj.DocUpload != null && obj.DocUpload.ContentLength > 0)
            //{
            //    var uploadDir = "~/content/uploads/";
            //    var filePath = Path.Combine(Server.MapPath(uploadDir), obj.DocUpload.FileName);
            //    obj.DocUpload.SaveAs(filePath);
            //}
            //obj.DocUrl = obj.DocUpload.FileName;
            _confManager.PostAbstract(obj);
            return PartialView();
        }

        [Route("Conference/mail/")]
        public void AbstractSubmit()
        {

            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("sc_admin@scientificcognizance.com", "SC_admin_2017"),
                //Credentials = new NetworkCredential("naveen4854@gmail.com", "naveenkumar@1"),
                EnableSsl = true,
                
        };
            client.Send("sc_admin@scientificcognizance.com", "naveen4854@gmail.com", "Test", "test message");
        }


    }
}