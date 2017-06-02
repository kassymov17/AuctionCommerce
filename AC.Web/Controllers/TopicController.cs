using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AC.Core;
using AC.Core.Domain.Topics;
using AC.Services.Topics;
using AC.Web.Models.Topics;

namespace AC.Web.Controllers
{
    public partial class TopicController : BasePublicController
    {
        #region Поля

        private readonly ITopicService _topicService;
        private readonly IWorkContext _workContext;

        #endregion

        #region Конструктор

        public TopicController(ITopicService topicService, IWorkContext workContext)
        {
            _topicService = topicService;
            _workContext = workContext;
        }

        #endregion

        #region Вспомогательные методы

        protected virtual TopicModel PrepareTopicModel(Topic topic)
        {
            if(topic == null)
                throw new ArgumentNullException("topic");

            var model = new TopicModel
            {
                Id = topic.Id,
                SystemName = topic.SystemName,
                Title = topic.Title,
                Body = topic.Body,
                MetaKeywords = topic.MetaKeywords,
                MetaTitle = topic.MetaTitle,
                MetaDescription = topic.MetaDescription
            };
            return model;
        }

        #endregion

        #region Методы

        [ChildActionOnly]
        public ActionResult TopicBlock(string systemName)
        {
            var topic = _topicService.GetTopicBySystemName(systemName);
            if (topic == null)
                return null;
            if (!topic.Published)
                return null;

            var model = PrepareTopicModel(topic);
            if (model == null)
                return Content("");

            return PartialView(model);
        }

        public ActionResult TopicDetailsPopup(string systemName)
        {
            return PartialView();
        }

        #endregion
    }
}