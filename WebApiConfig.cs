using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Lms
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Enable CORS globally for all origins
            var cors = new EnableCorsAttribute("*", "*", "*");  // Allows all origins, headers, and methods
            config.EnableCors(cors);

            // Web API configuration and services
            config.MapHttpAttributeRoutes();

            // Web API routes
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

