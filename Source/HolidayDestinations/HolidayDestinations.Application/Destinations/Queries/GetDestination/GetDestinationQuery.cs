using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HolidayDestinations.Application.Destinations.Queries.GetDestinaton
{
    public class GetDestinationQuery:IRequest<DestinationViewModel>
    {
        public int Id { get; set; }
    }
}
