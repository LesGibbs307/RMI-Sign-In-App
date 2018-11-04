using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RmiOnLocation.Web {
    public class RouteConfig {
        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                "Submit Info", // Route name
                "visitor/submit-info/", // URL with parameters
                new { controller = "Visitor", action = "SubmitInfo" } // Parameter defaults
            );

			routes.MapRoute(
				"SignOutList", // Route name
				"visitor/signoutlist/", // URL with parameters
				new { controller = "Visitor", action = "SignOutList" } // Parameter defaults
			);

			routes.MapRoute(
				"VisitorSignOut", // Route name
				"visitor/signout/", // URL with parameters
				new { controller = "Visitor", action = "SignOut" } // Parameter defaults
			);

            routes.MapRoute(
                "Thank You",
                "thank-you/",
                new { controller = "Visitor", action = "ThankYou" }
            );

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Visitor", action = "Index", id = UrlParameter.Optional }
			);
        }
    }
}
