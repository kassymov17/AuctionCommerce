using AC.Core.Domain.Media;

namespace AC.Core.Domain.Catalog
{
    public partial class ItemPicture : BaseEntity
    {
        public int ItemId { get; set; }

        public int PictureId { get; set; }

        public int DisplayOrder { get; set; }

        public virtual Picture Picture { get; set; }

        public virtual Item Item { get; set; }
    }
}
