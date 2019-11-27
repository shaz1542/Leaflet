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
using System.Threading;

namespace HolidayDestinations.Web.Controllers
{
    [Route("api/[controller]")]
    public class HolidayDestinationsController : Controller
    {
        public IHolidayDestinationsDbContext _context;
        
        public HolidayDestinationsController(IHolidayDestinationsDbContext context)
        {
            _context = context;
        }
        // GET api/values
        [HttpGet]
        public  IEnumerable<Destination> GetAsync(CancellationToken cancellationToken)
        {
            // Creates the database if not exists
            var p = _context.Database.EnsureCreated();
            //GET ALL THE saved destinations fro the db
            List<Destination> desx = _context.Destinations.ToList();
            return desx;
        }


        // POST api/values
        [HttpPost]
        public  void PostAsync([FromBody]Destination value,CancellationToken cancellationToken)
        {
            //GET the destination Model
            int count = _context.Destinations.Count();
            Destination d = new Destination()
            {
                Note = value.Note,
                Latitude = value.Latitude,
                Longitude = value.Longitude
            };
            _context.Destinations.AddAsync(d);
            _context.SaveChangesAsync(cancellationToken);
            
        }
        
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
