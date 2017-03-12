using AC.Services.Topics;
using AC.Web.Framework.UI;
using AC.Web.Models.Common;
using System.Web.Mvc;
using System.Linq;

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
            // [todo] кэшировать данные для ускорения
            var topicModel = _topicService.GetAllTopics()
                .Where(t=>t.IncludeInFooterColumn1 || t.IncludeInFooterColumn2 || t.IncludeInFooterColumn3)
                .Select(t=> new FooterTopicModel
                {
                    Id = t.Id,
                    Name = t.Title,
                    // for seo name
                    SeName = "",
                    IncludeInFooterColumn1 = t.IncludeInFooterColumn1,
                    IncludeInFooterColumn2 = t.IncludeInFooterColumn2,
                    IncludeInFooterColumn3 = t.IncludeInFooterColumn3
                }).ToList();

            // model
            return PartialView(topicModel);
        }

        public ActionResult ContactUs()
        {
            return View();
        }
    }
}