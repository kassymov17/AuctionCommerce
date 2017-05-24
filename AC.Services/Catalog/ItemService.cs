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
        private readonly IRepository<ItemPicture> _itemPictureRepository;

        #endregion

        #region Конструктор

        public ItemService(IRepository<Item> itemRepository, IRepository<ItemPicture> itemPictureRepository)
        {
            _itemRepository = itemRepository;
            _itemPictureRepository = itemPictureRepository;
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
    }
}
