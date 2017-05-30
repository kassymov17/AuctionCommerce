using System;
using System.Collections.Generic;
using AC.Core;
using AC.Core.Domain.Catalog;
using AC.Core.Domain.Users;
using AC.Core.Domain.Orders;

namespace AC.Services.Orders
{
    public partial interface IOrderService
    {
        IPagedList<Order> SearchOrders(int userId = 0, int itemId = 0, string orderNotes = null, int pageIndex = 0, int pageSize = int.MaxValue);
    }
}
