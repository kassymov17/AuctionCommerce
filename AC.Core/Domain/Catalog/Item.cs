using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using AC.Core.Domain.Users;

namespace AC.Core.Domain.Catalog
{
    public partial class Item : BaseEntity
    {
        private ICollection<Bid> _bids;
        private ICollection<ProxyBid> _proxyBids;
        private ICollection<ItemCategory> _itemCategories;
        private ICollection<ItemPicture> _itemPictures;

        public int ItemTypeId { get; set; }

        public string Name { get; set; }

        public string ShortDescription { get; set; }

        public string FullDescription { get; set; }

        public bool ShowOnHomePage { get; set; }

        public string MetaKeywords { get; set; }

        public string MetaTitle { get; set; }

        public string MetaDescription { get; set; }

        public int ApprovedRatingSum { get; set; }

        public int NotApprovedRatingSum { get; set; }

        public int ApprovedTotalReviews { get; set; }

        public int NotApprovedTotalReviews { get; set; }

        public int StockQuantity { get; set; }

        public bool DisplayStockAvailability { get; set; }

        public bool DisplayStockQuantity { get; set; }

        public bool DisableBuyButton { get; set; }

        public bool DisableWishlistButton { get; set; }

        public decimal InitialPrice { get; set; }

        public decimal BidStep { get; set; }

        public DateTime? AuctionStartDate { get; set; }

        public DateTime? AuctionEndDate { get; set; }

        public bool MarkAsNew { get; set; }

        public DateTime? MarkAsNewStartDateTimeUtc { get; set; }

        public DateTime? MarkAsNewEndDateTimeUtc { get; set; }

        public decimal Weight { get; set; }

        public decimal Length { get; set; }

        public decimal Width { get; set; }

        public decimal Height { get; set; }

        public bool Published { get; set; }

        public bool Deleted { get; set; }

        public DateTime CreatedOnUtc { get; set; }

        public DateTime UpdatedOnUtc { get; set; }

        public ItemType ItemType
        {
            get
            {
                return (ItemType) this.ItemTypeId;
            }
            set
            {
                this.ItemTypeId = (int) value;
            }
        }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Bid> Bids
        {
            get { return _bids ?? (_bids = new List<Bid>()); }
            protected set { _bids = value; }
        }

        public virtual ICollection<ProxyBid> ProxyBids
        {
            get { return _proxyBids ?? (_proxyBids = new List<ProxyBid>()); }
            protected set { _proxyBids = value; }
        }

        public virtual ICollection<ItemCategory> ItemCategories
        {
            get { return _itemCategories ?? (_itemCategories = new List<ItemCategory>()); }
            protected set { _itemCategories = value; }
        }

        public virtual ICollection<ItemPicture> ItemPictures
        {
            get { return _itemPictures ?? (_itemPictures = new List<ItemPicture>()); }
            protected set { _itemPictures = value; }
        }
    }
}
