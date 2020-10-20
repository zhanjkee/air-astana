using MediatR;

namespace AirAstana.Flights.Core.Commands.Locations.Delete
{
    public sealed class DeleteLocationCommand : IRequest<DeleteLocationResponse>
    {
        public int LocationId { get; set; }

        public DeleteLocationCommand(int locationId)
        {
            LocationId = locationId;
        }
    }
}
