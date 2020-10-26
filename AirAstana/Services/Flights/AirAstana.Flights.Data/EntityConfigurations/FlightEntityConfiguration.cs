using AirAstana.Flights.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirAstana.Flights.Data.EntityConfigurations
{
    public class FlightEntityConfiguration : EntityBaseConfiguration<FlightEntity>
    {
        public override void ConfigureEntity(EntityTypeBuilder<FlightEntity> builder)
        {
            builder.HasMany(x => x.Schedules)
                .WithOne(x => x.Flight)
                .HasForeignKey(x => x.FlightId);

            builder.HasOne(x => x.Source)
                .WithMany(x=>x.SourceFlights)
                .HasForeignKey(x=>x.SourceId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(x => x.Destination)
                .WithMany(x=>x.DestinationFlights)
                .HasForeignKey(x=>x.DestinationId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }
    }
}
