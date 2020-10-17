using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AirAstana.Auth.Domain.Entities
{
    public class UserEntity : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        private UserEntity() { /* Required by EF */ }

        public UserEntity(string firstName, string lastName, string userName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Email = email;
        }

        private readonly List<RefreshTokenEntity> _refreshTokens = new List<RefreshTokenEntity>();
        public IReadOnlyCollection<RefreshTokenEntity> RefreshTokens => _refreshTokens.AsReadOnly();

        public bool HasValidRefreshToken(string refreshToken)
        {
            return _refreshTokens.Any(rt => rt.Token == refreshToken && rt.Active);
        }

        public void AddRefreshToken(string token, string userId, string remoteIpAddress, double daysToExpire = 5)
        {
            _refreshTokens.Add(new RefreshTokenEntity(token, DateTime.UtcNow.AddDays(daysToExpire), userId, remoteIpAddress));
        }

        public void RemoveRefreshToken(string refreshToken)
        {
            _refreshTokens.Remove(_refreshTokens.First(t => t.Token == refreshToken));
        }
    }
}
