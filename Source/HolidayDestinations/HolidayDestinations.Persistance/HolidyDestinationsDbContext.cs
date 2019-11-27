using HolidayDestinations.Application.Interfaces;
using HolidayDestinations.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace HolidayDestinations.Persistance
{
    public class HolidayDestinationsDbContext : DbContext, IHolidayDestinationsDbContext
    {
        public HolidayDestinationsDbContext(DbContextOptions<HolidayDestinationsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Destination> Destinations { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Destination>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Note).IsRequired();
                entity.Property(e => e.Latitude).IsRequired();
                entity.Property(e => e.Longitude).IsRequired();
            });
        }
    }
}
