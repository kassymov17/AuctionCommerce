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
            Map(x => x.Title);
        }
    }
}
