using AC.Core.Domain.Orders;

namespace AC.Data.Mapping.Orders
{
    public partial class OrderItemMap : ACEntityTypeConfiguration<OrderItem>
    {
        public OrderItemMap()
        {
            this.ToTable("OrderItem");
            this.HasKey(oi => oi.Id);

            this.HasRequired(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId);

            this.HasRequired(oi => oi.Item)
                .WithMany()
                .HasForeignKey(oi => oi.ItemId);
        }
    }
}
