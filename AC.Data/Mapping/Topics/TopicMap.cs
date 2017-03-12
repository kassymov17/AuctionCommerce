using AC.Core.Domain.Topics;

namespace AC.Data.Mapping.Topics
{
    public class TopicMap : ACEntityTypeConfiguration<Topic>
    {
        public TopicMap()
        {
            this.ToTable("Topic");
            this.HasKey(t => t.Id);
        }
    }
}
