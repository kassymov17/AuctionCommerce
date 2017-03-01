using AC.Core.Domain.Topics;
using AC.Data.Entities.Common;
using FluentNHibernate.Mapping;

namespace AC.Data.Entities.Mapping
{
    class TopicMap : ClassMap<Topic>
    {
        public TopicMap()
        {
            Id(x => x.Id);
            Map(x => x.SystemName);
            Map(x => x.DisplayOrder);
            Map(x => x.Title);
            Map(x => x.Body);
            Map(x => x.Published);
            Map(x => x.MetaDescription);
            Map(x => x.MetaTitle);
            Map(x => x.MetaKeywords);
            Map(x => x.IncludeInFooterColumn1);
            Map(x => x.IncludeInFooterColumn2);
            Map(x => x.IncludeInFooterColumn3);
        }
    }
}
