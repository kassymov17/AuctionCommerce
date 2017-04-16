using AC.Core.Domain.Catalog;

namespace AC.Data.Mapping.Catalog
{
    public partial class ItemMap : ACEntityTypeConfiguration<Item>
    {
        public ItemMap()
        {
            this.ToTable("Item");
            this.HasKey(i => i.Id);
            this.Property(i => i.Name).IsRequired().HasMaxLength(400);
            this.Property(i => i.MetaKeywords).HasMaxLength(400);
            this.Property(i => i.MetaTitle).HasMaxLength(400);
            this.Property(i => i.InitialPrice).HasPrecision(18, 4);
            this.Property(i => i.BidStep).HasPrecision(18, 4);
            this.Property(i => i.Weight).HasPrecision(18, 4);
            this.Property(i => i.Height).HasPrecision(18, 4);
            this.Property(i => i.Length).HasPrecision(18, 4);
            this.Property(i => i.Width).HasPrecision(18, 4);

            this.Ignore(i => i.ItemTypeId);

            this.HasRequired(i => i.User)
                .WithMany(u => u.Items)
                .HasForeignKey(i => i.UserId)
                .WillCascadeOnDelete(false);
        }
    }
}
