using System.Collections.Generic;
using System.Linq;
using AC.Core.Domain.Orders;

namespace AC.Services.Orders
{
    public static class ShoppingCartExtensions
    {
        public static int GetTotalProducts(this IList<ShoppingCartItem> shoppingCart)
        {
            int result = 0;
            foreach (ShoppingCartItem sci in shoppingCart)
            {
                result += sci.Quantity;
            }

            return result;
        }
    }
}
