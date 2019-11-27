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
            return await Mediator.Send(new GetAllDestinationsQuery());
        }
        
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateDestinationCommand command)
        {
            var DestinationId = await Mediator.Send(command);

            return Ok(DestinationId);
        }
        
    }
}
