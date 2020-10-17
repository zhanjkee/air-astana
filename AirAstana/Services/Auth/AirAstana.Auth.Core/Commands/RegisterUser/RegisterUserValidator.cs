using FluentValidation;

namespace AirAstana.Auth.Core.Commands.RegisterUser
{
    public sealed class RegisterUserValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName is required.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required.");
        }
    }
}
