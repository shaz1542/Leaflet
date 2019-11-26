using System;

namespace HolidayDestinations.Domain.Entities
{
    public class Destination
    {
        public int Id { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string Note { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
