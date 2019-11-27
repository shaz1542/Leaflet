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
using HolidayDestinations.Application.Destinations.Queries.GetAllDestinations;

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
            //TODO move serialization in helper
            
            DestinationsListViewModel destinations= new DestinationsListViewModel() { };

            HttpResponseMessage res = await _client.GetAsync("api/HolidayDestinations");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                destinations = JsonConvert.DeserializeObject<DestinationsListViewModel>(result);
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
            //TODO: error handling and logging   
            return Json(new { success = true });
        }
        

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
