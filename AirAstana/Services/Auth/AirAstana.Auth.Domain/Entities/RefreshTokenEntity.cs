using AirAstana.Shared.SeedWork;
using System;

namespace AirAstana.Auth.Domain.Entities
{
    public sealed class RefreshTokenEntity : EntityBase
    {
        public string Token { get; private set; }
        public DateTime Expires { get; private set; }
        public string UserId { get; private set; }
        public bool Active => DateTime.UtcNow <= Expires;
        public string RemoteIpAddress { get; private set; }

        public RefreshTokenEntity(string token, DateTime expires, string userId, string remoteIpAddress)
        {
            Token = token;
            Expires = expires;
            UserId = userId;
            RemoteIpAddress = remoteIpAddress;
        }
    }
}
