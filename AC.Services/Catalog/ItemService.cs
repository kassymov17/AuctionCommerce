using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AC.Core.Domain.Catalog;
using AC.Data.Abstract;

namespace AC.Services.Catalog
{
    public partial class ItemService : IItemService
    {
        #region Поля 

        private readonly IRepository<Item> _itemRepository;

        #endregion

        #region Конструктор

        public ItemService(IRepository<Item> itemRepository)
        {
            _itemRepository = itemRepository;
        }

        #endregion

        public virtual int GetNumberOfItemsInCategory(IList<int> categoryIds = null)
        {
            if (categoryIds != null && categoryIds.Contains(0))
                categoryIds.Remove(0);

            var query = _itemRepository.Table;
            query = query.Where(i => !i.Deleted && i.Published);

            if (categoryIds != null && categoryIds.Any())
            {
                query = from i in query
                    from ic in i.ItemCategories.Where(ic => categoryIds.Contains(ic.CategoryId))
                    select i;
            }

            var result = query.Select(i => i.Id).Distinct().Count();
            return result;
        }

        public virtual IList<Item> GetAllItemsDisplayedOnHomePage()
        {
            var query = from i in _itemRepository.Table
                orderby i.Name
                where i.Published && !i.Deleted
                      && i.ShowOnHomePage
                select i;

            var items = query.ToList();
            return items;
        }
    }
}
