using AC.Core.Domain.Users;

namespace AC.Data.Mapping.Users
{
    public partial class UserRoleMap : ACEntityTypeConfiguration<UserRole>
    {
        public UserRoleMap()
        {
            this.ToTable("UserRole");
            this.HasKey(ur => ur.Id);
            this.Property(ur => ur.Name).IsRequired().HasMaxLength(255);
            this.Property(ur => ur.SystemName).IsRequired().HasMaxLength(255);
        }
    }
}
