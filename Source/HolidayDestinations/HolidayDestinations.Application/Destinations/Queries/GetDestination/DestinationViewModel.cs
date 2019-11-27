using System;
using System.Collections.Generic;
using System.Text;

namespace HolidayDestinations.Application.Destinations.Queries.GetDestinaton
{
    public class DestinationViewModel
    {
        public int Id { get; set; }
        public string Note { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
