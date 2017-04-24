using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AC.Core.Domain.Catalog;
using AC.Core.Domain.Orders;
using AC.Web.Framework.Mvc;
using AC.Web.Models.Media;

namespace AC.Web.Models.Catalog
{
    public partial class ItemDetailsModel : BaseACEntityModel
    {
        public ItemDetailsModel()
        {
            DefaultPictureModel = new PictureModel();
            PictureModels = new List<PictureModel>();
            ItemPrice = new ItemOverviewModel.ItemPriceModel();
            AddToCart = new AddToCartModel();
            PlaceBid = new PlaceBidModel();
        }

        public PictureModel DefaultPictureModel { get; set; }
        public IList<PictureModel> PictureModels { get; set; }

        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public bool IsAvailable { get; set; }

        public ItemType ItemType { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public string StockAvailability { get; set; }

        public ItemOverviewModel.ItemPriceModel ItemPrice { get; set; }
        public AddToCartModel AddToCart { get; set; }
        public PlaceBidModel PlaceBid { get; set; }

        #region Встроенный класс

        public partial class AddToCartModel
        {
            public int ItemId { get; set; }
            public int EnteredQuantity { get; set; }
            public string MinimumQuantityNotification { get; set; }
        }

        public partial class PlaceBidModel
        {
            public int ItemId { get; set; }
            public int Amount { get; set; }
        } 

        #endregion
    }
}