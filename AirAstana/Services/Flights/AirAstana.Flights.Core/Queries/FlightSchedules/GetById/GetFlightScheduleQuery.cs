using AirAstana.Flights.Core.Models.FlightSchedules;
using MediatR;

namespace AirAstana.Flights.Core.Queries.FlightSchedules.GetById
{
    public sealed class GetFlightScheduleQuery : IRequest<FlightSchedule>
    {
        public int FlightScheduleId { get; set; }

        public GetFlightScheduleQuery(int flightScheduleId)
        {
            FlightScheduleId = flightScheduleId;
        }
    }
}
