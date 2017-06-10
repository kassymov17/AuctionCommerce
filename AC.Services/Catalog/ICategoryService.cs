using System.Collections.Generic;
using AC.Core;
using AC.Core.Domain.Catalog;

namespace AC.Services.Catalog
{
    // [todo] пагинатор написать заменить им IList
    public partial interface ICategoryService
    {
        /// <summary>
        /// Получить все категории
        /// </summary>
        /// <param name="categoryName">Имя категории</param>
        /// <param name="pageIndex">Индекс страницы</param>
        /// <param name="pageSize">Размер страницы</param>
        /// <param name="showHidden">Показывать скрытые поля?</param>
        /// <returns>Категории</returns>
        IPagedList<Category> GetAllCategories(string categoryName = "", int pageIndex = 0, int pageSize = int.MaxValue,
            bool showHidden = false);

        /// <summary>
        /// Получить все подкатегории по id родителя
        /// </summary>
        /// <param name="parentCategoryId">id родителя</param>
        /// <param name="showHidden">показывать скрытые поля?</param>
        /// <param name="includeAllLevels">загружать все уровни-потомки?</param>
        /// <returns></returns>
        IList<Category> GetAllCategoriesByParentCategoryId(int parentCategoryId, bool showHidden = false,
            bool includeAllLevels = false);

        /// <summary>
        /// Показывать все категории главной страницы
        /// </summary>
        /// <param name="showHidden">Показывать скрытые поля?</param>
        /// <returns>Категории</returns>
        IList<Category> GetAllCategoriesDisplayedOnHomePage(bool showHidden = false);

        IList<ItemCategory> GetItemCategoriesByItemId(int itemId, bool showHidden = false);

        void DeleteItemCategory(ItemCategory itemCategory);

        IPagedList<ItemCategory> GetItemCategoriesByCategoryId(int categoryId, int pageIndex = 0,
            int pageSize = int.MaxValue, bool showHidden = false);

        void InsertItemCategory(ItemCategory itemCategory);

        Category GetCategoryById(int categoryId);
    }
}
