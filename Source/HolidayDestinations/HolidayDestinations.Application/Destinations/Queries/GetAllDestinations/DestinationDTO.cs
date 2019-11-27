using AutoMapper;
using HolidayDestinations.Application.Interfaces.Mapping;
using HolidayDestinations.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HolidayDestinations.Application.Destinations.Queries.GetAllDestinations
{
    public class DestinationDto :IHaveCustomMapping
    { 
        public string Note { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Destination, DestinationDto>()
                .ForMember(pDTO => pDTO.Note, opt => opt.MapFrom(p => p.Note))
                .ForMember(pDTO => pDTO.Latitude, opt => opt.MapFrom(p => p.Latitude))
                .ForMember(pDTO => pDTO.Longitude, opt => opt.MapFrom(p => p.Longitude));
                
        }   
    }
}
