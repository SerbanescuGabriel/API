using API.Db.Model;
using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Compilation;
using System.Web.Http;

namespace API.Autofac
{
    public class AutofacConfig
    {
        public static IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }

        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            var config = GlobalConfiguration.Configuration;

            var aseemblyes = BuildManager.GetReferencedAssemblies().Cast<Assembly>().ToArray();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();

            builder.RegisterWebApiFilterProvider(config);

            builder.RegisterWebApiModelBinderProvider();

            builder.RegisterType<LicentaEntities>();

            builder.RegisterAssemblyTypes(aseemblyes)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(aseemblyes)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();

            Container = builder.Build();

            return Container;
        }
    }
}