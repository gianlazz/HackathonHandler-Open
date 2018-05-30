using HackathonManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace HackathonManager.WebMvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static HackathonManager.RepositoryPattern.IRepository _dbRepo = DIContext.Context.GetMLabsMongoDbRepo();
        public static ISmsService _smsService = DIContext.Context.GetTwilioSmsService();
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
