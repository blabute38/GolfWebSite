﻿using Autofac;
using System.Linq;
using System.Reflection;

namespace Golf.RESTService.DependencyInjection
{
    public class RepositoryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var test = Assembly.Load(new AssemblyName("Golf.Repository"));

            builder.RegisterAssemblyTypes(Assembly.Load(new AssemblyName("Golf.Repository")))
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}