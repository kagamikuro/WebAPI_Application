// <copyright file="WebApiConfig.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WebAPIApp
{
    using System.Web.Http;

    /// <summary>
    /// web API config.
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// router.
        /// </summary>
        /// <param name="config"> HttpConfiguration.</param>
        public static void Register(HttpConfiguration config)
        {
            // Web API configure and server

            // Web API route
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
        }
    }
}
