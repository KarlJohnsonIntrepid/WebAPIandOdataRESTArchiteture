using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using System.Web.OData.Builder;
using Lead.Domain;
using System.Web.OData.Extensions;
using Lead.Models.Models;
using Lead.Models.Entities;

namespace Lead.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //We have to define all our returned models here
            var builder = new System.Web.OData.Builder.ODataConventionModelBuilder();

            config.Count().Filter().OrderBy().Expand().Select().MaxTop(null);

            builder.EntitySet<VisitorModel>("visitor");
            builder.EntitySet<OrderModel>("order");


            config.MapODataServiceRoute("odata", "odata" ,builder.GetEdmModel());
        }
    }
}
