using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;
using Nop.Web.Framework.Localization;
using Nop.Web.Framework.Mvc.Routing;
using Nop.Web.Framework.Seo;

namespace Nop.Plugin.Misc.Cms.Infrastructure
{
    public class RouteProvider : IRouteProvider
    {
        public void RegisterRoutes(IRouteBuilder routeBuilder)
        {

            //routeBuilder.MapGenericPathRoute("CmsTopic", "{SeName}",
            //    new { controller = "CmsTopic", action = "TopicDetails" });

            routeBuilder.MapLocalizedRoute("CmsTopic", "{SeName}",
                new { controller = "CmsTopic", action = "TopicDetails" },
                new {},
                new [] { "Nop.Plugin.Misc.Cms.Controllers" });



            //routeBuilder.Routes.Remove(route);
            //routeBuilder.Routes.Insert(0, route);
        }

        public int Priority {
            get
            {
                return 100;
            } 
        } 
    }
}
