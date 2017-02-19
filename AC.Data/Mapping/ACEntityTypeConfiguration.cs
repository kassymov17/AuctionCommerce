using System.Data.Entity.ModelConfiguration;

namespace AC.Data.Mapping
{
    public abstract class ACEntityTypeConfiguration<T> : EntityTypeConfiguration<T> where T : class
    {
        protected ACEntityTypeConfiguration()
        {
            PostInitialize();
        }

        protected virtual void PostInitialize()
        {

        }
    }
}
