using AC.Core.Domain.Catalog;

namespace AC.Data.Mapping.Catalog
{
    public partial class ProxyBidMap : ACEntityTypeConfiguration<ProxyBid>
    {
        public ProxyBidMap()
        {
            this.ToTable("ProxyBid");
            this.HasKey(p => p.Id);
            this.Property(p => p.Bid).IsRequired().HasPrecision(18, 4);

            this.HasRequired(p => p.User)
                .WithMany(u => u.ProxyBids)
                .HasForeignKey(p => p.UserId);

            this.HasRequired(p => p.Item)
                .WithMany(i => i.ProxyBids)
                .HasForeignKey(p => p.ItemId);
        }
    }
}
