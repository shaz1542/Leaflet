using HolidayDestinations.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HolidayDestinations.Application.Destinations.Queries.GetDestinaton
{
    public class GetDestinationQueryHandler : MediatR.IRequestHandler<GetDestinationQuery, DestinationViewModel>
    {
        private readonly IHolidayDestinationsDbContext _context;

        public GetDestinationQueryHandler(IHolidayDestinationsDbContext context)
        {
            _context = context;
        }
        
        public async Task<DestinationViewModel> Handle(GetDestinationQuery request, CancellationToken cancellationToken)
        {
            var destination =
                await _context.Destinations.Where(d => d.Id == request.Id).SingleOrDefaultAsync(cancellationToken);

            if (destination == null)
            {
                throw new Exception();
            }
            DestinationViewModel dvm = new DestinationViewModel()
            {
                Id = destination.Id,
                Latitude = destination.Latitude,
                Longitude = destination.Longitude
            };
            return dvm;
        }
    }
}
