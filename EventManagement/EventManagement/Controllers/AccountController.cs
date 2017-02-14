using EventManagement.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EventManagement.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login(User model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            User user = new User() { Email = model.Email, Password = model.Password, Roles = "Admin,Idiot" };

            //user = Repository.GetUserDetails(user);

            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(model.Email, false);

                var authTicket = new FormsAuthenticationTicket(1, user.Email, DateTime.Now, DateTime.Now.AddMinutes(20), false, user.Roles);
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                HttpContext.Response.Cookies.Add(authCookie);
                return RedirectToAction("Index", "Home");
            }

            else
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            //AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}