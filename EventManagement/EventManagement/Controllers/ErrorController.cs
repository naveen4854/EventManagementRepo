using EventManagement.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventManagement.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index()
        {
			this.ShowMessage(MessageType.Error, "Error message while displaying a partial view.");
            return PartialView();
        }
        public ViewResult ErrMsg(string err)
        {
            return View(err);
        }
        public ViewResult NotFound()
        {
            Response.StatusCode = 404;  //you may want to set this to 200
            return View("NotFound");
        }
    }
}