using HolidayDestinations.Application.Interfaces;
using HolidayDestinations.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
    
namespace HolidayDestinations.Application.Destinations.Commands.CreateDestination
{
    class CreateDestinationCommandHandler: IRequestHandler<CreateDestinationCommand, int>
    {
        private readonly IHolidayDestinationsDbContext _context;

        public CreateDestinationCommandHandler(IHolidayDestinationsDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateDestinationCommand request, CancellationToken cancellationToken)
        {
            var entity = new Destination
            {
                Note =  request.Note,
                Longitude = request.Longitude,
                Latitude = request.Latitude,
            };

            _context.Destinations.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }   
    }
}
