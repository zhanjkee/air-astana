using AirAstana.Flights.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirAstana.Flights.Data.EntityConfigurations
{
    public class FlightEntityConfiguration : EntityBaseConfiguration<FlightEntity>
    {
        public override void ConfigureEntity(EntityTypeBuilder<FlightEntity> builder)
        {
            builder.HasMany(x => x.Schedules).WithOne(x => x.Flight).HasForeignKey(x => x.FlightId);
        }
    }
}
