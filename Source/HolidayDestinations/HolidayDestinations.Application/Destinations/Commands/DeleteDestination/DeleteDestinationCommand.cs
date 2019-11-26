using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HolidayDestinations.Application.Destinations.Commands.DeleteDestination
{
    class DeleteDestinationCommand : IRequest
    {
        public int Id { get; set; }
    }
}
