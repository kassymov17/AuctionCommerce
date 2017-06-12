using AC.Services.Topics;
using AC.Web.Framework.UI;
using AC.Web.Models.Common;
using System.Web.Mvc;
using System.Linq;
using AC.Core;
using AC.Core.Domain.Orders;
using AC.Core.Domain.Users;
using AC.Services.Localization;
using AC.Services.Orders;

namespace AC.Web.Controllers
{
    public partial class CommonController : BasePublicController
    {
        #region Fields

        private readonly IPageHeadBuilder _pageHeadBuilder;
        private readonly ITopicService _topicService;
        private readonly IWorkContext _workContext;
        private readonly ILocalizationService _localizationService;

        #endregion

        public CommonController(IWorkContext workContext, ILocalizationService localizationService, IPageHeadBuilder pageHeadBuilder, ITopicService topicService)
        {
            _pageHeadBuilder = pageHeadBuilder;
            _topicService = topicService;
            _workContext = workContext;
            _localizationService = localizationService;
        }

        public ActionResult PageNotFound()
        {
            this.Response.StatusCode = 404;
            this.Response.TrySkipIisCustomErrors = true;

            return View();
        }

        [ChildActionOnly]
        public ActionResult LanguageSelector()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult Logo()
        {
            var model = new LogoModel
            {
                StoreName = "AuctionCommerce"
            };

            model.LogoPath = "/content/images/logo.png";

            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult HeaderLinks()
        {
            var user = _workContext.CurrentUser;
            //var unreadMessageCount = GetUnreadPrivateMessages();
            //var unreadMessage = string.Empty;
            //var alertMessage = string.Empty;

            //if (unreadMessageCount > 0)
            //{
            //    unreadMessage = string.Format(_localizationService.GetResource("PrivateMessages.TotalUnread"),
            //        unreadMessageCount);

            //    alertMessage = string.Format(_localizationService.GetResource("PrivateMessages.YouHaveUnreadPM"),
            //        unreadMessageCount);
            //}

            var model = new HeaderLinksModel
            {
                // зарегистрирован ли пользователь
                IsAuthenticated = user.IsRegistered(),
                CustomerEmailUsername = user.IsRegistered() ? user.Email : "",
                ShoppingCartEnabled = true,
                WishlistEnabled = true,
                AllowPrivateMessages = true,
                UnreadPrivateMessages = "",
                AlertMessage = string.Empty
            };

            if (user.HasShoppingCartItems)
            {
                model.ShoppingCartItems =
                    user.ShoppingCartItems.Where(sci => sci.ShoppingCartType == ShoppingCartType.ShoppingCart)
                        .ToList()
                        .GetTotalProducts();

                model.WishlistItems = user.ShoppingCartItems.Where(sci => sci.ShoppingCartType == ShoppingCartType.Wishlist)
                        .ToList()
                        .GetTotalProducts();
            }

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