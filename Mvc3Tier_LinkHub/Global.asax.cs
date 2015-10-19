using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.Web.WebPages.OAuth;

namespace Mvc3Tier_LinkHub
{
    public class MvcApplication : HttpApplication
    {

        public class OAuthConfig
        {
            public static void RegisterProviders()
            {
                OAuthWebSecurity.RegisterGoogleClient();
            }
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalFilters.Filters.Add(new AuthorizeAttribute()); // this block the whole application]

            OAuthConfig.RegisterProviders();
        }
    }
}
