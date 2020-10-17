using MediatR;

namespace AirAstana.Auth.Core.Commands.ExchangeRefreshToken
{
    public sealed class ExchangeRefreshTokenCommand : IRequest<ExchangeRefreshTokenResponse>
    {
        public string AccessToken { get; }
        public string RefreshToken { get; }
        public string SigningKey { get; }
        public string RemoteIpAddress { get; set; }
        public string ClientId { get; set; }        

        public ExchangeRefreshTokenCommand(string accessToken, string refreshToken, string signingKey, string remoteIpAddress, string clientId)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
            SigningKey = signingKey;
            RemoteIpAddress = remoteIpAddress;
            ClientId = clientId;
        }
    }
}
