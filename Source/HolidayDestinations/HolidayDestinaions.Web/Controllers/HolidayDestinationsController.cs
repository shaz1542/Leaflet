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
using HolidayDestinations.Application.Destinations.Queries.GetAllDestinations;

namespace HolidayDestinations.Web.Controllers
{
    [Route("api/[controller]")]
    public class HolidayDestinationsController : BaseController
    {
        public HolidayDestinationsController()
        {
            
        }

        [HttpGet]
        public async Task<DestinationsListViewModel> GetAll()
        {
            // Creates the database if not exists
            return await Mediator.Send(new GetAllDestinationsQuery());
        }
        
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateDestinationCommand command)
        {
            var DestinationId = await Mediator.Send(command);

            return Ok(DestinationId);
        }
        /*
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
         */
    }
}
