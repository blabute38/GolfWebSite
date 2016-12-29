using Autofac;
using System.Linq;
using System.Reflection;

namespace Golf.RESTService.DependencyInjection
{
    public class ServiceLayerModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.Load(new AssemblyName("Golf.ServiceLayer")))
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
