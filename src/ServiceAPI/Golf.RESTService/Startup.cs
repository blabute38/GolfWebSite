using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Autofac;
using Golf.RESTService.DependencyInjection;
using Autofac.Extensions.DependencyInjection;
using Golf.RESTService.Configuration;

namespace Golf.RESTService
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

            AutoMapperConfiguration.Configure();
        }

        public IConfigurationRoot Configuration { get; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        //public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            //Create the Autofac container builder.
            var builder = new ContainerBuilder();

            //Add any Autofac modules or registrations.
            builder.RegisterModule(new RepositoryModule());
            builder.RegisterModule(new ServiceLayerModule());
            builder.RegisterModule(new EFModelModule());

            //Populate the services.
            builder.Populate(services);

            //Build the container.
            var container = builder.Build();

            return container.Resolve<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
        }
    }
}
