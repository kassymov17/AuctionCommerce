using AC.Core.Domain.Catalog;

namespace AC.Data.Mapping.Catalog
{
    public partial class BidMap : ACEntityTypeConfiguration<Bid>
    {
        public BidMap()
        {
            this.ToTable("Bid");
            this.HasKey(b => b.Id);
            this.Property(b => b.Amount).IsRequired().HasPrecision(18, 4);

            this.HasRequired(b => b.User)
                .WithMany(i => i.Bids)
                .HasForeignKey(b => b.UserId);

            this.HasRequired(b => b.Item)
                .WithMany(i => i.Bids)
                .HasForeignKey(b => b.ItemId);
        }
    }
}
