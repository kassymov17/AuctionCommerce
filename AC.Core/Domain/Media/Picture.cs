
namespace AC.Core.Domain.Media
{
    public partial class Picture : BaseEntity
    {
        public byte[] PictureBinary { get; set; }

        public string MimeType { get; set; }

        public string SeoFilename { get; set; }

        public string AltAttribute { get; set; }

        public string TitleAttribute { get; set; }

        public bool IsNew { get; set; }
    }
}
