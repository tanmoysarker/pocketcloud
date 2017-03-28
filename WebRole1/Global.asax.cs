using System.Web.Mvc;
<%System.Net.Mime.MediaTypeNames.@Application Codebehind = "Global.asax.cs", Inherits = "pocketCloud.WebApiApplication" < Language = "C#" %>;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;


namespace pocketCloud
{
    public class WebApiApplication:System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            System.Web.Http.GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(System.Web.Routing.RouteTable.Routes);
            BundleConfig.RegisterBundles(System.Web.Optimization.BundleTable.Bundles);
        }
    }
}
