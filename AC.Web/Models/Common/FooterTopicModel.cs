using AC.Web.Framework.Mvc;

namespace AC.Web.Models.Common
{
    public class FooterTopicModel : BaseACEntityModel
    {
        public string Name { get; set; }
        public string SeName { get; set; }

        public bool IncludeInFooterColumn1 { get; set; }
        public bool IncludeInFooterColumn2 { get; set; }
        public bool IncludeInFooterColumn3 { get; set; }
    }
}