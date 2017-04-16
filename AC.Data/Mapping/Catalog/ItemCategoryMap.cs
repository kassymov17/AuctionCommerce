using AC.Core.Domain.Catalog;

namespace AC.Data.Mapping.Catalog
{
    public partial class ItemCategoryMap : ACEntityTypeConfiguration<ItemCategory>
    {
        public ItemCategoryMap()
        {
            this.ToTable("Item_Category_Mapping");
            this.HasKey(ic => ic.Id);

            this.HasRequired(ic => ic.Category)
                .WithMany()
                .HasForeignKey(ic => ic.CategoryId);

            this.HasRequired(ic => ic.Item)
                .WithMany(i => i.ItemCategories)
                .HasForeignKey(ic => ic.ItemId);
        }
    }
}
