using AutoMapper;
using HolidayDestinations.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HolidayDestinations.Application.Destinations.Queries.GetAllDestinations
{
    public class GetAllDestinationsQueryHandler : IRequestHandler<GetAllDestinationsQuery, DestinationsListViewModel>
    {
        private readonly IHolidayDestinationsDbContext _context;
        private readonly IMapper _mapper;


        public GetAllDestinationsQueryHandler(IHolidayDestinationsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<DestinationsListViewModel> Handle(GetAllDestinationsQuery request, CancellationToken cancellationToken)
        {
            var destinations = await _context.Destinations.ToListAsync(cancellationToken);

            var model = new DestinationsListViewModel
            {
                Destinations = _mapper.Map<IEnumerable<DestinationDto>>(destinations),
            };
            return model;
        }
    }
}
