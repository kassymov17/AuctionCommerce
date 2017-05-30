using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AC.Core;
using AC.Core.Domain.Orders;
using AC.Core.Domain.Users;
using AC.Services.Orders;
using AC.Web.Models.Order;

namespace AC.Web.Controllers
{
    public partial class OrderController : BasePublicController
    {
        #region Поля

        private readonly IWorkContext _workContext;
        private readonly IOrderService _orderService;

        #endregion

        #region Конструктор

        public OrderController(IWorkContext workContext, IOrderService orderService)
        {
            _workContext = workContext;
            _orderService = orderService;
        }

        #endregion

        #region Вспомагательные методы

        [NonAction]
        protected virtual UserOrderListModel PrepareUserOrderListModel()
        {
            var model = new UserOrderListModel();
            var orders = _orderService.SearchOrders(userId: _workContext.CurrentUser.Id);
            foreach (var order in orders)
            {
                var orderModel = new UserOrderListModel.OrderDetailsModel
                {
                    Id = order.Id,
                    CreatedOn = order.CreatedOnUtc,
                    OrderStatusEnum = order.OrderStatus,
                    OrderTotal = order.OrderTotal.ToString()
                };
                switch (order.OrderStatus)
                {
                    case OrderStatus.Cancelled:
                        orderModel.OrderStatus = "Отменен";
                        break;
                    case OrderStatus.Complete:
                        orderModel.OrderStatus = "Завершен";
                        break;
                    case OrderStatus.Pending:
                        orderModel.OrderStatus = "В ожидании";
                        break;
                    case OrderStatus.Processing:
                        orderModel.OrderStatus = "В процессе";
                        break;
                }

                model.Orders.Add(orderModel);
            }

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