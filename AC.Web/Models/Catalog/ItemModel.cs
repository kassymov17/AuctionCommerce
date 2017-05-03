using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using AC.Web.Framework;
using AC.Web.Framework.Mvc;
using AC.Web.Validators.Catalog;
using FluentValidation.Attributes;

namespace AC.Web.Models.Catalog
{
    [Validator(typeof(ItemValidator))]
    public partial class ItemModel : BaseACEntityModel
    {
        public ItemModel()
        {
            ItemPictureModels = new List<ItemPictureModel>();
            AddPictureModel = new ItemPictureModel();

            SelectedCategoryIds = new List<int>();
            AvailableCategories = new List<SelectListItem>();
        }

        public override int Id { get; set; }

        [ACResourceDisplayName("Admin.Catalog.Products.Fields.ProductType")]
        public int ItemTypeId { get; set; }
        [ACResourceDisplayName("Admin.Catalog.Products.Fields.ProductType")]
        public string ItemTypeName { get; set; }

        [ACResourceDisplayName("Admin.Catalog.Products.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [ACResourceDisplayName("Admin.Catalog.Products.Fields.ShortDescription")]
        [AllowHtml]
        public string ShortDescription { get; set; }

        [ACResourceDisplayName("Admin.Catalog.Products.Fields.FullDescription")]
        [AllowHtml]
        public string FullDescription { get; set; }

        [ACResourceDisplayName("Admin.Catalog.Products.Fields.ShowOnHomePage")]
        public bool ShowOnHomePage { get; set; }

        [ACResourceDisplayName("Admin.Catalog.Products.Fields.MetaKeywords")]
        [AllowHtml]
        public string MetaKeywords { get; set; }

        [ACResourceDisplayName("Admin.Catalog.Products.Fields.MetaDescription")]
        [AllowHtml]
        public string MetaDescription { get; set; }

        [ACResourceDisplayName("Admin.Catalog.Products.Fields.MetaTitle")]
        [AllowHtml]
        public string MetaTitle { get; set; }

        [ACResourceDisplayName("Admin.Catalog.Products.Fields.StockQuantity")]
        public int StockQuantity { get; set; }
        public int LastStockQuantity { get; set; }
        [ACResourceDisplayName("Admin.Catalog.Products.Fields.StockQuantity")]
        public string StockQuantityStr { get; set; }

        [ACResourceDisplayName("Admin.Catalog.Products.Fields.Price")]
        public decimal InitialPrice { get; set; }

        [ACResourceDisplayName("Admin.Catalog.Products.Fields.BidStep")]
        public decimal BidStep { get; set; }

        [ACResourceDisplayName("Admin.Catalog.Products.Fields.AuctionStartDate")]
        [UIHint("DateTimeNullable")]
        public DateTime? AuctionStartDate { get; set; }

        [ACResourceDisplayName("Admin.Catalog.Products.Fields.AuctionEndDate")]
        [UIHint("DateTimeNullable")]
        public DateTime AuctionEndDate { get; set; }

        [ACResourceDisplayName("Admin.Catalog.Products.Fields.Weight")]
        public decimal Weight { get; set; }

        [ACResourceDisplayName("Admin.Catalog.Products.Fields.Length")]
        public decimal Length { get; set; }

        [ACResourceDisplayName("Admin.Catalog.Products.Fields.Width")]
        public decimal Width { get; set; }

        [ACResourceDisplayName("Admin.Catalog.Products.Fields.Height")]
        public decimal Height { get; set; }

        [ACResourceDisplayName("Admin.Catalog.Products.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        [ACResourceDisplayName("Admin.Catalog.Products.Fields.Published")]
        public bool Published { get; set; }

        public bool Deleted { get; set; }

        [ACResourceDisplayName("Admin.Catalog.Products.Fields.CreatedOn")]
        public DateTime? CreatedOn { get; set; }
        [ACResourceDisplayName("Admin.Catalog.Products.Fields.UpdatedOn")]
        public DateTime? UpdatedOn { get; set; }

        //categories
        [ACResourceDisplayName("Admin.Catalog.Products.Fields.Categories")]
        [UIHint("MultiSelect")]
        public IList<int> SelectedCategoryIds { get; set; }
        public IList<SelectListItem> AvailableCategories { get; set; }

        //pictures
        public ItemPictureModel AddPictureModel { get; set; }
        public IList<ItemPictureModel> ItemPictureModels { get; set; }

        #region Вложенны классы

        public partial class ItemPictureModel : BaseACEntityModel
        {
            public int ItemId { get; set; }

            [UIHint("Picture")]
            [ACResourceDisplayName("Admin.Catalog.Products.Pictures.Fields.Picture")]
            public int PictureId { get; set; }

            [ACResourceDisplayName("Admin.Catalog.Products.Pictures.Fields.Picture")]
            public string PictureUrl { get; set; }

            [ACResourceDisplayName("Admin.Catalog.Products.Pictures.Fields.DisplayOrder")]
            public int DisplayOrder { get; set; }

            [ACResourceDisplayName("Admin.Catalog.Products.Pictures.Fields.OverrideAltAttribute")]
            [AllowHtml]
            public string OverrideAltAttribute { get; set; }

            [ACResourceDisplayName("Admin.Catalog.Products.Pictures.Fields.OverrideTitleAttribute")]
            [AllowHtml]
            public string OverrideTitleAttribute { get; set; }
        }

        #endregion
    }
}