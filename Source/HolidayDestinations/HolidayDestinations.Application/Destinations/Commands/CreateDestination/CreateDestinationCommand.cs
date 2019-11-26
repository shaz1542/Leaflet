using MediatR;
using System;

namespace HolidayDestinations.Application.Destinations.Commands.CreateDestination
{
    class CreateDestinationCommand : IRequest<int>
    {
        public int Id { get; set; }

        public string Note { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public DateTime TimeStamp { get; set; }

    }
}
