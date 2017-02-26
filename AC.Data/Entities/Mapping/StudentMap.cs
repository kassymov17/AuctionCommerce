using AC.Data.Entities.Common;
using FluentNHibernate.Mapping;

namespace AC.Data.Entities.Mapping
{
    class StudentMap : ClassMap<Student>
    {
        public StudentMap()
        {
            Id(x => x.ID);
            Map(x => x.Name);
            Map(x => x.IsBlabla);
        }
    }
}
