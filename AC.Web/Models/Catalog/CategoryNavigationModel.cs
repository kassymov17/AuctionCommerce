﻿using System.Collections.Generic;
using AC.Web.Framework.Mvc;

namespace AC.Web.Models.Catalog
{
    public partial class CategoryNavigationModel
    {
        public CategoryNavigationModel()
        {
            Categories = new List<CategorySimpleModel>();
        }

        public int CurrentCategoryId { get; set; }
        public List<CategorySimpleModel> Categories { get; set; }
    }
}