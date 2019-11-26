using HolidayDestinations.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HolidayDestinations.Application.Destinations.Commands.DeleteDestination
{
    class DeleteDestinationCommandHandler : IRequestHandler<DeleteDestinationCommand>
    {
        private readonly IHolidayDestinationDbContext _context;

        public DeleteDestinationCommandHandler(IHolidayDestinationDbContext context)
        {
            _context = context;
        }
        
        public async Task<Unit> Handle(DeleteDestinationCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Destinations.FindAsync(request.Id);
            if (entity == null)
            {
                //throw NotFound
            }
            _context.Destinations.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
