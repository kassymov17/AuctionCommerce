using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AC.Web.Framework.UI.Paging;

namespace AC.Web.Models.Catalog
{
    public partial class CatalogPagingFilteringModel : BasePageableModel
    {
        #region Конструктор

        public CatalogPagingFilteringModel()
        {
            this.AvailableSortOptions = new List<SelectListItem>();
            this.AvailableViewModes = new List<SelectListItem>();
            this.PageSizeOptions = new List<SelectListItem>();    
        }

        #endregion

        #region Свойства 

        public bool AllowItemSorting { get; set; }

        public IList<SelectListItem> AvailableSortOptions { get; set; }

        public bool AllowItemViewModeChanging { get; set; }

        public IList<SelectListItem> AvailableViewModes { get; set; }

        public bool AllowUsersToSelectPageSize { get; set; }

        public IList<SelectListItem> PageSizeOptions { get; set; }

        public int? OrderBy { get; set; }

        public string ViewMode { get; set; }

        #endregion
    }
}