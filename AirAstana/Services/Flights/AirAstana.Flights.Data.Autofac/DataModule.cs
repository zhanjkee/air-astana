using AirAstana.Flights.Core.Interfaces.Repositories;
using AirAstana.Flights.Data.Abstract;
using AirAstana.Flights.Data.Context;
using AirAstana.Flights.Data.Repositories;
using AirAstana.Flights.Data.SqlServer;
using AirAstana.Flights.Options;
using Autofac;

namespace AirAstana.Flights.Data.Autofac
{
    public class DataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(x =>
            {
                var configuration = x.Resolve<FlightsOptions>();
                return new SqlServerDbContextFactory(configuration.ConnectionString);
            }).As<IDbContextFactory>().InstancePerLifetimeScope();

            builder.Register(x =>
            {
                var configuration = x.Resolve<FlightsOptions>();
                var dbContextFactory = new SqlServerDbContextFactory(configuration.ConnectionString);
                return dbContextFactory.Create();
            }).As<FlightsContext>().InstancePerLifetimeScope();

            builder.RegisterType<FlightRepository>().As<IFlightRepository>().InstancePerLifetimeScope();
            builder.RegisterType<LocationRepository>().As<ILocationRepository>().InstancePerLifetimeScope();
        }
    }
}
