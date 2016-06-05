using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using System.Net.Http.Formatting;

namespace UrlShorter
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var xmlFormatter = config.Formatters.XmlFormatter;
            config.Formatters.Remove(xmlFormatter);


            config.Routes.MapHttpRoute(
                name: "redirect",
                routeTemplate: "{id}",
                defaults: new { controller = "reducer", action = "redirect" }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{action}/{id}",
                defaults: new { controller = "home", action = "get", id = RouteParameter.Optional}
            );
        }
    }
}
