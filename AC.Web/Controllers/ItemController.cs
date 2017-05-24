using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AC.Core;
using AC.Core.Domain.Catalog;
using AC.Core.Domain.Orders;
using AC.Services.Catalog;
using AC.Services.Localization;
using AC.Services.Media;
using AC.Web.Models.Catalog;
using AC.Web.Extensions;
using AC.Web.Framework;
using AC.Web.Framework.Kendoui;
using AC.Web.Models.Media;

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

        [NonAction]
        protected virtual Item PrepareBidStep(Item item)
        {
            if (item.InitialPrice > 100 && item.InitialPrice <= 1000)
                item.BidStep = 50;

            if (item.InitialPrice > 1000 && item.InitialPrice < 10000)
                item.BidStep = 500;

            if (item.InitialPrice >= 10000 && item.InitialPrice < 50000)
                item.BidStep = 1000;

            if (item.InitialPrice >= 50000 && item.InitialPrice < 100000)
                item.BidStep = 5000;

            if (item.InitialPrice >= 100000 && item.InitialPrice < 1000000)
                item.BidStep = 10000;

            return item;
        }

        [NonAction]
        protected virtual ItemDetailsModel PrepareItemDetailsPageModel(Item item)
        {
            if(item == null)
                throw new ArgumentNullException("item");

            #region Стандартные свойства

            PrepareBidStep(item);
            _itemService.UpdateItem(item);
            var model = new ItemDetailsModel
            {
                Id = item.Id,
                Name = item.Name,
                ShortDescription = item.ShortDescription,
                FullDescription = item.FullDescription,
                MetaKeywords = item.MetaKeywords,
                MetaTitle = item.MetaTitle,
                MetaDescription = item.MetaDescription,
                ItemType =  item.ItemType,
                User = item.User
            };

            #region Breadrumbs
            #endregion

            #region Изображения 

            var defaultPictureSize = 550;

            var pictures = _pictureService.GetPicturesByItemId(item.Id);
            var defaultPicture = pictures.FirstOrDefault();
            var defaultPictureModel = new PictureModel
            {
                ImageUrl = _pictureService.GetPictureUrl(defaultPicture, defaultPictureSize),
                FullSizeImgUrl = _pictureService.GetPictureUrl(defaultPicture, 0),
            };

            var pictureModels = new List<PictureModel>();
            foreach (var picture in pictures)
            {
                var pictureModel = new PictureModel
                {
                    ImageUrl = _pictureService.GetPictureUrl(picture, 100),
                    FullSizeImgUrl = _pictureService.GetPictureUrl(picture),
                };

                pictureModels.Add(pictureModel);
            }
            model.DefaultPictureModel = defaultPictureModel;
            model.PictureModels = pictureModels;

            #endregion

            #region Цены

            model.ItemPrice.Price = item.InitialPrice.ToString();
            if (item.ItemType == ItemType.AuctionItem)
            {
                model.ItemPrice.BidStep = item.BidStep.ToString();
                model.StartDate = item.AuctionStartDate;
                model.EndDate = item.AuctionEndDate;
            }

            #endregion

            #region Добавить в корзину

            model.AddToCart.ItemId = item.Id;
            model.AddToCart.EnteredQuantity = 1;

            #endregion

            // доступность товара
            model.IsAvailable = item.AuctionStartDate.HasValue && item.AuctionStartDate <= DateTime.UtcNow &&
                                item.AuctionEndDate.HasValue && item.AuctionEndDate >= DateTime.UtcNow;

            model.PlaceBid.ItemId = item.Id;
            model.PlaceBid.CurrentPrice = item.InitialPrice;
            model.PlaceBid.BidStep = item.BidStep;

            model.Bids = item.Bids.OrderByDescending(b => b.Amount).ToList();

            return model;

            #endregion
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
            var item = _itemService.GetItemById(itemId);
            if (item == null || item.Deleted)
                return InvokeHttp404();
            
            var model = PrepareItemDetailsPageModel(item);

            // TODO добавить в недавно просмотренные

            return View(model);
        }

        #region Изображения товара

        [ValidateInput(false)]
        public ActionResult ItemPictureAdd(int pictureId, int displayOrder, string overrideAltAttribute,
            string overrideTitleAttribute,
            int itemId)
        {
            if (pictureId == 0)
                throw new ArgumentException();

            var item = _itemService.GetItemById(itemId);
            if (item == null)
                throw new ArgumentException("Не найден продукт с данным id");

            var picture = _pictureService.GetPictureById(pictureId);
            if (picture == null)
                throw new ArgumentException("Не найдено изображение с данным id");

            _itemService.InsertItemPicture(new ItemPicture
            {
                PictureId = pictureId,
                ItemId = itemId,
                DisplayOrder = displayOrder
            });

            _pictureService.UpdatePicture(picture.Id,
                _pictureService.LoadPictureBinary(picture),
                picture.MimeType,
                picture.SeoFilename,
                overrideAltAttribute,
                overrideTitleAttribute);

            return Json(new {Result = true}, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ItemPictureList(DataSourceRequest command, int itemId)
        {
            var itemPictures = _itemService.GetItemPicturesByItemId(itemId);
            var itemPicturesModel = itemPictures
                .Select(x =>
                {
                    var picture = _pictureService.GetPictureById(x.PictureId);
                    if (picture == null)
                        throw new Exception("Изображение не получается загрузиться");
                    var m = new ItemModel.ItemPictureModel
                    {
                        Id = x.Id,
                        ItemId =  x.ItemId,
                        PictureId = x.PictureId,
                        PictureUrl = _pictureService.GetPictureUrl(picture),
                        OverrideTitleAttribute = picture.AltAttribute,
                        OverrideAltAttribute = picture.TitleAttribute,
                        DisplayOrder = x.DisplayOrder
                    };
                    return m;
                }).ToList();

            var gridModel = new DataSourceResult
            {
                Data = itemPicturesModel,
                Total = itemPicturesModel.Count
            };

            return Json(gridModel);
        }

        [HttpPost]
        public ActionResult ItemPictureUpdate(ItemModel.ItemPictureModel model)
        {
            var itemPicture = _itemService.GetItemPictureById(model.Id);
            if (itemPicture == null)
                throw new ArgumentException("Не найдено изображание с данным id");

            itemPicture.DisplayOrder = model.DisplayOrder;
            _itemService.UpdateItemPicture(itemPicture);

            var picture = _pictureService.GetPictureById(itemPicture.PictureId);
            if(picture == null)
                throw new ArgumentException("Не найдено изображение с таким id");

            _pictureService.UpdatePicture(picture.Id, 
            _pictureService.LoadPictureBinary(picture),
            picture.MimeType,
            picture.SeoFilename,
            model.OverrideAltAttribute,
            model.OverrideTitleAttribute
            );

            return new NullJsonResult();
        }

        [HttpPost]
        public ActionResult ItemPictureDelete(int id)
        {
            var itemPicture = _itemService.GetItemPictureById(id);
            if(itemPicture == null)
                throw new ArgumentException("Не найдено изображение с данным id");

            var pictureId = itemPicture.PictureId;
            _itemService.DeleteItemPicture(itemPicture);

            var picture = _pictureService.GetPictureById(pictureId);
            if(picture == null)
                throw new ArgumentException("Не найдено изображение с данным id");

            _pictureService.DeletePicture(picture);

            return new NullJsonResult();
        }

        #endregion

        #endregion
    }
}