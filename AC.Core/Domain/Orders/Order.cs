using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AC.Core.Domain.Users;

namespace AC.Core.Domain.Orders
{
    public partial class Order : BaseEntity
    {
        private ICollection<OrderNote> _orderNotes;
        private ICollection<OrderItem> _orderItems;

        public Guid OrderGuid { get; set; }

        public int UserId { get; set; }

        public int OrderStatusId { get; set; }

        public decimal OrderTotal { get; set; }

        public string UserIp { get; set; }

        public bool Deleted { get; set; }

        public DateTime CreatedOnUtc { get; set; }

        #region Навигационные свойства

        public virtual User User { get; set; }

        public virtual ICollection<OrderNote> OrderNotes
        {
            get { return _orderNotes ?? (_orderNotes = new List<OrderNote>()); }
            protected set { _orderNotes = value; }
        }

        public virtual ICollection<OrderItem> OrderItems
        {
            get { return _orderItems ?? (_orderItems = new List<OrderItem>()); }
            protected set { _orderItems = value; }
        }

        #endregion

        public OrderStatus OrderStatus
        {
            get
            {
                return (OrderStatus)this.OrderStatusId;
            }
            set
            {
                this.OrderStatusId = (int) value;
            }
        }
    }
}
