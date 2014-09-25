using System.Web.Mvc;
using System.Web.Routing;

namespace Taksopark.MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Account/RegisterUser",
                url: "register",
                defaults: new { controller = "Account", action = "RegisterUser" }
            );

            routes.MapRoute(
                name: "UserProfile/GetUserHistory",
                url: "orders",
                defaults: new { controller = "UserProfile", action = "GetUserHistory" }
            );


            //UserProfile/GetUserProfile

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
