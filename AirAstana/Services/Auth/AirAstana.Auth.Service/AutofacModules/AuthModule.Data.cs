using AirAstana.Auth.Data.Abstract;
using AirAstana.Auth.Data.Context;
using AirAstana.Auth.Data.SqlServer;
using AirAstana.Auth.Options;
using Autofac;

namespace AirAstana.Auth.Service.AutofacModules
{
    public partial class AuthModule
    {
        protected void RegisterData(ContainerBuilder builder)
        {
            builder.Register(x =>
            {
                var configuration = x.Resolve<ServiceOptions>();
                var dbContextFactory = new SqlServerDbContextFactory(configuration.ConnectionString);
                return dbContextFactory.Create();
            }).As<ApplicationDbContext>().InstancePerLifetimeScope();
        }
    }
}
