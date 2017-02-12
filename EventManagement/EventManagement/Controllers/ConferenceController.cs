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
            ViewBag.Titles = _confManager.GetTitles();
            ViewBag.Categories = _confManager.GetCategories();
            ViewBag.Countries = _confManager.GetCountries();
            ViewBag.Tracks = tracks;
            //var c = new AbstractSubmitModel
            //{
            //    Titles = _confManager.GetTitles(),
            //    Categories = _confManager.GetCategories(),
            //    Countries = _confManager.GetCountries(),
            //    Tracks = tracks
            //};
            return PartialView("PartialAbstractSubmit");
        }

        [HttpPost]
        public ActionResult SubmitAbstract(AbstractSubmitDTO obj)
        {
            _confManager.PostAbstract(obj);
            return RedirectToAction("Tracks", "Conference", new { id = obj.ConferenceId});
        }

        [Route("Conference/{id}/Registration/")]
        public ActionResult Registration(int id)
        {
            ViewData["ConferenceId"] = id;
            var regclasslst = new List<RegistrationClass>();
            regclasslst.Add(new RegistrationClass {Id=1, Name = "Academia", IsActive = false, Amount = 150 });
            regclasslst.Add(new RegistrationClass {Id=2, Name = "Business", IsActive = false, Amount = 350 });

            var regPerLst = new List<RegistrationPeriodDTO>();
            regPerLst.Add(new RegistrationPeriodDTO { Name = "Early", IsActive = true, regclass = regclasslst });
            regPerLst.Add(new RegistrationPeriodDTO { Name = "near", IsActive = true, regclass = regclasslst });
            regPerLst.Add(new RegistrationPeriodDTO { Name = "On Time", IsActive = true, regclass = regclasslst });

            var reglst = new List<RegistrationDTO>();
            reglst.Add(new RegistrationDTO { Id = 1, Name = "Poster Registration", IsActive = true});
            reglst.Add(new RegistrationDTO { Id = 2, Name = "Speaker Registration", IsActive = true });
            reglst.Add(new RegistrationDTO { Id = 3, Name = "Delegate Registration", IsActive = true });
            reglst.Add(new RegistrationDTO { Id = 4, Name = "Student Delegate", IsActive = true });

            var occ = new List<OccupancyDTO>();
            occ.Add(new OccupancyDTO { Id = 1, Name = "Single", NoOfPeople = 1, isSelected = false, Amount = 200 });
            occ.Add(new OccupancyDTO { Id = 2, Name = "Double", NoOfPeople = 2, isSelected = false, Amount = 300});
            occ.Add(new OccupancyDTO { Id = 3, Name = "Triple", NoOfPeople = 3, isSelected = false, Amount = 400 });

            var acc = new List<AccommodationDTO>();
            acc.Add(new AccommodationDTO { Id = 1, Name = "For 2 Nights"});
            acc.Add(new AccommodationDTO { Id = 3, Name = "For 3 Nights"});
            acc.Add(new AccommodationDTO { Id = 4, Name = "For 4 Nights"});

            ViewBag.Reglst = reglst;
            ViewBag.regclasslst = regclasslst;

            ViewBag.acclst = acc;
            ViewBag.occlst = occ;

            var purchase = new PurchaseDTO();
            ViewBag.AccompanyPrices = _confManager.GetAllAccompanyPrice(id);
            ViewBag.Countries = _confManager.GetCountries();
            return View(purchase);
        }

        public ActionResult GetRegPrice(int regTypeId, int regClassId)
        {
            var confId = 8;
            var amount = _confManager.GetRegPrice(regTypeId, regClassId, confId);
            return Json(new { txt = "$" + amount, val = amount }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAccPrice(int AccTypeId, int OccId)
        {
            var confId = 8;
            var amount = _confManager.GetAccPrice(AccTypeId, OccId, confId);
            return Json(new { txt = "$" + amount, val = amount }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAccompanyPrice(int accompanyId)
        {
            var confId = 8;
            var amount = _confManager.GetAccompanyPrice(accompanyId, confId);
            return Json(new { txt = "$" + amount, val = amount }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult test(PurchaseDTO obj)
        {
            return RedirectToAction("Registration", "Conference", new { id = 8 });
        }

        //[Route("Conference/Submit/")]
        //[HttpPost]
        //public ActionResult AbstractSubmit(AbstractSubmitDTO obj)
        //{
        //    _confManager.PostAbstract(obj);
        //    return new HttpStatusCodeResult(HttpStatusCode.OK);
        //}

        //[Route("Conference/mail/")]
        //public void AbstractSubmit()
        //{
        //    var client = new SmtpClient("smtp.gmail.com", 587)
        //    {
        //        UseDefaultCredentials = false,
        //        Credentials = new NetworkCredential("sc_admin@scientificcognizance.com", "SC_admin_2017"),
        //        //Credentials = new NetworkCredential("naveen4854@gmail.com", "naveenkumar@1"),
        //        EnableSsl = true,
        //    };
        //    client.Send("sc_admin@scientificcognizance.com", "naveen4854@gmail.com", "Test", "test message");
        //}


    }
}