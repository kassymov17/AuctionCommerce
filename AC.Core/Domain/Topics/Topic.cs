using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AC.Core.Domain.Topics
{
    public partial class Topic : BaseEntity
    {
        public string SystemName { get; set; }
        public int DisplayOrder { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public bool Published { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string MetaTitle { get; set; }
        public bool IncludedInTopMenu { get; set; }
        public bool IncludeInFooterColumn1 { get; set; }
        public bool IncludeInFooterColumn2 { get; set; }
        public bool IncludeInFooterColumn3 { get; set; }
    }
}
