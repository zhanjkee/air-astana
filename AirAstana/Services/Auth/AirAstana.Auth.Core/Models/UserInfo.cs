using System.Collections.Generic;

namespace AirAstana.Auth.Core.Models
{
    public class UserInfo
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Locale { get; set; }
        public string ZoneInfo { get; set; }
        public IEnumerable<string> Roles { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
