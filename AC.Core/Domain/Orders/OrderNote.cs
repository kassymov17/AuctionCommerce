using System;

namespace AC.Core.Domain.Orders
{
    public partial class OrderNote : BaseEntity
    {
        public int OrderId { get; set; }

        public string Note { get; set; }

        public bool DisplayToUser { get; set; }

        public DateTime CreatedOnUtc { get; set; }

        public virtual Order Order { get; set; }
    }
}
