using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AC.Web.Framework.Mvc;

namespace AC.Web.Models.Topics
{
    public partial class TopicModel : BaseACEntityModel
    {
        public string SystemName { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public string MetaKeywords { get; set; }
        
        public string MetaDescription { get; set; }

        public string MetaTitle { get; set; }

        public string SeName { get; set; }
    }
}