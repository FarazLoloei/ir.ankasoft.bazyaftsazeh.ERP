using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //AreaRegistration.RegisterAllAreas();
            //RouteConfig.RegisterRoutes(RouteTable.Routes);

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //AutoMapperConfig.Init();
            AutoMapperConfig.RegisterMappings();
        }
    }
}