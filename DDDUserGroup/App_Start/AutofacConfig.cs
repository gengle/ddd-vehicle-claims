using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Application.Composition;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;

namespace DDDUserGroup.App_Start
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            // Register dependencies in controllers
            builder.RegisterControllers(typeof(AutofacConfig).Assembly);

            // Register dependencies in filter attributes
            builder.RegisterFilterProvider();

            // Register dependencies in custom views
            builder.RegisterSource(new ViewRegistrationSource());

            // Register our Data dependencies
            builder.RegisterModule(new Application.Composition.CoreModule());
            builder.RegisterModule(new Application.Composition.MessagingModule());
            builder.RegisterModule(new Infrastructure.Persistance.PersistenceModule()
            {
                ConnectionStringOrName = "name=ClaimConnectionString"
            });

            var config = GlobalConfiguration.Configuration;
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(config);

            var container = builder.Build();

            // Set MVC DI resolver to use our Autofac container
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}