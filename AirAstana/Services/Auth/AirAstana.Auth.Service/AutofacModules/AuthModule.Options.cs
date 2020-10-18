using AirAstana.Auth.Options;
using Autofac;
using Microsoft.Extensions.Configuration;
using AirAstana.Shared.Extensions;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AirAstana.Auth.Service.AutofacModules
{
    public partial class AuthModule
    {
        protected void RegisterOptions(ContainerBuilder builder)
        {
            SecurityKey signingKey = null;

            builder.Register(x =>
            {
                var configuration = x.Resolve<IConfiguration>();
                var serviceOptions = configuration.GetValidOptions<ServiceOptions>(ServiceOptions.SectionName);
                signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(serviceOptions.SecretKey));
                return serviceOptions;

            });

            builder.Register(x =>
            {
                var configuration = x.Resolve<IConfiguration>();
                var jwtIssuerOptions = configuration.GetValidOptions<JwtIssuerOptions>(JwtIssuerOptions.SectionName);
                jwtIssuerOptions.SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
                return jwtIssuerOptions;
            });          
        }
    }
}
