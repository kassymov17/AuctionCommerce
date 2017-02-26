using AC.Data.Entities.Common;
using FluentNHibernate.Mapping;

namespace AC.Data.Entities.Mapping
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.UserId);
            Map(x => x.Name);
            Map(x => x.Login);
            Map(x => x.Email);
            Map(x => x.PhoneNumber);
            Map(x => x.Password);
            Map(x => x.Rating);
        }
    }
}
