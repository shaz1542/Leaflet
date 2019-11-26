using HolidayDestinations.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HolidayDestinations.Application.Interfaces
{
    public interface IHolidayDestinationDbContext
    {
        DbSet<Destination> Destinations { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
