using System;
using System.Collections.Generic;
using AC.Core;
using AC.Core.Domain.Catalog;

namespace AC.Services.Catalog
{
    public partial interface IItemService
    {
        int GetNumberOfItemsInCategory(IList<int> categoryIds = null);

        IList<Item> GetAllItemsDisplayedOnHomePage();

        Item GetItemById(int itemId);

        void UpdateItem(Item item);

        void UpdateItems(IList<Item> items);

        void InsertItem(Item item);

        void InsertItemPicture(ItemPicture itemPicture);

        IList<ItemPicture> GetItemPicturesByItemId(int itemId);

        ItemPicture GetItemPictureById(int itemPictureId);

        void UpdateItemPicture(ItemPicture itemPicture);

        void DeleteItemPicture(ItemPicture itemPicture);

        IPagedList<Item> SearchItems(
            int pageIndex = 0,
            int pageSize = int.MaxValue,
            IList<int> categoryIds = null,
            ItemType? itemType = null,
            string keywords = null     
        );

        IList<Item> GetItemsByIds(int[] itemIds);

        void DeleteItems(IList<Item> items);
    }
}
