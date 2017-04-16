namespace AC.Core.Domain.Catalog
{
    public partial class ItemCategory : BaseEntity
    {
        public int ItemId { get; set; }

        public int CategoryId { get; set; }

        public bool IsFeaturedItem { get; set; }

        public int DisplayOrder { get; set; }

        public virtual Category Category { get; set; }

        public virtual Item Item { get; set; }
    }
}
