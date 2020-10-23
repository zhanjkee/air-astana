using Autofac;

namespace AirAstana.Auth.Service.AutofacModules
{
    public partial class AuthModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            RegisterOptions(builder);
        }
    }
}
