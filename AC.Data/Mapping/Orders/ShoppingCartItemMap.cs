using AC.Core.Domain.Orders;

namespace AC.Data.Mapping.Orders
{
    public partial class ShoppingCartItemMap : ACEntityTypeConfiguration<ShoppingCartItem>
    {
        public ShoppingCartItemMap()
        {
            this.ToTable("ShoppingCartItem");
            this.HasKey(sci => sci.Id);

            this.Ignore(sci => sci.ShoppingCartType);

            this.HasRequired(sci => sci.User)
                .WithMany(u => u.ShoppingCartItems)
                .HasForeignKey(sci => sci.UserId);

            this.HasRequired(sci => sci.Item)
                .WithMany()
                .HasForeignKey(sci => sci.ItemId);
        }
    }
}
