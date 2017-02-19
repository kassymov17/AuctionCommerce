using System.Collections.Generic;
using AC.Core.Domain.Topics;

namespace AC.Services.Topics
{
    public partial interface ITopicService
    {
        /// <summary>
        /// deletes a topic
        /// </summary>
        /// <param name="topic"> Topic </param>
        void DeleteTopic(Topic topic);

        /// <summary>
        /// Gets a topic
        /// </summary>
        /// <param name="topicId">The topic identifier</param>
        /// <returns>Topic</returns>
        Topic GetTopicById(int topicId);

        /// <summary>
        /// Gets all topics
        /// </summary>
        /// <returns>Topics</returns>
        IList<Topic> GetAllTopics();

        /// <summary>
        /// Inserts a topic
        /// </summary>
        /// <param name="topic">Topic</param>
        void InsertTopic(Topic topic);

        /// <summary>
        /// Updates the topic
        /// </summary>
        /// <param name="topic">Topic</param>
        void UpdateTopic(Topic topic);
    }
}
