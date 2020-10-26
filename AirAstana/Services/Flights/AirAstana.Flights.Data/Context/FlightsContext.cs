using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AirAstana.Flights.Data.Extensions;
using AirAstana.Flights.Domain.Entities;
using AirAstana.Shared.SeedWork;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AirAstana.Flights.Data.Context
{
    public class FlightsContext : DbContext
    {
        public FlightsContext([NotNull] DbContextOptions options) : base(options)
        {
        }

        protected FlightsContext()
        {
        }

        /// <summary>
        ///     Gets or sets the flights.
        /// </summary>
        public DbSet<FlightEntity> Flights { get; set; }

        /// <summary>
        ///     Gets or sets the locations.
        /// </summary>
        public DbSet<LocationEntity> Locations { get; set; }

        /// <summary>
        ///     Gets or sets the flight schedules.
        /// </summary>
        public DbSet<FlightScheduleEntity> FlightSchedules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var dateTimeUtcConverter = new ValueConverter<DateTime, DateTime>(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Local));
            modelBuilder.UseValueConverterForType<DateTime>(dateTimeUtcConverter);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FlightsContext).Assembly);
        }

        public override int SaveChanges()
        {
            AddAuitInfo();
            return base.SaveChanges();
        }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            AddAuitInfo();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void AddAuitInfo()
        {
            var entries = ChangeTracker.Entries().Where(x => x.Entity is EntityBase && (x.State == EntityState.Added || x.State == EntityState.Modified));
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    ((EntityBase)entry.Entity).CreatedDate = DateTime.UtcNow;
                }
                ((EntityBase)entry.Entity).ModifiedDate = DateTime.UtcNow;
            }
        }
    }
}
