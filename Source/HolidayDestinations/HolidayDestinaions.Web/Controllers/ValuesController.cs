using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HolidayDestinations.Persistance;
using MediatR;
using HolidayDestinations.Application.Destinations.Commands.CreateDestination;
using HolidayDestinations.Domain.Entities;
using HolidayDestinations.Application.Interfaces;

namespace HolidayDestinations.Web.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        public IHolidayDestinationsDbContext _context;
        
        public ValuesController(IHolidayDestinationsDbContext context)
        {
            _context = context;
        }
        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<string>> GetAsync()
        {
            // Creates the database if not exists
            var p = _context.Database.EnsureCreated();

            List<Destination> desx = _context.Destinations.ToList();
            return desx.Select(a => a.Note).ToArray<string>();
            
            
            //return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
