using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AzureTest.Client.Controllers;
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
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected override void ConfigureNails(INailsConfigurator nails)
        {
            nails.InspectAssemblyOf<SystemDate>()
                .InspectAssemblyOf<Player>()
                .InspectAssemblyOf<HomeController>()
                .IoC.Container<Unity>()
                .Persistence.DataMapper<EntityFramework>(x => x.Configure<EfContext>())
                .Logging.Logger<Log4net>()
                .Initialize();

        }
    }
}
