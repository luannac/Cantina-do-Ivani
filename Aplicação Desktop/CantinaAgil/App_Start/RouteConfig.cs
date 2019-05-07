﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CantinaAgil
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controllAtendenteser}/{action}/{id}",
                defaults: new { controller = "Log", action = "Initial", id = UrlParameter.Optional }
            );
        }
    }
}
