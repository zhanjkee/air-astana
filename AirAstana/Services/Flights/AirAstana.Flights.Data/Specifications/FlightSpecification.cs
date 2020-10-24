using AirAstana.Flights.Domain.Entities;

namespace AirAstana.Flights.Data.Specifications
{
    public sealed class FlightSpecification : BaseSpecification<FlightEntity>
    {
        public FlightSpecification(int id) : base(u => u.Id == id)
        {
            AddInclude(u=>u.Destination);
            AddInclude(u=>u.Source);
            AddInclude(u => u.Schedules);
        }
    }
}
