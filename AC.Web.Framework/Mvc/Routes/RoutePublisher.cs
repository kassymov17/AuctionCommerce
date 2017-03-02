using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Routing;
using AC.Core.Infrastructure;

namespace AC.Web.Framework.Mvc.Routes
{
    public class RoutePublisher : IRoutePublisher
    {
        protected readonly ITypeFinder typeFinder;

        public RoutePublisher(ITypeFinder typeFinder)
        {
            this.typeFinder = typeFinder;
        }

        /// <summary>
        /// Зарегистрировать маршруты
        /// </summary>
        /// <param name="routes">Коллекция маршрутов</param>
        public virtual void RegisterRoutes(RouteCollection routes)
        {
            var routeProviderTypes = typeFinder.FindClassesOfType<IRouteProvider>();
            var routesProviders = new List<IRouteProvider>();
            foreach(var providerType in routeProviderTypes)
            {
                var provider = Activator.CreateInstance(providerType) as IRouteProvider;
                routesProviders.Add(provider);
            }
            routesProviders = routesProviders.OrderByDescending(rp => rp.Priority).ToList();
            routesProviders.ForEach(rp=>rp.RegisterRoutes(routes));
        }
    }
}
