using System;
using System.Collections.Generic;
using AC.Core.Domain.Catalog;

namespace AC.Services.Catalog
{
    public partial interface IItemService
    {
        int GetNumberOfItemsInCategory(IList<int> categoryIds = null);

        IList<Item> GetAllItemsDisplayedOnHomePage();

        Item GetItemById(int itemId);

        void UpdateItem(Item item);

        void InsertItem(Item item);

        void InsertItemPicture(ItemPicture itemPicture);

        IList<ItemPicture> GetItemPicturesByItemId(int itemId);

        ItemPicture GetItemPictureById(int itemPictureId);

        void UpdateItemPicture(ItemPicture itemPicture);

        void DeleteItemPicture(ItemPicture itemPicture);
    }
}
