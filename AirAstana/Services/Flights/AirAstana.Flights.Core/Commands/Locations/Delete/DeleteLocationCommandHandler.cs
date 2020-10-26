using System;
using System.Threading;
using System.Threading.Tasks;
using AirAstana.Flights.Core.Interfaces.UoW;
using JetBrains.Annotations;
using MediatR;

namespace AirAstana.Flights.Core.Commands.Locations.Delete
{
    public sealed class DeleteLocationCommandHandler : IRequestHandler<DeleteLocationCommand, DeleteLocationResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteLocationCommandHandler([NotNull] IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<DeleteLocationResponse> Handle(DeleteLocationCommand request, CancellationToken cancellationToken)
        {
            var locationRepository = _unitOfWork.LocationRepository;
            var location = await locationRepository.GetByIdAsync(request.LocationId);
            if (location == null) return Result(false, $"Location does not exists by id: {request.LocationId}");

            locationRepository.Delete(location);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result(true);
        }

        private static DeleteLocationResponse Result(bool success, string message = null)
        {
            return new DeleteLocationResponse(success, message);
        }
    }
}
