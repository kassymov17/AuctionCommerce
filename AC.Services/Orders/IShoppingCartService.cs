using System;
using System.Collections.Generic;
using AC.Core.Domain.Catalog;
using AC.Core.Domain.Users;
using AC.Core.Domain.Orders;

namespace AC.Services.Orders
{
    public partial interface IShoppingCartService
    {
        ShoppingCartItem FindShoppingCartItemInTheCart(IList<ShoppingCartItem> shoppingCart,
            ShoppingCartType shoppingCartType,
            Item item);

        IList<string> GetShoppingCartItemWarnings(User user, ShoppingCartType shoppingCartType,
            Item item, int quantity = 1, bool getStandardWarnings = true);

        IList<string> GetStandardWarnings(User user, ShoppingCartType shoppingCartType, Item item, int quantity);

        IList<string> AddToCart(User user, Item item, ShoppingCartType shoppingCartType, int quantity = 1);

        IList<string> PlaceBid(User user, Item item, decimal userEnteredPrice = decimal.Zero);
    }
}
