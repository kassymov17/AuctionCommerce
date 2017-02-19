﻿using AC.Services.Topics;
using AC.Web.Framework.UI;
using AC.Web.Models.Common;
using System.Web.Mvc;

namespace AC.Web.Controllers
{
    public partial class CommonController : BasePublicController
    {
        #region Fields
        private readonly IPageHeadBuilder _pageHeadBuilder;
        private readonly ITopicService _topicService;
        #endregion

        public CommonController(IPageHeadBuilder pageHeadBuilder, ITopicService topicService)
        {
            _pageHeadBuilder = pageHeadBuilder;
            _topicService = topicService;
        }

        public CommonController()
        {

        }
        

        [ChildActionOnly]
        public ActionResult HeaderLinks()
        {
            var model = new HeaderLinksModel
            {
                // зарегистрирован ли пользователь
                IsAuthenticated = false,
                CustomerEmailUsername = "CustomerEmailUsername",
                ShoppingCartEnabled = true,
                WishlistEnabled = true,
                AllowPrivateMessages = true,
                UnreadPrivateMessages = "",
                AlertMessage = string.Empty
            };

            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult Footer()
        {
            // footer topics
            var example = _topicService.GetAllTopics();
            return PartialView();
        }
    }
}