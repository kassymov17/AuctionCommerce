using System;
using System.Collections.Generic;
using System.Linq;
using AC.Core;
using AC.Core.Domain.Catalog;
using AC.Core.Domain.Users;
using AC.Core.Domain.Orders;
using AC.Data.Abstract;

namespace AC.Services.Orders
{
    public partial class OrderService : IOrderService
    {
        #region Поля

        private readonly IRepository<Order> _orderRepository;

        #endregion

        #region Конструктор

        public OrderService(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        #endregion

        public virtual IPagedList<Order> SearchOrders(int userId = 0, int itemId = 0, string orderNotes = null, int pageIndex = 0,
            int pageSize = int.MaxValue)
        {
            var query = _orderRepository.Table;

            if (userId > 0)
                query = query.Where(o => o.UserId == userId);

            if (itemId > 0)
                query = query.Where(o => o.OrderItems.Any(orderItem => orderItem.Item.Id == itemId));

            if (!String.IsNullOrEmpty(orderNotes))
                query = query.Where(o => o.OrderNotes.Any(on => on.Note.Contains(orderNotes)));

            query = query.Where(o => !o.Deleted);
            query = query.OrderByDescending(o => o.CreatedOnUtc);

            return new PagedList<Order>(query, pageIndex, pageSize);
        }
    }
}
