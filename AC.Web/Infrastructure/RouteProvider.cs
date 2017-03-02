using System.Web.Mvc;
using System.Web.Routing;
using AC.Web.Framework.Mvc.Routes;

namespace AC.Web.Infrastructure
{
    public partial class RouteProvider : IRouteProvider
    {
        public void RegisterRoutes(RouteCollection routes)
        {
            // home page
            routes.MapRoute("HomePage",
                "",
                new { controller = "Home", action = "Index" },
                new[] { "AC.Web.Controllers" });

            // contact us
            routes.MapRoute("ContactUs",
                "contactus",
                new { controller = "Common", action = "ContactUs" },
                new[] { "AC.Web.Controllers" });
        }

        public int Priority
        {
            get
            {
                return 0;
            }
        }
    }
}