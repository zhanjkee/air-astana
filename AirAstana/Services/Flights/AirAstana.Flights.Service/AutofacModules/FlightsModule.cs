using AirAstana.Flights.Core.Autofac;
using AirAstana.Flights.Data.Autofac;
using Autofac;

namespace AirAstana.Flights.Service.AutofacModules
{
    public partial class FlightsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            RegisterOptions(builder);
            builder.RegisterModule(new DataModule());
            builder.RegisterModule(new CoreModule());
        }
    }
}
