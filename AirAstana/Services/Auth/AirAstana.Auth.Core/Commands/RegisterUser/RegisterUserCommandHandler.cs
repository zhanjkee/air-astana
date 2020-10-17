using AirAstana.Auth.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AirAstana.Auth.Core.Commands.RegisterUser
{
    public sealed class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegisterUserResponse>
    {
        private readonly UserManager<UserEntity> _userManager;

        public RegisterUserCommandHandler(UserManager<UserEntity> userManager)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public async Task<RegisterUserResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var userEntity = new UserEntity(request.FirstName, request.LastName, request.UserName, request.Email);
            var result = await _userManager.CreateAsync(userEntity, request.Password);
            return result.Succeeded ? new RegisterUserResponse(userEntity.Id, true) : new RegisterUserResponse(result.Errors.Select(e => e.Description));
        }
    }
}
