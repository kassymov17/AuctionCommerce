using System;
using System.Collections.Generic;
using AC.Core.Domain.Catalog;

namespace AC.Core.Domain.Orders
{
    public partial class OrderItem : BaseEntity
    {
        public Guid OrderItemGuid { get; set; }

        public int OrderId { get; set; }

        public int ItemId { get; set; }

        public int Quantity { get; set; }

        public virtual Order Order { get; set; }

        public virtual Item Item { get; set; }
    }
}
