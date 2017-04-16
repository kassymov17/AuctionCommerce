using AC.Core.Domain.Catalog;

namespace AC.Data.Mapping.Catalog
{
    public partial class ItemPictureMap : ACEntityTypeConfiguration<ItemPicture>
    {
        public ItemPictureMap()
        {
            this.ToTable("Item_Picture_Mapping");
            this.HasKey(ip => ip.Id);

            this.HasRequired(ip => ip.Picture)
                .WithMany()
                .HasForeignKey(ip => ip.PictureId);

            this.HasRequired(ip => ip.Item)
                .WithMany(ip => ip.ItemPictures)
                .HasForeignKey(ip => ip.ItemId);
        }
    }
}
