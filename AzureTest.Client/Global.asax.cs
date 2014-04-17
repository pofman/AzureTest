using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AzureTest.Foundations;
using AzureTest.Model;
using AzureTest.Persistence.Contexts;
using NailsFramework.Config;
using NailsFramework.IoC;
using NailsFramework.Logging;
using NailsFramework.Persistence;
using NailsFramework.UserInterface;

namespace AzureTest.Client
{
    public class WebApiApplication : NailsMvcApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected override void ConfigureNails(INailsConfigurator nails)
        {
            nails.InspectAssemblyOf<SystemDate>()
                .InspectAssemblyOf<Player>()
                .IoC.Container<Unity>()
                .Persistence.DataMapper<EntityFramework>(x => x.Configure<EfContext>())
                .Logging.Logger<Log4net>()
                .Initialize();

        }
    }
}
