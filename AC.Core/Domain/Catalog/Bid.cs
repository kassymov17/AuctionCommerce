using System;
using AC.Core.Domain.Users;

namespace AC.Core.Domain.Catalog
{
    public partial class Bid : BaseEntity
    {
        public int ItemId { get; set; }

        public int UserId { get; set; }

        public decimal Amount { get; set; }

        public DateTime CreatedOn { get; set; }

        public virtual Item Item { get; set; }

        public virtual User User { get; set; }
    }
}
