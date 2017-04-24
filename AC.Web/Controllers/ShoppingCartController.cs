using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AC.Core;
using AC.Core.Domain.Catalog;
using AC.Core.Domain.Users;
using AC.Core.Domain.Orders;
using AC.Services.Catalog;
using AC.Services.Localization;
using AC.Services.Media;
using AC.Services.Orders;

namespace AC.Web.Controllers
{
    public partial class ShoppingCartController : Controller
    {
        #region Поля

        private readonly IItemService _itemService;
        private readonly IWorkContext _workContext;
        private readonly IPictureService _pictureService;
        private readonly ILocalizationService _localizationService;
        private readonly IShoppingCartService _shoppingCartService; 

        #endregion

        #region Конструктор

        public ShoppingCartController(IItemService itemService, IWorkContext workContext, IPictureService pictureService,
            ILocalizationService localizationService, IShoppingCartService shoppingCartService)
        {
            _itemService = itemService;
            _workContext = workContext;
            _pictureService = pictureService;
            _localizationService = localizationService;
            _shoppingCartService = shoppingCartService;
        }

        #endregion

        #region Методы

        [HttpPost]
        public ActionResult AddItemToCart_Catalog(int itemId, int shoppingCartTypeId, int quantity)
        {
            var cartType = (ShoppingCartType) shoppingCartTypeId;

            var item = _itemService.GetItemById(itemId);

            if (item == null)
                return Json(new
                {
                    success = false,
                    message = "не найден товар с таким id"
                });

            if (item.ItemType != ItemType.ShopItem)
            {
                return Json(new
                {
                    redirect = Url.RouteUrl("Item", new { itemId = item.Id })
                });
            }
            
            // [todo] добавление в корзину товара с атрибутами
            var cart = _workContext.CurrentUser.ShoppingCartItems
                .Where(sci => sci.ShoppingCartType == cartType)
                .ToList();

            var shoppingCartItem = _shoppingCartService.FindShoppingCartItemInTheCart(cart, cartType, item);
            // если товар уже есть в корзине
            var quantityToValidate = shoppingCartItem != null ? shoppingCartItem.Quantity + quantity : quantity;
            var addToCartWarnings = _shoppingCartService.GetShoppingCartItemWarnings(_workContext.CurrentUser, cartType,
                item, quantityToValidate, true);
            if (addToCartWarnings.Any())
            {
                return Json(new
                {
                    success = false,
                    message = addToCartWarnings.ToArray()
                });
            }

            // добавить товар в корзину
            addToCartWarnings = _shoppingCartService.AddToCart(user: _workContext.CurrentUser,
                item: item,
                shoppingCartType: cartType,
                quantity: quantity);

            if (addToCartWarnings.Any())
            {
                return Json(new
                {
                    redirect = Url.RouteUrl("Item", new {itemId = item.Id})
                });
            }

            switch (cartType)
            {
                case ShoppingCartType.Wishlist:
                {
                    return Json(new
                    {
                        success = true,
                        message = "",
                        updatetopwishlistsectionhtml = ""
                    });
                }
                case ShoppingCartType.ShoppingCart:
                default:
                {
                    // показать уведомления
                    var updatetopcartsectionhtml = string.Format(_localizationService.GetResource("ShoppingCart.HeaderQuantity"),
                            _workContext.CurrentUser.ShoppingCartItems
                            .Where(sci => sci.ShoppingCartType == ShoppingCartType.ShoppingCart)
                            .ToList()
                            .GetTotalProducts());

                    var updateflyoutcartsectionhtml = "";

                    return Json(new
                    {
                        success = true,
                        message = string.Format(_localizationService.GetResource("Products.ProductHasBeenAddedToTheCart.Link"), Url.RouteUrl("ShoppingCart")),
                        updatetopcartsectionhtml = updatetopcartsectionhtml,
                        updateflyoutcartsectionhtml = updateflyoutcartsectionhtml
                    });
                }
            }
        }

        [HttpPost]
        public ActionResult PlaceBid(int itemId, FormCollection form)
        {
            if (!_workContext.CurrentUser.IsRegistered())
            {     return Json(new
                {
                    redirect = Url.RouteUrl("Login")
                });
            }
            var item = _itemService.GetItemById(itemId);
            if (item == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Позволяется делать ставки только на товара типа аукцион"
                });
            }
            if (item.UserId == _workContext.CurrentUser.Id)
            {
                return Json(new
                {
                    success = false,
                    message = "Вы являетесь владельцем лота"
                });
            }
            if (!(item.AuctionStartDate <= DateTime.UtcNow && item.AuctionEndDate >= DateTime.UtcNow))
            {
                return Json(new
                {
                    success = false,
                    message = "Время аукциона закончилось"
                });
            }

            // ставка
            decimal userEnteredPrice = decimal.Zero;
            foreach (string formKey in form.AllKeys)
            {
                decimal.TryParse(form[formKey], out userEnteredPrice);
            }

            var placeBidWarnings = new List<string>();
            placeBidWarnings.AddRange(_shoppingCartService.PlaceBid(_workContext.CurrentUser, item, userEnteredPrice));

            if (placeBidWarnings.Any())
            {
                return Json(new
                {
                    success = false,
                    message = placeBidWarnings.ToArray()
                });
            }

            return Json(new
            {
                success = true,
                message = string.Format(_localizationService.GetResource("Products.BidHasBeenPlaced.Link"), Url.RouteUrl("UserInfo"))
            });
        }

        #endregion
    }
}