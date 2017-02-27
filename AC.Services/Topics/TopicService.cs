using AC.Core.Domain.Topics;
using AC.Data.Abstract;
using System.Linq;

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
            return _topicRepository.GetAll();
        }
    }
}
