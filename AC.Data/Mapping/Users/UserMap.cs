using AC.Core.Domain.Users;

namespace AC.Data.Mapping.Users
{
    public partial class UserMap : ACEntityTypeConfiguration<User>
    {
        public UserMap()
        {
            this.ToTable("User");
            this.HasKey(u => u.Id);
            this.Property(u => u.Username).HasMaxLength(100);
            this.Property(u => u.Email).HasMaxLength(100);

            this.Ignore(u => u.PasswordFormat);

            this.HasMany(u => u.UserRoles)
                .WithMany()
                .Map(m => m.ToTable("User_UserRole_Mapping"));

            // [todo] связи с товарами
        }
    }
}
