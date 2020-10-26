using System;
using System.Linq.Expressions;
using AirAstana.Flights.Domain.Entities;

namespace AirAstana.Flights.Core.Specifications
{
    public sealed class FlightScheduleSpecification : BaseSpecification<FlightScheduleEntity>
    {
        public FlightScheduleSpecification(int id) : base(u => u.Id == id)
        {
        }

        public FlightScheduleSpecification(Expression<Func<FlightScheduleEntity, bool>> criteria) : base(criteria)
        {
        }
    }
}
