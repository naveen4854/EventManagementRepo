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
        [Route("Conference/{key}/Home")]
        public ActionResult Home(string key)
        {
            var id = 0;
            if (!string.IsNullOrEmpty(key))
                id = _confManager.GetConferenceId(key);
            if (id == 0)
                throw new ArgumentException("Conference Not Found", "original");
            ViewData["ConferenceId"] = id;
            ViewData["Conferencekey"] = key;
            return View(_confManager.GetConference(id));
        }
        public ActionResult PartialHome(ConferenceDTO obj)
        {
            return PartialView(obj);
        }

        [Route("Conference/{key}/OrganisingCommitte")]
        public ActionResult Team(string key)
        {
            var id = 0;
            if (!string.IsNullOrEmpty(key))
                id = _confManager.GetConferenceId(key);
            if (id == 0)
                throw new ArgumentException("Conference Not Found", "original");
            ViewData["ConferenceId"] = id;
            ViewData["Conferencekey"] = key;
            return View(_confManager.GetConferenceTeam(id));
        }

        [Route("Conference/{key}/PartialTeam")]
        public ActionResult PartialTeam(string key)
        {
            var id = 0;
            if (!string.IsNullOrEmpty(key))
                id = _confManager.GetConferenceId(key);
            if (id == 0)
                throw new ArgumentException("Conference Not Found", "original");
            ViewData["ConferenceId"] = id;
            ViewData["Conferencekey"] = key;
            return PartialView(_confManager.GetConferenceTeam(id));
        }

        [Route("Conference/{key}/Chair")]
        public ActionResult Chair(string key)
        {
            var id = 0;
            if (!string.IsNullOrEmpty(key))
                id = _confManager.GetConferenceId(key);
            if (id == 0)
                throw new ArgumentException("Conference Not Found", "original");
            ViewData["ConferenceId"] = id;
            ViewData["Conferencekey"] = key;
            return View(_confManager.GetConferenceChair(id));
        }

        public ActionResult PartialVenue(VenueDTO venue)
        {
            return PartialView(venue);
        }

        [Route("Conference/{key}/Program/")]
        public ActionResult Program(string key)
        {
            var id = 0;
            if (!string.IsNullOrEmpty(key))
                id = _confManager.GetConferenceId(key);
            if (id == 0)
                throw new ArgumentException("Conference Not Found", "original");
            ViewData["ConferenceId"] = id;
            ViewData["Conferencekey"] = key;
            return View(_confManager.GetConferencePeriod(id));
        }

        [Route("Conference/{key}/Program/{day}")]
        public ActionResult PartialProgram(string key, int day)
        {
            var id = 0;
            if (!string.IsNullOrEmpty(key))
                id = _confManager.GetConferenceId(key);
            if (id == 0)
                throw new ArgumentException("Conference Not Found", "original");
            ViewData["ConferenceId"] = id;
            ViewData["Conferencekey"] = key;
            return PartialView(_confManager.GetConferencePrograms(id, day));
        }

        [Route("Conference/{key}/Poster/")]
        public ActionResult Poster(string key)
        {
            var id = 0;
            if (!string.IsNullOrEmpty(key))
                id = _confManager.GetConferenceId(key);
            if (id == 0)
                throw new ArgumentException("Conference Not Found", "original");
            ViewData["ConferenceId"] = id;
            ViewData["Conferencekey"] = key;
            return View(_confManager.GetConferencePosters(id));
        }


        [Route("Conference/{key}/Abstract/{prgId}")]
        public ActionResult PartialAbstract(string key, int prgId)
        {
            var id = 0;
            if (!string.IsNullOrEmpty(key))
                id = _confManager.GetConferenceId(key);
            if (id == 0)
                throw new ArgumentException("Conference Not Found", "original");
            ViewData["ConferenceId"] = id;
            ViewData["Conferencekey"] = key;
            var a = _confManager.GetAbstract(id, prgId);
            return PartialView("PartialAbstract", a);
        }

        [Route("Conference/{key}/DownloadBrochure/")]
        public ActionResult DownloadBrochure(string key)
        {
            return RedirectToAction("Index", "Error");
            //var id = 0;
            //if (!string.IsNullOrEmpty(key))
            //    id = _confManager.GetConferenceId(key);
            //if (id == 0)
            //    throw new ArgumentException("Conference Not Found", "original");
            //ViewData["ConferenceId"] = id;
            //ViewData["Conferencekey"] = key;
            //var fileName = _confManager.GetConferenceBrochure(id);
            //if (!string.IsNullOrEmpty(fileName))
            //{
            //    DirectoryInfo dirInfo = new DirectoryInfo(HostingEnvironment.MapPath("~/Content/downloads/confbrouchers"));
            //    return File(dirInfo.FullName + @"\" + fileName, "application / docx", "brochure.docx");
            //}
            //else
            //{
            //    return RedirectToAction("Index", "Error");
            //}
        }

        [Route("Conference/DownloadSampleAbstract/")]
        public ActionResult DownloadSampleAbstract()
        {
            var fileName = "Sample Abstract.docx";
            if (!string.IsNullOrEmpty(fileName))
            {
                DirectoryInfo dirInfo = new DirectoryInfo(HostingEnvironment.MapPath("~/Content/downloads/"));
                return File(dirInfo.FullName + @"\" + fileName, "application / docx", "Sample Abstract.docx");
            }
            else
            {
                return RedirectToAction("Index", "Error");
            }
        }

        [Route("Conference/SponsorExhibitor/")]
        public ActionResult SponsorExhibitor()
        {
            var fileName = "Sponsor and Exhibitor.PDF";
            if (!string.IsNullOrEmpty(fileName))
            {
                DirectoryInfo dirInfo = new DirectoryInfo(HostingEnvironment.MapPath("~/Content/downloads/"));
                return File(dirInfo.FullName + @"\" + fileName, "application / pdf", "Sponsor and Exhibitor.PDF");
            }
            else
            {
                return RedirectToAction("Index", "Error");
            }
        }

        [Route("Conference/{key}/ScientificSessions/")]
        public ActionResult ScientificSessions(string key)
        {
            var id = 0;
            if (!string.IsNullOrEmpty(key))
                id = _confManager.GetConferenceId(key);
            if (id == 0)
                throw new ArgumentException("Conference Not Found", "original");
            ViewData["ConferenceId"] = id;
            ViewData["Conferencekey"] = key;
            return View("tracks", _confManager.GetConferenceTracks(id));
        }

        [Route("Conference/{key}/PartialAbstractSubmit/{trackId}")]
        public ActionResult PartialAbstractSubmit(string key, int trackId)
        {
            var id = 0;
            if (!string.IsNullOrEmpty(key))
                id = _confManager.GetConferenceId(key);
            if (id == 0)
                throw new ArgumentException("Conference Not Found", "original");
            ViewData["ConferenceId"] = id;
            ViewData["Conferencekey"] = key;
            ViewBag.Titles = _confManager.GetTitles();
            ViewBag.Categories = _confManager.GetCategories();
            ViewBag.Countries = _confManager.GetCountries();
            ViewBag.Tracks = _confManager.GetConferenceTracks(id);
            ViewBag.Track = trackId;

            return PartialView("PartialAbstractSubmit");
        }

        [Route("Conference/{key}/AbstractSubmit")]
        public ActionResult AbstractSubmit(string key)
        {
            var id = 0;
            if (!string.IsNullOrEmpty(key))
                id = _confManager.GetConferenceId(key);
            if (id == 0)
                throw new ArgumentException("Conference Not Found", "original");
            ViewData["ConferenceId"] = id;
            ViewData["Conferencekey"] = key;
            ViewBag.Titles = _confManager.GetTitles();
            ViewBag.Categories = _confManager.GetCategories();
            ViewBag.Countries = _confManager.GetCountries();
            ViewBag.Tracks = _confManager.GetConferenceTracks(id);

            return View();
        }

        [HttpPost]
        public ActionResult SubmitAbstract(AbstractSubmitDTO obj)
        {
            _confManager.PostAbstract(obj);
            return RedirectToAction("Tracks", "Conference", new { id = obj.ConferenceId });
        }

        [Route("Conference/{key}/Registration/")]
        public ActionResult Registration(string key)
        {
            var id = 0;
            if (!string.IsNullOrEmpty(key))
                id = _confManager.GetConferenceId(key);
            if (id == 0)
                throw new ArgumentException("Conference Not Found", "original");
            ViewData["ConferenceId"] = id;
            ViewData["Conferencekey"] = key;
            var dt = new DateTime(2017, 06, 20);
            ViewBag.Countries = _confManager.GetCountries();
            var pricingTypeLst1 = new List<PricingType>
            {
                new PricingType { Name = "Early", IsActive = DateTime.Compare(dt,DateTime.Now.Date)>=0, Price = 699},
                new PricingType { Name = "Standard", IsActive = DateTime.Compare(dt,DateTime.Now.Date)<0, Price = 799},
            };

            var pricingTypeLst2 = new List<PricingType>
            {
                new PricingType { Name = "Early", IsActive = DateTime.Compare(dt,DateTime.Now.Date)>=0, Price = 599},
                new PricingType { Name = "Standard", IsActive = DateTime.Compare(dt,DateTime.Now.Date)<0, Price = 699},
            };

            var pricingTypeLst3 = new List<PricingType>
            {
                new PricingType { Name = "Early", IsActive = DateTime.Compare(dt,DateTime.Now.Date)>=0, Price = 399},
                new PricingType { Name = "Standard", IsActive = DateTime.Compare(dt,DateTime.Now.Date)<0, Price = 499},
            };

            var pricingTypeLst4 = new List<PricingType>
            {
                new PricingType { Name = "Early", IsActive = DateTime.Compare(dt,DateTime.Now.Date)>=0, Price = 299},
                new PricingType { Name = "Standard", IsActive = DateTime.Compare(dt,DateTime.Now.Date)<0, Price = 299},
            };

            var regTypelst = new List<RegistrationTypeDTO>();
            regTypelst.Add(new RegistrationTypeDTO { Id = 1, Name = "Speaker Registration", IsActive = true, PricingTypes = pricingTypeLst1 });
            regTypelst.Add(new RegistrationTypeDTO { Id = 2, Name = "Delegate Registration", IsActive = true, PricingTypes = pricingTypeLst2 });
            regTypelst.Add(new RegistrationTypeDTO { Id = 3, Name = "Poster Registration", IsActive = true, PricingTypes = pricingTypeLst3 });
            regTypelst.Add(new RegistrationTypeDTO { Id = 4, Name = "Student Delegate", IsActive = true, PricingTypes = pricingTypeLst4 });


            var occlst1 = new List<OccupancyDTO> {
                new OccupancyDTO { Name="single",IsActive = true, Price = 360},
                new OccupancyDTO { Name="double",IsActive = true, Price = 400},
                new OccupancyDTO { Name="triple",IsActive = true, Price = 440}
            };
            var occlst2 = new List<OccupancyDTO> {
                new OccupancyDTO { Name="single",IsActive = true, Price = 540},
                new OccupancyDTO { Name="double",IsActive = true, Price = 600},
                new OccupancyDTO { Name="triple",IsActive = true, Price = 640}
            };
            var occlst3 = new List<OccupancyDTO> {
                new OccupancyDTO { Name="single",IsActive = true, Price = 720},
                new OccupancyDTO { Name="double",IsActive = true, Price = 800},
                new OccupancyDTO { Name="triple",IsActive = true, Price = 880}
            };

            var acclst = new List<AccommodationDTO> {
                new AccommodationDTO { Name = "For 2 Nights", occ = occlst1},
                new AccommodationDTO { Name = "For 3 Nights", occ = occlst2},
                new AccommodationDTO { Name = "For 4 Nights", occ = occlst3},
            };

            ViewBag.Reglst = regTypelst;

            var purchase = new PurchaseDTO();
            purchase.Reg = regTypelst;
            purchase.acc = acclst;
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
            if (ModelState.IsValid)
                return RedirectToAction("Registration", "Conference", new { id = 8 });
            return RedirectToAction("Registration", "Conference", new { id = 8 });
        }

        [Route("Conference/{key}/Guidelines/")]
        public ActionResult Guidelines(string key)
        {
            var id = 0;
            if (!string.IsNullOrEmpty(key))
                id = _confManager.GetConferenceId(key);
            if (id == 0)
                throw new ArgumentException("Conference Not Found", "original");
            ViewData["ConferenceId"] = id;
            ViewData["Conferencekey"] = key;
            return View();
        }

        [Route("Conference/{key}/RegistrationPolicy/")]
        public ActionResult RegistrationPolicy(string key)
        {
            var id = 0;
            if (!string.IsNullOrEmpty(key))
                id = _confManager.GetConferenceId(key);
            if (id == 0)
                throw new ArgumentException("Conference Not Found", "original");
            ViewData["ConferenceId"] = id;
            ViewData["Conferencekey"] = key;
            return View();
        }

        [Route("Conference/ModalRegistrationPolicy/")]
        public ActionResult ModalRegistrationPolicy()
        {
            return PartialView();
        }
        [Route("Conference/{key}/Email/")]
        public ActionResult ConferenceEmail(string key)
        {
            var email = _confManager.GetConferenceEmail(key);
            return PartialView("ConferenceEmail", email);
        }
    }
}