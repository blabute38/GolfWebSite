using Autofac;
using Golf.RESTService.Client.Implementations.Golfers;
using Golf.RESTService.Client.Interfaces;
using System.Net.Http;

namespace Golf.RESTService.Client.DependencyInjection
{
    public class GolfRESTServiceClientModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new HttpClient()).As(typeof(HttpClient)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(CreateGolfer<>)).As(typeof(ICreateEntity<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(RetrieveGolfer<>)).As(typeof(IRetrieveEntity<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(UpdateGolfer<>)).As(typeof(IUpdateEntity<>)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(DeleteGolfer)).As(typeof(IDeleteEntity)).InstancePerLifetimeScope();
        }
    }
}
