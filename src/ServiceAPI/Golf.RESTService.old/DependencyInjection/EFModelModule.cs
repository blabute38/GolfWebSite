using Autofac;
using EntityFramework.Toolkit.Core;
using Golf.Model.DbContexts;
using Golf.Repository.Implementations;
using System.Data.Entity;

namespace Golf.RESTService.DependencyInjection
{
    public class EFModelModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new RepositoryModule());

            builder.RegisterType(typeof(GolferContext)).As(typeof(DbContext)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(UnitOfWork)).As(typeof(Repository.Interfaces.IUnitOfWork)).InstancePerLifetimeScope();
            builder.RegisterType<GolferContextDbConnection>().As<IDbConnection>().SingleInstance();
        }
    }
}
