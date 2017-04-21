using Autofac;
using Golf.Model.DbContexts;
using System.Data.Entity;

namespace Golf.Model.DependencyInjection
{
    public class GolfModelModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType(typeof(GolferContext)).As(typeof(DbContext)).InstancePerLifetimeScope();
        }
    }
}
