using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;

namespace ChessHostService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{action}",
            //    defaults: new { action = Rou }
            //);

            config.Routes.MapHttpRoute("StartGame", "api/game/start", new { controller = "Game", action = "Start" });
            config.Routes.MapHttpRoute("CheckGame", "api/game/{id}", new { controller = "Game", action = "Get", id = RouteParameter.Optional });


            config.Routes.MapHttpRoute(
                name: "GameId",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
        }
    }
}
