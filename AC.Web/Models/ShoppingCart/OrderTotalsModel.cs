using System.Collections.Generic;
using AC.Web.Framework.Mvc;

namespace AC.Web.Models.ShoppingCart
{
    public partial class OrderTotalsModel
    {
        public string SubTotal { get; set; }

        public string OrderTotal { get; set; }

        //todo скидки, налоги, стоимость доставки
    }
}