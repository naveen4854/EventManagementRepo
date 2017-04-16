using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventManagement.Controllers
{
    public class SharedController : Controller
    {
        [Route("Shared/PartialRegistrationPolicy/")]
        public ActionResult PartialRegistrationPolicy()
        {
            return PartialView();
        }

        [Route("Shared/Logo/")]
        public ActionResult Logo()
        {
            return PartialView();
        }


    }
}