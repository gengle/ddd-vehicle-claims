using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using DDDUserGroup.App_Start;
using Newtonsoft.Json;

namespace DDDUserGroup
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            JsonSerializerSettings serializerSettings = GlobalConfiguration.Configuration
                .Formatters.JsonFormatter.SerializerSettings;
            serializerSettings.TypeNameHandling = TypeNameHandling.Objects;

            AutofacConfig.ConfigureContainer();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
