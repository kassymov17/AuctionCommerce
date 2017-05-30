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
                new { controller = "ShoppingCart", action = "Cart" },
                new[] { "AC.Web.Controllers" });

            // item
            routes.MapRoute("Item",
                "item/{itemId}",
                new { controller = "Item", action = "ItemDetails" },
                new { itemId = @"\d+" },
                new[] { "AC.Web.Controllers" });
            
            // login
            routes.MapRoute("Login",
                "login/",
                new { controller = "User", action = "Login" },
                new[] { "AC.Web.Controllers" }
            );

            // logout
            routes.MapRoute("Logout",
                "logout/",
                new { controller = "User", action = "Logout" },
                new[] { "AC.Web.Controllers" });
                
            // register
            routes.MapRoute("Register",
                "register/",
                new { controller = "User", action = "Register" },
                new[] { "AC.Web.Controllers" }
            );

            // register result
            routes.MapRoute("RegisterResult",
                "registerresult/",
                new { controller = "User", action = "RegisterResult" },
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

            // account
            routes.MapRoute("AddItem",
                "user/additem",
                new {controller = "User", action = "AddItem"},
                new[] {"AC.Web.Controllers"});

            routes.MapRoute("MyItems",
                "user/myitems",
                new { controller = "User", action = "MyItems" },
                new[] { "AC.Web.Controllers" });

            routes.MapRoute("MyBids",
                "user/mybids",
                new { controller = "User", action = "MyBids" },
                new[] { "AC.Web.Controllers" });

            routes.MapRoute("UserOrders",
                "account/myorders",
                new { controller = "Order", action = "UserOrders" },
                new[] { "AC.Web.Controllers" });

            routes.MapRoute("WonBids",
                "user/wonbids",
                new { controller = "User", action = "WonBids" },
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

            // place a bid
            routes.MapRoute("BidForItem",
                "bidforitem/item/{itemId}",
                new { controller = "ShoppingCart", action = "PlaceBid" },
                new { itemId = @"\d+" },
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