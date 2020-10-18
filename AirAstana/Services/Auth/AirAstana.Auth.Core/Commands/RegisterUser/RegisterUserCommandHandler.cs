using AirAstana.Auth.Core.Interfaces.Repositories;
using AirAstana.Auth.Domain.Entities;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AirAstana.Auth.Core.Commands.RegisterUser
{
    public sealed class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegisterUserResponse>
    {
        private readonly IUserRepository _userRepository;

        public RegisterUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<RegisterUserResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var userEntity = new UserEntity(request.FirstName, request.LastName, request.UserName, request.Email);
            var result = await _userRepository.CreateUserAsync(userEntity, request.Password);
            return result.Succeeded ? new RegisterUserResponse(userEntity.Id, true) : new RegisterUserResponse(result.Errors.Select(e => e.Description));
        }
    }
}
