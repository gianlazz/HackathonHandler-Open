using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HackathonManager.TwilioBotWebMvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        //public static HackathonManager.RepositoryPattern.IRepository DbRepo = DIContext.Context.GetLocalMongoDbRepo();
        public static HackathonManager.RepositoryPattern.IRepository DbRepo = DIContext.Context.GetMLabsMongoDbRepo();
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
