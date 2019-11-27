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
using System.Net.Http.Headers;

namespace HolidayDestinations.Web.Controllers
{
    public class HolidaysController : Controller
    {
        private HttpClient _client { get; set; }

        public HolidaysController()
        {
            _client = new HolidayDestinationsApi().Initialize();
        }
        
        public async Task<IActionResult> Index()
        {
            //GET ALL THE DESTINATIONS
            List<Destination> destinations = new List<Destination>() { };

            HttpResponseMessage res = await _client.GetAsync("api/HolidayDestinations");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                destinations = JsonConvert.DeserializeObject<List<Destination>>(result);
            }
            return View(destinations);
        }


        [HttpPost]
        public async Task<ActionResult> SaveDestination([FromBody]Destination data)
        {
            var destination = JsonConvert.SerializeObject(data);
            var buffer = System.Text.Encoding.UTF8.GetBytes(destination);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage res = await _client.PostAsync("api/HolidayDestinations", byteContent);
            
            if (res.IsSuccessStatusCode)
            {
                //rerender OR Redirect to the Index
            }
            
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
