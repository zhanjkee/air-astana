using IdentityModel;
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
        /// <param name="name">Логин пользователя.</param>
        /// <param name="userName">Имя пользователя.</param>
        /// <param name="zoneInfo">Часовой пояс пользователя.</param>
        /// <param name="locale">Локаль пользователя.</param>
        /// <param name="clientId">ID клиента.</param>
        /// <param name="isAuthorized">Флаг, авторизован ли пользователь в системе.</param>
        /// <param name="roles">Роли пользователя.</param>
        public UserIdentity(
            int id,
           string name,
           string userName,
           string zoneInfo,
           string locale,
           string clientId,
           bool isAuthorized,
           IEnumerable<string> roles)
           : this(new[]
           {
                new Claim(JwtClaimTypes.Id, id.ToString()),
                new Claim(JwtClaimTypes.Name, name),
                new Claim(JwtClaimTypes.Subject, userName),
                new Claim(JwtClaimTypes.ZoneInfo, zoneInfo),
                new Claim(JwtClaimTypes.Locale, locale),
                new Claim(JwtClaimTypes.ClientId, clientId),
                new Claim(UserIdentityClaimsTypes.IsAuthorized, isAuthorized.ToString()),
           }.Concat(roles.Select(r => new Claim(JwtClaimTypes.Role, r))))
        {

        }

        /// <summary>
        ///     Конструктор.
        /// </summary>
        public UserIdentity(IEnumerable<Claim> claims)
            : base(claims, JwtConstants.TokenType, JwtClaimTypes.Name, JwtClaimTypes.Role)
        {

        }

        /// <summary>
        ///     ID пользователя.
        /// </summary>
        public int Id
        {
            get
            {
                var first = FindFirst(JwtClaimTypes.Id);
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
                return FindFirst(JwtClaimTypes.Subject)?.Value;
            }
        }

        /// <summary>
        ///     Имя пользователя.
        /// </summary>
        public override string Name
        {
            get
            {
                return FindFirst(JwtClaimTypes.Name)?.Value;
            }
        }

        /// <summary>
        ///     Часовой пояс пользователя.
        /// </summary>
        public string ZoneInfo
        {
            get
            {
                return FindFirst(JwtClaimTypes.ZoneInfo)?.Value;
            }
        }

        /// <summary>
        ///     Локаль пользователя.
        /// </summary>
        public string Locale
        {
            get
            {
                return FindFirst(JwtClaimTypes.Locale)?.Value;
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
                    FindFirst(JwtClaimTypes.Expiration)?.Value, CultureInfo.InvariantCulture))));
            }
        }

        /// <summary>
        ///     Роли пользователя.
        /// </summary>
        public IEnumerable<string> Roles
        {
            get
            {
                return FindAll(JwtClaimTypes.Role).Select(c => c.Value);
            }
        }
    }
}
