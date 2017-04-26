using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AC.Services.Catalog;
using WebGrease;

namespace AC.Web.Helpers
{
    public static class SelectListHelper
    {
        public static List<SelectListItem> GetCategoryList(ICategoryService categoryService, bool showHidden = false)
        {

            var categories = categoryService.GetAllCategories(showHidden: showHidden);
            var categoryListItems = categories.Select(c => new SelectListItem
            {
                Text = c.GetFormattedBreadCrumb(categories),
                Value = c.Id.ToString()
            });


            var result = new List<SelectListItem>();
            //clone the list to ensure that "selected" property is not set
            foreach (var item in categoryListItems)
            {
                result.Add(new SelectListItem
                {
                    Text = item.Text,
                    Value = item.Value
                });
            }

            return result;
        }
    }
}