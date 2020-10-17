using System.Collections.Generic;

namespace AirAstana.Auth.Core.Models
{
    public class UserInfo
    {
        public string Id { get; }
        public string UserName { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Locale { get; }
        public string ZoneInfo { get; }
        public IEnumerable<string> Roles { get; }

        public UserInfo(string id, string userName, string firstName, string lastName, string locale, string zoneInfo, IEnumerable<string> roles)
        {
            Id = id;
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            Locale = locale;
            ZoneInfo = zoneInfo;
            Roles = roles;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
