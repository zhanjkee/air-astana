using AirAstana.Flights.Core.Models.Locations;
using MediatR;

namespace AirAstana.Flights.Core.Commands.Locations.Update
{
    public sealed class UpdateLocationCommand : IRequest<UpdateLocationResponse>
    {
        public Location Location { get; set; }

        public UpdateLocationCommand(Location location)
        {
            Location = location;
        }
    }
}
