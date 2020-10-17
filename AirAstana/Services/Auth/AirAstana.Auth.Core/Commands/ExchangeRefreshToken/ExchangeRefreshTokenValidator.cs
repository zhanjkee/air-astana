using FluentValidation;

namespace AirAstana.Auth.Core.Commands.ExchangeRefreshToken
{
    public sealed class ExchangeRefreshTokenValidator : AbstractValidator<ExchangeRefreshTokenCommand>
    {
        public ExchangeRefreshTokenValidator()
        {
            RuleFor(x => x.AccessToken).NotEmpty().WithMessage("AccessToken is required.");
            RuleFor(x => x.RefreshToken).NotEmpty().WithMessage("RefreshToken is required.");
            RuleFor(x => x.SigningKey).NotEmpty().WithMessage("SigningKey is required.");
        }
    }
}
