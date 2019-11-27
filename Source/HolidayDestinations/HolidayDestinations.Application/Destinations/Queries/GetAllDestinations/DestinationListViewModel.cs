using System;
using System.Collections.Generic;
using System.Text;

namespace HolidayDestinations.Application.Destinations.Queries.GetAllDestinations
{
    public class DestinationsListViewModel
    {
        public IEnumerable<DestinationDto> Destinations { get; set; }
    }
}
