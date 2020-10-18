using AirAstana.Auth.Options;
using Autofac;
using Microsoft.Extensions.Configuration;

namespace AirAstana.Auth.Service.AutofacModules
{
    public partial class AuthModule
    {
        protected void RegisterOptions(ContainerBuilder builder)
        {
            builder.Register(x =>
            {
                var configuration = x.Resolve<IConfiguration>();
                return configuration.Get<AuthOptions>();
            });

            builder.Register(x =>
            {
                var configuration = x.Resolve<IConfiguration>();
                return configuration.Get<JwtIssuerOptions>();
            });
        }
    }
}
