using System;
using System.Collections.Generic;
using AC.Core.Domain.Orders;
using AC.Web.Framework.Mvc;

namespace AC.Web.Models.Order
{
    public partial class UserOrderListModel
    {
        public UserOrderListModel()
        {
            Orders = new List<OrderDetailsModel>();
        }
        public IList<OrderDetailsModel> Orders { get; set; }

        public partial class OrderDetailsModel : BaseACEntityModel
        {
            public string OrderTotal { get; set; }
            public OrderStatus OrderStatusEnum { get; set; }   
            public string OrderStatus { get; set; }
            public DateTime CreatedOn { get; set; }
        }    
    }
}