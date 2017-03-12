using System.Data.Entity.ModelConfiguration;

namespace AC.Data.Mapping
{
    public abstract class ACEntityTypeConfiguration<T> : EntityTypeConfiguration<T> where T : class
    {
        protected ACEntityTypeConfiguration()
        {
            PostInitialize();
        }

        /// <summary>
        /// Developers can override this method in custom partial classes
        /// in order to add some custom initialization code to constructors
        /// </summary>
        protected virtual void PostInitialize()
        {

        }
    }
}
