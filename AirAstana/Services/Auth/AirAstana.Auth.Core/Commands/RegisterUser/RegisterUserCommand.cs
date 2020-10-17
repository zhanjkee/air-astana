using MediatR;

namespace AirAstana.Auth.Core.Commands.RegisterUser
{
    public sealed class RegisterUserCommand : IRequest<RegisterUserResponse>
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string UserName { get; }
        public string Password { get; }
        public string Locale { get; set; }
        public string ZoneInfo { get; set; }

        public RegisterUserCommand(string firstName, string lastName, string email, string userName, string password, string locale, string zoneInfo)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            UserName = userName;
            Password = password;
            Locale = locale;
            ZoneInfo = zoneInfo;
        }
    }
}
