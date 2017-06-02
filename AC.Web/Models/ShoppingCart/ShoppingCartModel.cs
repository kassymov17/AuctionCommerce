using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AC.Web.Framework.Mvc;
using AC.Web.Models.Media;

namespace AC.Web.Models.ShoppingCart
{
    public partial class ShoppingCartModel
    {
        public ShoppingCartModel()
        {
            Items = new List<ShoppingCartItemModel>();    
        }

        public IList<ShoppingCartItemModel> Items { get; set; }
        public IList<string> Warnings { get; set; }
        
        #region Вложенный класс

        public partial class ShoppingCartItemModel : BaseACEntityModel
        {
            public PictureModel Picture { get; set; }    

            public int ItemId { get; set; }

            public string ItemName { get; set; }

            public string UnitPrice { get; set; }

            public string SubTotal { get; set; }

            public int Quantity { get; set; }
            
            public IList<string> Warnings { get; set; }
        }
        
        #endregion
    }
}