using AC.Core.Domain.Orders;

namespace AC.Data.Mapping.Orders
{
    public partial class OrderMap : ACEntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            this.ToTable("Order");
            this.HasKey(o => o.Id);
            this.Property(o => o.OrderTotal).HasPrecision(18, 4);

            this.Ignore(o => o.OrderStatus);

            this.HasRequired(o => o.User)
                .WithMany()
                .HasForeignKey(o => o.UserId);
        }
    }
}
