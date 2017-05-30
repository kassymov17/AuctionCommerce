using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AC.Core;
using AC.Core.Domain.Catalog;
using AC.Data.Abstract;

namespace AC.Services.Catalog
{
    public partial class ItemService : IItemService
    {
        #region Поля 

        private readonly IRepository<Item> _itemRepository;
        private readonly IRepository<ItemPicture> _itemPictureRepository;
        private readonly IWorkContext _workContext;

        #endregion

        #region Конструктор

        public ItemService(IRepository<Item> itemRepository, IRepository<ItemPicture> itemPictureRepository, IWorkContext workContext)
        {
            _itemRepository = itemRepository;
            _itemPictureRepository = itemPictureRepository;
            _workContext = workContext;
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

        public virtual Item GetItemById(int itemId)
        {
            if (itemId == 0)
                return null;

            return _itemRepository.GetById(itemId);
        }

        public virtual void UpdateItem(Item item)
        {
            if(item == null)
                throw new ArgumentNullException("item");

            _itemRepository.Update(item);
        }

        public virtual void InsertItem(Item item)
        {
            if(item == null)
                throw new ArgumentNullException("item");

            _itemRepository.Insert(item);
        }

        public virtual void InsertItemPicture(ItemPicture itemPicture)
        {
            if (itemPicture == null)
                throw new ArgumentNullException("itemPicture");

            _itemPictureRepository.Insert(itemPicture);
        }


        public virtual IList<ItemPicture> GetItemPicturesByItemId(int itemId)
        {
            var query = from ip in _itemPictureRepository.Table
                where ip.ItemId == itemId
                orderby ip.DisplayOrder
                select ip;

            var itemPictures = query.ToList();
            return itemPictures;
        }

        public virtual ItemPicture GetItemPictureById(int itemPictureId)
        {
            if (itemPictureId == 0)
                return null;

            return _itemPictureRepository.GetById(itemPictureId);
        }

        public virtual void UpdateItemPicture(ItemPicture itemPicture)
        {
            if(itemPicture == null)
                throw new ArgumentNullException("itemPicture");

            _itemPictureRepository.Update(itemPicture);
        }

        public virtual void DeleteItemPicture(ItemPicture itemPicture)
        {
            if(itemPicture == null)
                throw new ArgumentNullException("itemPicture");

            _itemPictureRepository.Delete(itemPicture);
        }

        public virtual IPagedList<Item> SearchItems(
            int pageIndex = 0,
            int pageSize = int.MaxValue,
            IList<int> categoryIds = null,
            ItemType? itemType = null,
            string keywords = null
        )
        {
            if (categoryIds != null && categoryIds.Contains(0))
                categoryIds.Remove(0);

            // товары через linq запросы
            var query = _itemRepository.Table.Where(i => i.User.Id == _workContext.CurrentUser.Id);
            query = query.Where(i => !i.Deleted);

            if (itemType.HasValue)
            {
                var itemTypeId = (int) itemType.Value;
                query = query.Where(i => i.ItemTypeId == itemTypeId);
            }

            // поиск по ключевым словам
            if (!String.IsNullOrWhiteSpace(keywords))
            {
                query = from i in query
                    where (i.Name.Contains(keywords))
                    select i;
            }

            if (categoryIds != null && categoryIds.Any())
            {
                query = from i in query
                        from ic in i.ItemCategories.Where(ic => categoryIds.Contains(ic.CategoryId))
                        select i;
            }

            query = from i in query
                group i by i.Id
                into iGroup
                orderby iGroup.Key
                select iGroup.FirstOrDefault();

            var items = new PagedList<Item>(query, pageIndex, pageSize);

            return items;
        }

        public virtual IList<Item> GetItemsByIds(int[] itemIds)
        {
            if (itemIds == null || itemIds.Length == 0)
                return new List<Item>();

            var query = from i in _itemRepository.Table
                        where itemIds.Contains(i.Id)
                        select i;

            var items = query.ToList();

            var sortedItems = new List<Item>();
            foreach (int id in itemIds)
            {
                var item = items.Find(x => x.Id == id);
                if(item != null)
                    sortedItems.Add(item);
            }
            return sortedItems;
        }

        public virtual void DeleteItems(IList<Item> items)
        {
            if(items == null)
                throw new ArgumentNullException("items");

            foreach (var item in items)
            {
                item.Deleted = true;
            }
            // обновить
            UpdateItems(items);
        }

        public virtual void UpdateItems(IList<Item> items)
        {
            if(items == null)
                throw new ArgumentNullException("items");

            // обновить
            _itemRepository.Update(items);
        }
    }
}
