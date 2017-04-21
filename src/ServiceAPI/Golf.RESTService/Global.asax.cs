using Autofac;
using Autofac.Integration.WebApi;
using Golf.Model.DependencyInjection;
using Golf.Repository.DependencyInjection;
using Golf.RESTService.Configuration;
using Golf.ServiceLayer.DependencyInjection;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace Golf.RESTService
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AutoMapperConfiguration.Configure();

            var builder = new ContainerBuilder();

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            // Add any Autofac modules or registrations.
            builder.RegisterModule(new GolfRepositoryModule());
            builder.RegisterModule(new GolfServiceLayerModule());
            builder.RegisterModule(new GolfModelModule());

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
