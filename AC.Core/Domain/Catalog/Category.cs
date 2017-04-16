using System;
using System.Collections.Generic;

namespace AC.Core.Domain.Catalog
{
    public partial class Category : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string MetaKeywords { get; set; }

        public string MetaDescription { get; set; }

        public string MetaTitle { get; set; }

        public int ParentCategoryId { get; set; }

        public int PictureId { get; set; }

        public int PageSize { get; set; }

        public bool AllowUsersToSelectPages { get; set; }

        public string PageSizeOptions { get; set; }

        public string PriceRanges { get; set; }

        public bool ShowOnHomePage { get; set; }

        public bool IncludeInTopMenu { get; set; }

        public bool Published { get; set; }

        public bool Deleted { get; set; }

        public int DisplayOrder { get; set; }

        public DateTime CreatedOnUtc { get; set; }
        
        public DateTime UpdatedOnUtc { get; set; } 
    }
}
