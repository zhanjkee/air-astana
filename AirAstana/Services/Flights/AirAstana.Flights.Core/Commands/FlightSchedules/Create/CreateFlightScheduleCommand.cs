using AirAstana.Flights.Core.Models.FlightSchedules;
using MediatR;

namespace AirAstana.Flights.Core.Commands.FlightSchedules.Create
{
    public sealed class CreateFlightScheduleCommand : IRequest<CreateFlightScheduleResponse>
    {
        public FlightSchedule FlightSchedule { get; set; }

        public CreateFlightScheduleCommand(FlightSchedule flightSchedule)
        {
            FlightSchedule = flightSchedule;
        }
    }
}
