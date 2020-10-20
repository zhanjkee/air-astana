using AirAstana.Flights.Core.Models.Locations;
using MediatR;

namespace AirAstana.Flights.Core.Commands.Locations.Create
{
    public sealed class CreateLocationCommand : IRequest<CreateLocationResponse>
    {
        public Location Location { get; set; }

        public CreateLocationCommand(Location location)
        {
            Location = location;
        }
    }
}
