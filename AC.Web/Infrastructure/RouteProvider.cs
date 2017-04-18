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

            // shopping cart
            routes.MapRoute("ShoppingCart",
                "cart/",
                new {controller = "ShoppingCart", action = "Cart"},
                new[] { "AC.Web.Controllers" });

            // contact us
            routes.MapRoute("ContactUs",
                "contactus",
                new { controller = "Common", action = "ContactUs" },
                new[] { "AC.Web.Controllers" });

            // product search
            routes.MapRoute("ProductSearch",
                "search/",
                new {controller = "Catalog", action = "Search"},
                new[] {"AC.Web.Controllers"});

            // customer info
            routes.MapRoute("UserInfo",
                "user/info",
                new { controller = "User", action = "Info" },
                new[] { "AC.Web.Controllers" });

            // category
            routes.MapRoute("Category",
                "{SeName}",
                new { controller = "Catalog", action = "Category" },
                new[] { "AC.Web.Controllers" });

            // add item to cart
            routes.MapRoute("AddItemToCart-Catalog", 
                "additemtocart/catalog/{itemId}/{shoppingCartTypeId}/{quantity}",
                new { controller = "ShoppingCart", action = "AddItemToCart_Catalog" },
                new { itemId = @"\d+", shoppingCartTypeId = @"\d+", quantity = @"\d+" },
                new[] { "AC.Web.Controllers" }
                );
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