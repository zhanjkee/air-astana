using AirAstana.Flights.Options;
using AirAstana.Shared.Extensions;
using Autofac;
using Microsoft.Extensions.Configuration;

namespace AirAstana.Flights.Service.AutofacModules
{
    public partial class FlightsModule
    {
        protected void RegisterOptions(ContainerBuilder builder)
        {
            builder.Register(x =>
            {
                var configuration = x.Resolve<IConfiguration>();
                return configuration.GetValidOptions<FlightsOptions>(FlightsOptions.SectionName);
            });
        }
    }
}
