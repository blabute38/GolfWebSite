using Autofac;
using System.Linq;
using System.Reflection;

namespace Golf.ServiceLayer.DependencyInjection
{
    public class GolfServiceLayerModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.Load("Golf.ServiceLayer"))
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
