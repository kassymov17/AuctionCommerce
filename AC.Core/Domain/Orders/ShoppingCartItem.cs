using System;
using AC.Core.Domain.Catalog;
using AC.Core.Domain.Users;

namespace AC.Core.Domain.Orders
{
    public partial class ShoppingCartItem : BaseEntity
    {
        public int ShoppingCartTypeId { get; set; }

        public int UserId { get; set; } // покупатель

        public int ItemId { get; set; }

        public int Quantity { get; set; }

        public DateTime CreatedOnUtc { get; set; }

        public DateTime UpdatedOnUtc { get; set; }

        public ShoppingCartType ShoppingCartType
        {
            get
            {
                return (ShoppingCartType) ShoppingCartTypeId;
            }
            set
            {
                this.ShoppingCartTypeId = (int) value;
            }
        }

        public virtual Item Item { get; set; }

        public virtual User User { get; set; }
    }
}
