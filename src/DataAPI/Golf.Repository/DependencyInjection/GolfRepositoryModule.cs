using Autofac;
using Golf.Repository.Implementations;
using System.Linq;
using System.Reflection;

namespace Golf.Repository.DependencyInjection
{
    public class GolfRepositoryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.Load("Golf.Repository"))
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            builder.RegisterType(typeof(UnitOfWork)).As(typeof(Interfaces.IUnitOfWork)).InstancePerLifetimeScope();
        }
    }
}
