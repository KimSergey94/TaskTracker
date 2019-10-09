using BLL_TaskTracker.Infrastructure;
using DAL_TaskTracker.EF;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TaskTracker.Util;

namespace TaskTracker
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            System.Data.Entity.Database.SetInitializer<TaskTrackerContext>(new TaskTrackerDbInitializer());
            var db = new TaskTrackerContext("TaskTrackerDb");
            db.Database.Initialize(true);

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            ModelValidatorProviders.Providers.Clear();


            NinjectModule orderModule = new OrderModule();
            NinjectModule serviceModule = new ServiceModule("TaskTrackerDb");
            var kernel = new StandardKernel(orderModule, serviceModule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));

            
        }
    }
}
