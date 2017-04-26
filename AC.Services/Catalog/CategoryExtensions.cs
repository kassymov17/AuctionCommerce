using System;
using System.Collections.Generic;
using System.Linq;
using AC.Core.Domain.Catalog;

namespace AC.Services.Catalog
{
    public static class CategoryExtensions
    {
        /// <summary>
        /// Древовидное содержание категорий
        /// </summary>
        /// <param name="source">Список категорий</param>
        /// <param name="parentId">id родителя</param>
        /// <param name="ignoreCategoriesWithoutExistingParent">Игнорировать категории без существующего родителя</param>
        /// <returns></returns>
        public static IList<Category> SortCategoriesForTree(this IList<Category> source, int parentId = 0,
            bool ignoreCategoriesWithoutExistingParent = false)
        {
            if(source == null)
                throw new ArgumentNullException("source");

            var result = new List<Category>();

            foreach (var cat in source.Where(c => c.ParentCategoryId == parentId).ToList())
            {
                result.Add(cat);
                result.AddRange(SortCategoriesForTree(source, cat.Id, true));
            }

            if (!ignoreCategoriesWithoutExistingParent && result.Count != source.Count)
            {
                foreach (var cat in source)
                    if(result.FirstOrDefault(x => x.Id == cat.Id) == null)
                        result.Add(cat);
            }
            return result;
        }

        public static string GetFormattedBreadCrumb(this Category category,
            IList<Category> allCategories,
            string separator = ">>", int languageId = 0)
        {
            string result = string.Empty;

            var breadcrumb = GetCategoryBreadCrumb(category, allCategories, true);
            for (int i = 0; i <= breadcrumb.Count - 1; i++)
            {
                var categoryName = breadcrumb[i].Name;
                result = String.IsNullOrEmpty(result)
                    ? categoryName
                    : string.Format("{0} {1} {2}", result, separator, categoryName);
            }

            return result;
        }

        public static IList<Category> GetCategoryBreadCrumb(this Category category,
            IList<Category> allCategories,
            bool showHidden = false)
        {
            if (category == null)
                throw new ArgumentNullException("category");

            var result = new List<Category>();

            //used to prevent circular references
            var alreadyProcessedCategoryIds = new List<int>();

            while (category != null && //not null
                !category.Deleted && //not deleted
                (showHidden || category.Published) && //published
                !alreadyProcessedCategoryIds.Contains(category.Id)) //prevent circular references
            {
                result.Add(category);

                alreadyProcessedCategoryIds.Add(category.Id);

                category = (from c in allCategories
                            where c.Id == category.ParentCategoryId
                            select c).FirstOrDefault();
            }
            result.Reverse();
            return result;
        }
    }
}
