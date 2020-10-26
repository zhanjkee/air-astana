using System;
using System.Threading;
using System.Threading.Tasks;
using AirAstana.Flights.Core.Interfaces.UoW;
using AirAstana.Flights.Core.Mappers;
using JetBrains.Annotations;
using MediatR;

namespace AirAstana.Flights.Core.Commands.Locations.Update
{
    public sealed class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand, UpdateLocationResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateLocationCommandHandler([NotNull] IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<UpdateLocationResponse> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
        {
            var locationRepository = _unitOfWork.LocationRepository;
            var location = await locationRepository.GetByIdAsync(request.Location.Id);
            if (location == null) return Result(false, $"Location does not exists by id: {request.Location.Id}");

            locationRepository.Update(request.Location.ToEntity());
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result(true);
        }

        private static UpdateLocationResponse Result(bool success, string message = null)
        {
            return new UpdateLocationResponse(success, message);
        }
    }
}
