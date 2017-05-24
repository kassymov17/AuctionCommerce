using AC.Core.Domain.Users;

namespace AC.Core.Domain.Catalog
{
    public partial class ProxyBid : BaseEntity
    {
        public int ItemId { get; set; }

        public int UserId { get; set; }

        public decimal Bid { get; set; }

        public virtual Item Item { get; set; }

        public virtual User User { get; set; }
    }
}
