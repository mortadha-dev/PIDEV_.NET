using System.Web.Mvc;
using System.Web.Routing;

namespace ConsumeWebServices
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Register", id = UrlParameter.Optional }
            );

            routes.MapRoute(
   name: "customer",
   url: "{controller}/{action}/{id}",
   defaults: new { controller = "Customer", action = "Create", name = UrlParameter.Optional }
);



            routes.MapRoute(
        name: "Edittt",
        url: "{controller}/{action}/{id}",
        defaults: new { controller = "Basket", action = "Edit", name = UrlParameter.Optional }
    );



            routes.MapRoute(
             name: "NOT",
             url: "{controller}/{action}/{userid}",
             defaults: new { controller = "Basket", action = "AddOrEdit", userid = UrlParameter.Optional }
         );

            routes.MapRoute(
               name: "woow",
               url: "{controller}/{action}/{bid}/{pid}",
               defaults: new { controller = "Product", action = "AffecterProductToBasket", bid = UrlParameter.Optional, pid = UrlParameter.Optional }
                  );





        }
    }
}
