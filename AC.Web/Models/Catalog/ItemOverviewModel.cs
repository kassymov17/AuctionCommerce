using System;
using System.Collections.Generic;
using AC.Core.Domain.Catalog;
using AC.Web.Framework.Mvc;
using AC.Web.Models.Media;

namespace AC.Web.Models.Catalog
{
    public partial class ItemOverviewModel : BaseACEntityModel
    {
        public ItemOverviewModel()
        {
            ItemPrice = new ItemPriceModel();
            DefaultPictureModel = new PictureModel();
        }

        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public DateTime? AuctionStartDate { get; set; }
        public DateTime? AuctionEndDate { get; set; }

        public ItemType ItemType { get; set; }

        public bool MarkAsNew { get; set; }

        // цена
        public ItemPriceModel ItemPrice { get; set; }

        // [todo] аттрибуты

        // картинка
        public PictureModel DefaultPictureModel { get; set; }

        #region Вложенный класс

        public partial class ItemPriceModel
        {
            public string Price { get; set; }
            public string BidStep { get; set; }
            public List<Bid> Bids { get; set; }

            public bool DisableBuyButton { get; set; }
            public bool DisableWishlistButton { get; set; }

            public bool ForceRedirectionAfterAddingToCart { get; set; }
        }

        #endregion
    }
}