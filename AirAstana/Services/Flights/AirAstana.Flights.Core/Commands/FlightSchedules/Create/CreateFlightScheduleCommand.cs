using AirAstana.Flights.Core.Models.FlightSchedules;
using MediatR;

namespace AirAstana.Flights.Core.Commands.FlightSchedules.Create
{
    public sealed class CreateFlightScheduleCommand : IRequest<CreateFlightScheduleResponse>
    {
        public int FlightId { get; set; }
        public FlightSchedule FlightSchedule { get; set; }

        public CreateFlightScheduleCommand(int flightId, FlightSchedule flightSchedule)
        {
            FlightId = flightId;
            FlightSchedule = flightSchedule;
        }
    }
}
