using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BookMe.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(name: null,
                            url: "",
                            defaults: new { controller = "Home", action = "Index", search = (string) null, page = 1 });
            routes.MapRoute(name: "ListHotelWithoutSearch",
                            url: "Hotels/{page}",
                            defaults: new { controller = "Hotel", action = "List", category = (string)null },
                            constraints: new { page = @"\d+" }
            );
            routes.MapRoute(name: "ListHotelWithSearch",
                            url: "Hotels/{search}",
                            defaults: new { controller = "Hotel", action = "List", page = 1 }
            );
            routes.MapRoute(name: "HoteListWithPageAndSearch",
                            url: "Hotels/{search}/{page}",
                            defaults: new { controller = "Hotel", action = "List" },
                            constraints: new { page = @"\d+" }
            );
            routes.MapRoute(name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
