using EventManagement.BLL;
using EventManagement.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace EventManagement.Controllers
{
    public class SharedController : Controller
    {
        private ConferenceManager _confManager;
        public SharedController()
        {
            _confManager = new ConferenceManager();
        }
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

        [Route("Shared/LoadCountries/")]
        public ActionResult LoadCountries()
        {
            var URL = "https://restcountries.eu/rest/v2/all?fields=name;callingCodes";
            var urlParameters = "";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                var countries = response.Content.ReadAsAsync<IEnumerable<CountryModel>>().Result;
                foreach (var country in countries)
                {
                    _confManager.AddCountry(country);
                }
            }
           
            return PartialView();
        }

        [HttpPost]
        [Route("Shared/GetCountryDetails/{id}")]
        public ActionResult GetCountryDetails(int id)
        {
            var country = _confManager.GetCountryDetails(id);
            return Json(country);
        }
    }
}