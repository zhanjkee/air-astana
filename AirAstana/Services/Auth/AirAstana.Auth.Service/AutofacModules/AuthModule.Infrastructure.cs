using AirAstana.Auth.Core.Interfaces.Services;
using AirAstana.Auth.Infrastructure.Auth;
using AirAstana.Auth.Infrastructure.Auth.Interfaces;
using Autofac;

namespace AirAstana.Auth.Service.AutofacModules
{
    public partial class AuthModule
    {
        protected void RegisterInfrastructure(ContainerBuilder builder)
        {
            builder.RegisterType<JwtFactory>().As<IJwtFactory>().SingleInstance();
            builder.RegisterType<JwtTokenHandler>().As<IJwtTokenHandler>().SingleInstance();
            builder.RegisterType<TokenFactory>().As<ITokenFactory>().SingleInstance();
            builder.RegisterType<JwtTokenValidator>().As<IJwtTokenValidator>().SingleInstance();
        }
    }
}
