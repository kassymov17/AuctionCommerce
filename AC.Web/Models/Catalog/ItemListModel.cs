using System.Collections.Generic;
using System.Web.Mvc;
using AC.Web.Framework;

namespace AC.Web.Models.Catalog
{
    public partial class ItemListModel
    {
        public ItemListModel()
        {
            AvailableCategories = new List<SelectListItem>();
            AvailableItemTypes = new List<SelectListItem>();
        }
        [ACResourceDisplayName("Admin.Catalog.Products.List.SearchProductName")]
        [AllowHtml]
        public string SearchItemName { get; set; }
        [ACResourceDisplayName("Admin.Catalog.Products.List.SearchCategory")]
        public int SearchCategoryId { get; set; }
        [ACResourceDisplayName("Admin.Catalog.Products.List.SearchProductType")]
        public int SearchItemTypeId { get; set; }

        public IList<SelectListItem> AvailableCategories { get; set; }
        public IList<SelectListItem> AvailableItemTypes { get; set; }
    }
}