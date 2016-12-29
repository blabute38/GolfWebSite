using Autofac;
using Golf.Model.DbContexts;
using Golf.Repository.Implementations;
using Microsoft.EntityFrameworkCore;

namespace Golf.RESTService.DependencyInjection
{
    public class EFModelModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var optionsBuilder = new DbContextOptionsBuilder<GolferContext>();
            optionsBuilder.UseSqlServer(@"Data Source=mssql4.gear.host;Initial Catalog=golfingmodel;Integrated Security=False;User Id=golfingmodel;Password=Fe1m?7j_UhvR");

            builder.Register(c => 
                {
                    var context = new GolferContext(optionsBuilder.Options);

                    context.Database.Migrate();

                    return context;
                })
                .As<DbContext>()
                .InstancePerLifetimeScope();
            builder.RegisterType(typeof(UnitOfWork)).As(typeof(Repository.Interfaces.IUnitOfWork)).InstancePerLifetimeScope();
        }
    }
}
