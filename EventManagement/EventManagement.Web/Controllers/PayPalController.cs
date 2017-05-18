using EventManagement.BLL;
using EventManagement.DataModels;
using EventManagement.DataModels.Enum;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventManagement.Controllers
{
    public class PayPalController : Controller
    {
        private readonly ConferenceManager _confManager;
        public PayPalController() {
            _confManager = new ConferenceManager();
        }
        public ActionResult test()
        {
            return View();
        }
        public ActionResult RedirectFromPaypal(int RegId)
        {
            return View();
        }

        public ActionResult CancelFromPaypal()
        {
            return View();
        }

        public ActionResult NotifyFromPaypal()
        {
            return View();
        }

        public ActionResult ValidateCommand(int regId)
        {
            var regDet = _confManager.GetRegistrationDetails(regId);
            var confKey = _confManager.GetConferenceKey(regDet.ConferenceId);
            bool useSandbox = Convert.ToBoolean(ConfigurationManager.AppSettings["IsSandbox"]);
            var baseUrl = string.Format("{0}://{1}{2}", Request.Url.Scheme, Request.Url.Authority, Url.Content("~"));
            var paypal = new PayPalModel(useSandbox)
            {
                business = ConfigurationManager.AppSettings["business"],
                no_shipping = "1",
                @return = baseUrl + string.Format( ConfigurationManager.AppSettings["return"], confKey, regId),
                cancel_return = baseUrl + string.Format(ConfigurationManager.AppSettings["cancel_return"], confKey, regId),
                notify_url = baseUrl + string.Format(ConfigurationManager.AppSettings["notify_url"], confKey, regId),
                currency_code = "USD",
                item_name = regDet.ItemDescription,
                amount = regDet.Amount.ToString()
            };
            _confManager.UpdateRegStatus(regId, RegStatusEnum.InProgress);
;            return PartialView(paypal);
        }
    }
}