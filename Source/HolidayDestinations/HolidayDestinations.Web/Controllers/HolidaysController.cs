using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HolidayDestinations.Web.Models;
using HolidayDestinations.Web.Helper;
using System.Net.Http;
using Newtonsoft.Json;

namespace HolidayDestinations.Web.Controllers
{
    public class Destination
    {
        public string Note { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }

    public class HolidaysController : Controller
    {
        HolidayDestinationsApi _api = new HolidayDestinationsApi();

        public async Task<IActionResult> Index()
        {
            //GET ALL THE DESTINATIONS
            List<Destination> destinations = new List<Destination>() { };
            HttpClient client = _api.Initialize();
            HttpResponseMessage res = await client.GetAsync("api/HolidayDestinations");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                destinations = JsonConvert.DeserializeObject<List<Destination>>(result);
            }
            return View(destinations);
        }


        [HttpPost]
        public ActionResult SaveDestination([FromBody]Destination data)
        {
            var p = data;
            ViewData["Message"] = "Your application description page.";
            return Json(new { success = true });
        }

        [HttpPost]
        public ActionResult DeleteDestination(int destinaitonId)
        {
            //CALL THE API CLINET DELETE THE DESTINATION 
            //RERENDER THE PAGE
            return Json(new { success = true });
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
