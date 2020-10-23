using Microsoft.AspNetCore.Identity;

namespace AirAstana.Auth.Data.Entities
{
    public sealed class UserEntity : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        private UserEntity() {  }

        public UserEntity(string firstName, string lastName, string userName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Email = email;
        }
    }
}
