using System;
using System.Linq;
using AC.Core.Domain.Topics;
using AC.Data.Abstract;

namespace AC.Services.Topics
{
    public partial class TopicService : ITopicService
    {
        private readonly IRepository<Topic> _topicRepository;

        public TopicService(IRepository<Topic> topicRepository)
        {
            _topicRepository = topicRepository;
        }

        public IQueryable<Topic> GetAllTopics()
        {
            return _topicRepository.Table;
        }

        public Topic GetTopicById(int topicId)
        {
            if (topicId == 0)
                return null;
            return _topicRepository.GetById(topicId);
        }

        public virtual void UpdateTopic(Topic topic)
        {
            if (topic == null)
                throw new ArgumentNullException("topic");

            _topicRepository.Update(topic);
        }

        public virtual Topic GetTopicBySystemName(string systemName)
        {
            if (string.IsNullOrEmpty(systemName))
                return null;
            var query = _topicRepository.Table;
            query = query.Where(t => t.SystemName == systemName);
            query = query.OrderBy(t => t.Id);
            var topics = query.ToList();

            return topics.FirstOrDefault();
        }
    }
}
