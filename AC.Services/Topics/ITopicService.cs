using AC.Core.Domain.Topics;
using System.Collections.Generic;
using System.Linq;

namespace AC.Services.Topics
{
    public partial interface ITopicService
    {
        //void DeleteTopic(int topicId);

        //Topic GetTopicById(int topicId);

        IQueryable<Topic> GetAllTopics();

        //void InsertTopic(Topic topic);

        //void UpdateTopic(Topic topic);
    }
}
