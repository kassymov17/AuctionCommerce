using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AC.Core;
using AC.Core.Domain.Catalog;
using AC.Services.Catalog;
using AC.Services.Localization;
using AC.Services.Media;
using AC.Web.Models.Catalog;
using AC.Web.Extensions;

namespace AC.Web.Controllers
{
    public class ItemController : BasePublicController
    {
        #region Поля

        private readonly ICategoryService _categoryService;
        private readonly IItemService _itemService;
        private readonly IWorkContext _workContext;
        private readonly IPictureService _pictureService;
        private readonly ILocalizationService _localizationService;

        #endregion

        #region Конструктор

        public ItemController(ICategoryService categoryService, IItemService itemService, IWorkContext workContext, IPictureService pictureService, ILocalizationService localizationService)
        {
            _categoryService = categoryService;
            _itemService = itemService;
            _workContext = workContext;
            _pictureService = pictureService;
            _localizationService = localizationService;
        }

        #endregion

        #region Вспомогательные методы

        [NonAction]
        protected virtual IEnumerable<ItemOverviewModel> PrepareItemOverviewModels(IEnumerable<Item> items,
            bool preparePriceModel = true, bool preparePictureModel = true,
            int? itemThumbPictureSize = null,
            bool forceRedirectionAfterAddingToCart = false)
        {
            return this.PrepareItemOverviewModels(_workContext, _categoryService, _itemService, _localizationService,
                _pictureService, items, preparePriceModel, preparePictureModel, itemThumbPictureSize, forceRedirectionAfterAddingToCart);
        }

        #endregion

        #region Методы

        [ChildActionOnly]
        public ActionResult HomepageItems()
        {
            var items = _itemService.GetAllItemsDisplayedOnHomePage();

            if (!items.Any())
                return Content("");

            var model = PrepareItemOverviewModels(items, true, true, 500).ToList();
            return PartialView(model);
        }

        public ActionResult ItemDetails(int itemId)
        {
            return View();
        }

        #endregion
    }
}