﻿using EventManagement.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventManagement.Controllers
{
    public class HomeController : Controller
    {
        private ConferenceManager _confManager;

        public HomeController()
        {
            _confManager = new ConferenceManager();
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PartialHome()
        {
            return PartialView();
        }
        public ActionResult PartialConferences()
        {
            ConferenceManager a = new ConferenceManager();
            var c = a.GetConferences();
            return PartialView(c);
        }

        public ActionResult PartialAboutUs()
        {
            return PartialView();
        }

        public ActionResult PartialRegistrationPolicy()
        {
            return PartialView();
        }

        public ActionResult PartialContactUs()
        {
            return PartialView();
        }

        public ActionResult SponsorExhibitor()
        {
            return View();
        }

        public ActionResult ScientificAdvisors()
        {
            Server.MapPath("");
            var SAlst = _confManager.GetSientificAdvisors();
            return View(SAlst);
        }


        public ActionResult PartialScientificAdvisors()
        {
            var SAlst = _confManager.GetSientificAdvisors();
            return PartialView(SAlst);
        }
    }
}