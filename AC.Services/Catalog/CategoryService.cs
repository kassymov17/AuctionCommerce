using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using AC.Core;
using AC.Core.Domain.Catalog;
using AC.Data.Abstract;

namespace AC.Services.Catalog
{
    public partial class CategoryService : ICategoryService
    {
        #region Поля

        private readonly IRepository<Category> _categoryRepository;
        private readonly IWorkContext _workContext;

        #endregion

        #region Конструктор

        public CategoryService(IRepository<Category> categoryRepository, IWorkContext workContext)
        {
            _categoryRepository = categoryRepository;
            _workContext = workContext;
        }

        #endregion

        #region Методы

        public virtual IPagedList<Category> GetAllCategories(string categoryName = "", int pageIndex = 0,
            int pageSize = int.MaxValue, bool showHidden = false)
        {
            var query = _categoryRepository.Table;
            if (!showHidden)
                query = query.Where(c => c.Published);
            if (!String.IsNullOrWhiteSpace(categoryName))
                query = query.Where(c => c.Name.Contains(categoryName));
            query = query.Where(c => !c.Deleted);
            query = query.OrderBy(c => c.ParentCategoryId).ThenBy(c => c.DisplayOrder);

            query = from c in query
                    group c by c.Id
                       into cGroup
                    orderby cGroup.Key
                    select cGroup.FirstOrDefault();
            query = query.OrderBy(c => c.ParentCategoryId).ThenBy(c => c.DisplayOrder);

            var unsortedCategories = query.ToList();

            //sort categories
            var sortedCategories = unsortedCategories.SortCategoriesForTree();

            // пагинация
            return new PagedList<Category>(sortedCategories, pageIndex, pageSize);
        }

        public virtual IList<Category> GetAllCategoriesByParentCategoryId(int parentCategoryId, bool showHidden = false,
            bool includeAllLevels = false)
        {
            var query = _categoryRepository.Table;
            if (!showHidden)
                query = query.Where(c => c.Published);
            query = query.Where(c => c.ParentCategoryId == parentCategoryId);
            query = query.Where(c => !c.Deleted);
            query = query.OrderBy(c => c.DisplayOrder);

            var categories = query.ToList();
            if (includeAllLevels)
            {
                var childCategories = new List<Category>();
                foreach (var category in categories)
                {
                    childCategories.AddRange(GetAllCategoriesByParentCategoryId(category.Id, showHidden, includeAllLevels));
                }
                categories.AddRange(childCategories);
            }
            return categories;
        }

        public virtual IList<Category> GetAllCategoriesDisplayedOnHomePage(bool showHidden = false)
        {
            var query = from c in _categoryRepository.Table
                orderby c.DisplayOrder
                where c.Published && !c.Deleted
                      && c.ShowOnHomePage
                select c;

            var categories = query.ToList();

            return categories;
        }

        #endregion
    }
}
