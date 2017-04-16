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
    }
}
