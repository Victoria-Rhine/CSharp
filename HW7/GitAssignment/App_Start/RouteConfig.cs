using System.Web.Mvc;
using System.Web.Routing;

namespace GitAssignment
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // custom route requirement
            routes.MapRoute(
               name: "GitCommitInfo",
               url: "api/{action}/{id}",
               defaults: new { controller = "Home", action = "commits?user={user}&repo={repo}", id = UrlParameter.Optional }
           );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}