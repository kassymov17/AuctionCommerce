using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AC.Core;
using AC.Core.Domain.Orders;
using AC.Web.Models.Checkout;

namespace AC.Web.Controllers
{
    public class CheckoutController : Controller
    {
        #region Поля

        private readonly IWorkContext _workContext;

        #endregion

        #region Конструктор

        public CheckoutController(IWorkContext workContext)
        {
            _workContext = workContext;
        }

        #endregion

        #region Вспомогательные методы

        protected virtual AddressModel PrepareBillingAddressModel(IList<ShoppingCartItem> items)
        {
            var model = new AddressModel();
            return model;
        }

        #endregion

        public ActionResult Index()
        {
            // валидация
            var cart = _workContext.CurrentUser.ShoppingCartItems
                .Where(sci => sci.ShoppingCartType == ShoppingCartType.ShoppingCart)
                .ToList();

            if(!cart.Any())
                return RedirectToRoute("ShoppingCart");
            
            return View();
        }

        [ChildActionOnly]
        public ActionResult OpcBillingForm()
        {
            var cart = _workContext.CurrentUser.ShoppingCartItems
                .Where(sci => sci.ShoppingCartType == ShoppingCartType.ShoppingCart)
                .ToList();

            var billingAddressModel = PrepareBillingAddressModel(cart);
            return PartialView("OpcBillingAddress", billingAddressModel);
        }
    }
}