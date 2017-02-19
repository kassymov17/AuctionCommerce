using System;
using System.Collections.Generic;
using System.Linq;
using AC.Core;
using AC.Core.Domain.Topics;
using AC.Core.Data;

namespace AC.Services.Topics
{
    public partial class TopicService : ITopicService
    {
        #region Fields

        private readonly IRepository<Topic> _topicRepository;

        #endregion

        public TopicService(IRepository<Topic> topicRepository)
        {
            _topicRepository = topicRepository;
        }

        #region Methods

        public virtual void DeleteTopic(Topic topic)
        {
            if (topic == null)
                throw new ArgumentNullException("topic");

            _topicRepository.Delete(topic);
        }

        public virtual Topic GetTopicById(int topicId)
        {
            if (topicId == 0)
                return null;

            return _topicRepository.GetById(topicId);
        }

        /// <summary>
        /// Gets all topics
        /// </summary>
        /// <returns>Topics</returns>
        public virtual IList<Topic> GetAllTopics()
        {
            var query = _topicRepository.Table;
            query = query.OrderBy(t => t.DisplayOrder).ThenBy(t => t.SystemName);

            query = query.Where(t => t.Published);

            query = from t in query
                    group t by t.Id
                    into tGroup
                    orderby tGroup.Key
                    select tGroup.FirstOrDefault();

            query = query.OrderBy(t => t.DisplayOrder).ThenBy(t => t.SystemName);

            return query.ToList();
        }

        /// <summary>
        /// Inserts a topic
        /// </summary>
        /// <param name="topic">Topic</param>
        public virtual void InsertTopic(Topic topic)
        {
            if (topic == null)
                throw new ArgumentNullException("topic");

            _topicRepository.Insert(topic);
        }

        /// <summary>
        /// Updates the topic
        /// </summary>
        /// <param name="topic">Topic</param>
        public virtual void UpdateTopic(Topic topic)
        {
            if (topic == null)
                throw new ArgumentNullException("topic");

            _topicRepository.Update(topic);
        }

        #endregion
    }
}
