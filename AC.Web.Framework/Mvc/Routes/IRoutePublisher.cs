using System.Web.Routing;

namespace AC.Web.Framework.Mvc.Routes
{
    public interface IRoutePublisher
    {
        void RegisterRoutes(RouteCollection routes);
    }
}
