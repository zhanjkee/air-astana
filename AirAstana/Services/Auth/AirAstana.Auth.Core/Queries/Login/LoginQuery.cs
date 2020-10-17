using MediatR;

namespace AirAstana.Auth.Core.Queries.Login
{
    public sealed class LoginQuery : IRequest<LoginResponse>
    {
        public string UserName { get; }
        public string Password { get; }
        public string RemoteIpAddress { get; }
        public string ClientId { get; }

        public LoginQuery(string userName, string password, string remoteIpAddress, string clientId)
        {
            UserName = userName;
            Password = password;
            RemoteIpAddress = remoteIpAddress;
            ClientId = clientId;
        }
    }
}
