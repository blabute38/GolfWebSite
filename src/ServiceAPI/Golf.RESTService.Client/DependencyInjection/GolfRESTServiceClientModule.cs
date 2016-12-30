using Autofac;
using Golf.RESTService.Client.Implementations.Generic;
using Golf.RESTService.Client.Implementations.Golfers;
using Golf.RESTService.Client.Interfaces;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Golf.RESTService.Client.DependencyInjection
{
    public class GolfRESTServiceClientModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            builder.Register(c => httpClient).As(typeof(HttpClient)).InstancePerDependency();
            builder.RegisterGeneric(typeof(RetrieveGolfer<>)).As(typeof(IRetrieveEntity<>)).InstancePerLifetimeScope();
        }
    }
}
