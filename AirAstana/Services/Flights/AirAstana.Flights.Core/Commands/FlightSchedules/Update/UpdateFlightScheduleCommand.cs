using AirAstana.Flights.Core.Models.FlightSchedules;
using MediatR;

namespace AirAstana.Flights.Core.Commands.FlightSchedules.Update
{
    public sealed class UpdateFlightScheduleCommand : IRequest<UpdateFlightScheduleResponse>
    {
        public FlightSchedule FlightSchedule { get; set; }

        public UpdateFlightScheduleCommand(FlightSchedule flightSchedule)
        {
            FlightSchedule = flightSchedule;
        }
    }
}
