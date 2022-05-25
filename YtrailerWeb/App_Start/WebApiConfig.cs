using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace YTrailerWeb
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
			config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}",
                defaults: new {  id = RouteParameter.Optional , action = "GetTasks"}
                // defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            //config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
