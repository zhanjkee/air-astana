using System;
using System.Threading;
using System.Threading.Tasks;
using AirAstana.Flights.Core.Interfaces.UoW;
using AirAstana.Flights.Core.Mappers;
using JetBrains.Annotations;
using MediatR;

namespace AirAstana.Flights.Core.Commands.Locations.Create
{
    public sealed class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand, CreateLocationResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateLocationCommandHandler([NotNull] IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<CreateLocationResponse> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
            var locationRepository = _unitOfWork.LocationRepository;
            await locationRepository.InsertAsync(request.Location.ToEntity(), cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result(true);
        }

        private static CreateLocationResponse Result(bool success, string message = null)
        {
            return new CreateLocationResponse(success, message);
        }
    }
}
