using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading;

namespace AirAstana.Auth.Identity
{
    /// <summary>
    ///     Удостоверение пользователя.
    /// </summary>
    public sealed class UserIdentity : ClaimsIdentity
    {
        /// <summary>
        ///     Конструктор.
        /// </summary>
        /// <param name="id">ID пользователя.</param>        
        /// <param name="userName">Имя пользователя.</param>
        /// /// <param name="name">Логин пользователя.</param>
        /// <param name="zoneInfo">Часовой пояс пользователя.</param>
        /// <param name="locale">Локаль пользователя.</param>
        /// <param name="clientId">ID клиента.</param>
        /// <param name="jwtId">ID токена.</param>
        /// <param name="issuedAt">Дата выдачи токена.</param>
        /// <param name="roles">Роли пользователя.</param>
        public UserIdentity(
           int id,           
           string userName,
           string name,
           string zoneInfo,
           string locale,
           string clientId,
           string jwtId,
           string issuedAt,
           IEnumerable<string> roles)
           : this(new[]
           {
                new Claim(UserIdentityConstants.Id, id.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, userName),
                new Claim(UserIdentityConstants.Name, name),                
                new Claim(UserIdentityConstants.ZoneInfo, zoneInfo),
                new Claim(UserIdentityConstants.Locale, locale),
                new Claim(UserIdentityConstants.ClientId, clientId),
                new Claim(JwtRegisteredClaimNames.Jti, jwtId),
                new Claim(JwtRegisteredClaimNames.Iat, issuedAt),
           }.Concat(roles.Select(r => new Claim(UserIdentityConstants.Role, r))))
        {

        }

        /// <summary>
        ///     Конструктор.
        /// </summary>
        public UserIdentity(IEnumerable<Claim> claims)
            : base(claims, JwtConstants.TokenType, UserIdentityConstants.AuthenticationTypes.Jwt, UserIdentityConstants.Role)
        {

        }

        /// <summary>
        ///     ID пользователя.
        /// </summary>
        public int Id
        {
            get
            {
                var first = FindFirst(UserIdentityConstants.Id);
                if (first == null || !int.TryParse(first.Value, out int result)) return -1;
                return result;
            }
        }

        /// <summary>
        ///     Логин пользователя.
        /// </summary>
        public string UserName
        {
            get
            {
                return FindFirst(JwtRegisteredClaimNames.Sub)?.Value;
            }
        }

        /// <summary>
        ///     Имя пользователя.
        /// </summary>
        public override string Name
        {
            get
            {
                return FindFirst(UserIdentityConstants.Name)?.Value;
            }
        }

        /// <summary>
        ///     Часовой пояс пользователя.
        /// </summary>
        public string ZoneInfo
        {
            get
            {
                return FindFirst(UserIdentityConstants.ZoneInfo)?.Value;
            }
        }

        /// <summary>
        ///     Локаль пользователя.
        /// </summary>
        public string Locale
        {
            get
            {
                return FindFirst(UserIdentityConstants.Locale)?.Value;
            }
        }

        /// <summary>
        ///     Культура пользователя.
        /// </summary>
        public CultureInfo Culture
        {
            get
            {
                if (!string.IsNullOrEmpty(Locale))
                    return new CultureInfo(Locale);

                return Thread.CurrentThread.CurrentCulture;
            }
        }

        /// <summary>
        ///     Срок действия удостоверения.
        /// </summary>
        public DateTime Expires
        {
            get
            {
                return EpochTime.DateTime(Convert.ToInt64(Math.Truncate(Convert.ToDouble(
                    FindFirst(JwtRegisteredClaimNames.Exp)?.Value, CultureInfo.InvariantCulture))));
            }
        }

        /// <summary>
        ///     Роли пользователя.
        /// </summary>
        public IEnumerable<string> Roles
        {
            get
            {
                return FindAll(UserIdentityConstants.Role).Select(c => c.Value);
            }
        }
    }
}
