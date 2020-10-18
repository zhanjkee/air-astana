using AirAstana.Auth.Data.Abstract;
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
                var configuration = x.Resolve<AuthOptions>();
                var dbContextFactory = new SqlServerDbContextFactory(configuration.ConnectionString);
                return dbContextFactory;
            }).As<IDbContextFactory>().InstancePerLifetimeScope();
        }
    }
}
