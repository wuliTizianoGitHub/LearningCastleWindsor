using Castle.Windsor;
using Castle.Windsor.Installer;
using LearningCastleWindsor.ToBeSeen.Plumbing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace LearningCastleWindsor.ToBeSeen
{
    public class MvcApplication : System.Web.HttpApplication
    {

        private static IWindsorContainer container;


        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            BootstrapContainer();
        }

        private static void BootstrapContainer()
        {
            container = new WindsorContainer().Install(FromAssembly.This());

            var containerFactory = new WindsorControllerFactory(container.Kernel);

            ControllerBuilder.Current.SetControllerFactory(containerFactory);
        }

        protected void Application_End()
        {
            container.Dispose();
        }
    }
}
