using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AC.Core;
using AC.Core.Domain.Users;
using AC.Web.Models.Order;

namespace AC.Web.Controllers
{
    public partial class OrderController : BasePublicController
    {
        #region Поля

        private readonly IWorkContext _workContext;

        #endregion

        #region Конструктор

        public OrderController(IWorkContext workContext)
        {
            _workContext = workContext;
        }

        #endregion

        #region Вспомагательные методы

        [NonAction]
        protected virtual UserOrderListModel PrepareUserOrderListModel()
        {
            var model = new UserOrderListModel();
            return model;
        }

        #endregion

        #region Методы

        public ActionResult UserOrders()
        {
            if(!_workContext.CurrentUser.IsRegistered())
                return new HttpUnauthorizedResult();

            var model = PrepareUserOrderListModel();
            return View(model);
        }

        #endregion
    }
}