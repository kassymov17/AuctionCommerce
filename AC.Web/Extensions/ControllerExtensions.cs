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
using AC.Web.Models.Media;

namespace AC.Web.Extensions
{
    public static class ControllerExtensions
    {
        public static IEnumerable<ItemOverviewModel> PrepareItemOverviewModels(this Controller controller,
            IWorkContext workContext,
            ICategoryService categoryService,
            IItemService itemService,
            ILocalizationService localizationService,
            IPictureService pictureService,
            IEnumerable<Item> items,
            bool preparePriceModel = true, bool preparePictureModel = true,
            int? itemThumbPictureSize = null,
            bool forceRedirectionAfterAddingToCart = false)
        {
            if(items == null)
                throw new ArgumentNullException("items");

            var models = new List<ItemOverviewModel>();
            foreach (var item in items)
            {
                var model = new ItemOverviewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    ShortDescription = item.ShortDescription,
                    FullDescription = item.FullDescription,
                    ItemType = item.ItemType,
                };

                // цена
                if (preparePriceModel)
                {
                    var priceModel = new ItemOverviewModel.ItemPriceModel
                    {
                        ForceRedirectionAfterAddingToCart = forceRedirectionAfterAddingToCart
                    };

                    switch (item.ItemType)
                    {
                        case ItemType.AuctionItem:
                            {
                                #region тип товара аукцион
                                // не отображать кнопку добавить в корзину
                                priceModel.DisableBuyButton = true;
                                // отобразить кнопку избранное
                                priceModel.DisableWishlistButton = false;

                                priceModel.BidStep = item.BidStep.ToString();
                                priceModel.Price = item.InitialPrice.ToString();
                                priceModel.Bids = item.Bids.ToList();

                                #endregion
                            }
                            break;
                        case ItemType.ShopItem:
                            {
                                #region тип товара магазин

                                // добавить в корзину
                                priceModel.DisableBuyButton = false;
                                // добавить в избранное
                                priceModel.DisableWishlistButton = false;

                                priceModel.Price = item.InitialPrice.ToString();

                                #endregion
                            }
                            break;
                    }

                    model.ItemPrice = priceModel;
                }
                // изображение
                if (preparePictureModel)
                {
                    int pictureSize = itemThumbPictureSize ?? 415;

                    var picture = pictureService.GetPicturesByItemId(item.Id, 1).FirstOrDefault();
                    var pictureModel = new PictureModel
                    {
                        ImageUrl = pictureService.GetPictureUrl(picture, pictureSize),
                        FullSizeImgUrl = pictureService.GetPictureUrl(picture)
                    };
                    // "title" attribute
                    pictureModel.Title = (picture != null && !string.IsNullOrEmpty(picture.TitleAttribute))
                        ? picture.TitleAttribute
                        : string.Format(localizationService.GetResource("Media.Product.ImageLinkTitleFormat"),
                            model.Name);

                    // "alt" attribute
                    pictureModel.AlternateText = (picture != null && !string.IsNullOrEmpty(picture.AltAttribute))
                        ? picture.AltAttribute
                        : string.Format(localizationService.GetResource("Media.Product.ImageAlternateTextFormat"),
                            model.Name);

                    model.DefaultPictureModel = pictureModel;

                }
                model.AuctionStartDate = item.AuctionStartDate;
                model.AuctionEndDate = item.AuctionEndDate;
                

                models.Add(model);
            }
            return models;
        }
    }
}