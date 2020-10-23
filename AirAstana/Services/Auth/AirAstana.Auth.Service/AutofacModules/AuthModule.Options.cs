using AirAstana.Auth.Options;
using Autofac;
using Microsoft.Extensions.Configuration;
using AirAstana.Shared.Extensions;

namespace AirAstana.Auth.Service.AutofacModules
{
    public partial class AuthModule
    {
        protected void RegisterOptions(ContainerBuilder builder)
        {
            builder.Register(x =>
            {
                var configuration = x.Resolve<IConfiguration>();
                return configuration.GetValidOptions<AuthOptions>(AuthOptions.SectionName);
            });    
        }
    }
}
