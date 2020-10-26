using System;
using MediatR;

namespace AirAstana.Flights.Core.Commands.FlightSchedules.AddDelay
{
    public sealed class AddDelayFlightScheduleCommand : IRequest<AddDelayFlightScheduleResponse>
    {
        public int FlightScheduleId { get; set; }
        public TimeSpan Delay { get; set; }
        public AddDelayFlightScheduleCommand(int flightScheduleId, TimeSpan delay)
        {
            FlightScheduleId = flightScheduleId;
            Delay = delay;
        }
    }
}
