using AirAstana.Flights.Domain.Entities;

namespace AirAstana.Flights.Data.Specifications
{
    public sealed class FlightScheduleSpecification : BaseSpecification<FlightScheduleEntity>
    {
        public FlightScheduleSpecification(int id) : base(u => u.Id == id)
        {
            AddInclude(u=>u.Flight);
        }
    }
}
