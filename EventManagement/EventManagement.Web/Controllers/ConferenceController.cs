using EventManagement.BLL;
using EventManagement.DataModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Security.Cryptography;
using System.Text;
using System.Web.Hosting;
using System.Web.Mvc;

namespace EventManagement.Controllers
{
    public class ConferenceController : Controller
    {
        private readonly ConferenceManager _confManager;
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
        public ActionResult OrganisingCommitte(string key)
        {
            var id = 0;
            if (!string.IsNullOrEmpty(key))
                id = _confManager.GetConferenceId(key);
            if (id == 0)
                throw new ArgumentException("Conference Not Found", "original");
            ViewData["ConferenceId"] = id;
            ViewData["Conferencekey"] = key;
            return View(_confManager.GetConferenceOCM(id));
        }

        [Route("Conference/{key}/PartialOCM")]
        public ActionResult PartialOCM(string key)
        {
            var id = 0;
            if (!string.IsNullOrEmpty(key))
                id = _confManager.GetConferenceId(key);
            if (id == 0)
                throw new ArgumentException("Conference Not Found", "original");
            ViewData["ConferenceId"] = id;
            ViewData["Conferencekey"] = key;
            return PartialView(_confManager.GetConferenceOCM(id));
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
                string mimeType = "application/pdf";
                Response.AppendHeader("Content-Disposition", "inline; filename=" + fileName);
                return File(dirInfo.FullName + @"\" + fileName, mimeType);
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
            _confManager.SubmitAbstract(obj);
            var confkey = _confManager.GetConferenceKey(obj.ConferenceId);
            var redirectUrl = Url.RouteUrl(routeName: "SubmitSuccess", routeValues: new { key = confkey });
            return Json(new { Url = redirectUrl });
        }

        [Route("Conference/{key}/SubmitSuccess", Name = "SubmitSuccess")]
        public ActionResult AbstractSubmitSuccess(string key)
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

            var regclass = _confManager.GetConferenceRegClassMapping(id);
            var regTypelst = _confManager.GetConferencePrices(id, regclass);


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

            ViewBag.RegClasslst = regclass;

            var purchase = new PurchaseDTO();
            purchase.Reg = regTypelst;
            purchase.acc = acclst;
            return View(purchase);
        }

        [Route("Conference/{key}/Registration/Success/{regId}")]
        public ActionResult RegistrationSuccess(string key,int regId)
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

        [Route("Conference/{key}/Registration/Fail/{regId}")]
        public ActionResult RegistrationFail(string key, int regId)
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

        [Route("Conference/{key}/Registration/Cancel/{regId}")]
        public ActionResult RegistrationCancel(string key, int regId)
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

        [HttpPost]
        [Route("Conference/RegistrationSubmit")]
        public ActionResult Register(PurchaseDTO obj)
        {
            var regId = _confManager.RegisterForConference(obj);
            if (regId == -1)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Bad Request");

            return RedirectToAction("ValidateCommand", "PayPal", new { RegId = regId });

            //RemotePost myremotepost = new RemotePost();
            //string key = "3wj8Vdij";
            //string salt = "xjqlt4Zeui";

            ////posting all the parameters required for integration.

            //myremotepost.Url = "https://secure.payu.in/_payment";
            //myremotepost.Add("key", key);
            //string txnid = Generatetxnid();
            //myremotepost.Add("txnid", txnid);
            //myremotepost.Add("amount", amount);
            //myremotepost.Add("productinfo", productInfo);
            //myremotepost.Add("firstname", firstName);
            //myremotepost.Add("phone", phone);
            //myremotepost.Add("email", email);
            //myremotepost.Add("surl", surl);//Change the success url here depending upon the port number of your local system.
            //myremotepost.Add("furl", furl);//Change the failure url here depending upon the port number of your local system.
            //myremotepost.Add("service_provider", "payu_paisa");
            //string hashString = key + "|" + txnid + "|" + amount + "|" + productInfo + "|" + firstName + "|" + email + "|||||||||||" + salt;
            ////string hashString = "3Q5c3q|2590640|3053.00|OnlineBooking|vimallad|ladvimal@gmail.com|||||||||||mE2RxRwx";
            //string hash = Generatehash512(hashString);
            //myremotepost.Add("hash", hash);

            //myremotepost.Post();
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
            var id = 0;
            if (!string.IsNullOrEmpty(key))
                id = _confManager.GetConferenceId(key);
            if (id == 0)
                throw new ArgumentException("Conference Not Found", "original");
            ViewData["ConferenceId"] = id;
            ViewData["Conferencekey"] = key;
            var email = _confManager.GetConferenceEmail(id);
            return PartialView("ConferenceEmail", email);
        }

        [Route("Conference/{key}/KeynoteSpeakers")]
        public ActionResult KeynoteSpeakers(string key)
        {
            var id = 0;
            if (!string.IsNullOrEmpty(key))
                id = _confManager.GetConferenceId(key);
            if (id == 0)
                throw new ArgumentException("Conference Not Found", "original");
            ViewData["ConferenceId"] = id;
            ViewData["Conferencekey"] = key;
            return View(_confManager.GetConferenceKeynoteSpeakers(id));
        }

        [Route("Conference/{key}/PartialKeynoteSpeakers")]
        public ActionResult PartialKeynoteSpeakers(string key)
        {
            var id = 0;
            if (!string.IsNullOrEmpty(key))
                id = _confManager.GetConferenceId(key);
            if (id == 0)
                throw new ArgumentException("Conference Not Found", "original");
            ViewData["ConferenceId"] = id;
            ViewData["Conferencekey"] = key;
            return PartialView(_confManager.GetConferenceKeynoteSpeakers(id));
        }

        public string Generatehash512(string text)
        {

            byte[] message = Encoding.UTF8.GetBytes(text);

            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] hashValue;
            SHA512Managed hashString = new SHA512Managed();
            string hex = "";
            hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hex += String.Format("{0:x2}", x);
            }
            return hex;

        }
        public string Generatetxnid()
        {

            Random rnd = new Random();
            string strHash = Generatehash512(rnd.ToString() + DateTime.Now);
            string txnid1 = strHash.ToString().Substring(0, 20);

            return txnid1;
        }
    }
}