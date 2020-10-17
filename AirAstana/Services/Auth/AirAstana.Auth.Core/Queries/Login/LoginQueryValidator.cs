using FluentValidation;

namespace AirAstana.Auth.Core.Queries.Login
{
    public sealed class LoginQueryValidator : AbstractValidator<LoginQuery>
    {
        public LoginQueryValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName is required.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required.");
        }
    }
}
