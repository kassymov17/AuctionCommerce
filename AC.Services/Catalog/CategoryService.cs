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
        private readonly IRepository<ItemCategory> _itemCategoryRepository;
        private readonly IRepository<Item> _itemRepository;

        private readonly IWorkContext _workContext;

        #endregion

        #region Конструктор

        public CategoryService(IRepository<Item> itemRepository, IRepository<ItemCategory> itemCategoryRepository, IRepository<Category> categoryRepository, IWorkContext workContext)
        {
            _itemCategoryRepository = itemCategoryRepository;
            _categoryRepository = categoryRepository;
            _itemRepository = itemRepository;
            _workContext = workContext;
        }

        #endregion

        #region Методы

        public virtual IList<ItemCategory> GetItemCategoriesByItemId(int itemId, bool showHidden = false)
        {
            if (itemId == 0)
                return new List<ItemCategory>();


            var query = from pc in _itemCategoryRepository.Table
                        join c in _categoryRepository.Table on pc.CategoryId equals c.Id
                        where pc.ItemId == itemId &&
                              !c.Deleted &&
                              (showHidden || c.Published)
                        orderby pc.DisplayOrder
                        select pc;

            var allItemCategories = query.ToList();
            var result = new List<ItemCategory>();
            if (!showHidden)
            {
                foreach (var pc in allItemCategories)
                {
                    result.Add(pc);
                }
            }
            else
            {
                // без фильтра
                result.AddRange(allItemCategories);
            }
            return result;
        }

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

        public virtual void DeleteItemCategory(ItemCategory itemCategory)
        {
            if(itemCategory == null)
                throw new ArgumentNullException("itemCategory");

            _itemCategoryRepository.Delete(itemCategory);
        }

        public virtual IPagedList<ItemCategory> GetItemCategoriesByCategoryId(int categoryId, int pageIndex = 0,
            int pageSize = int.MaxValue, bool showHidden = false)
        {
            if (categoryId == 0)
                return new PagedList<ItemCategory>(new List<ItemCategory>(), pageIndex, pageSize);

            var query = from ic in _itemCategoryRepository.Table
                        join i in _itemRepository.Table on ic.ItemId equals i.Id
                        where ic.CategoryId == categoryId &&
                              !i.Deleted &&
                              (showHidden || i.Published)
                        orderby ic.DisplayOrder
                        select ic;

            if (!showHidden)
            {
                query = from c in query
                    group c by c.Id
                    into cGroup
                    orderby cGroup.Key
                    select cGroup.FirstOrDefault();

                query = query.OrderBy(ic => ic.DisplayOrder);
            }

            var itemCategories = new PagedList<ItemCategory>(query, pageIndex, pageSize);
            return itemCategories;
        }

        public virtual void InsertItemCategory(ItemCategory itemCategory)
        {
            if (itemCategory == null)
                throw new ArgumentNullException("itemCategory");

            _itemCategoryRepository.Insert(itemCategory);
        }

        public virtual Category GetCategoryById(int categoryId)
        {
            if (categoryId == 0)
                return null;

            return _categoryRepository.GetById(categoryId);
        }

        #endregion
    }
}
