using AC.Core.Infrastructure;

namespace AC.Web.Infrastructure.Mapper
{
    public class AutoMapperStartupTask : IStartupTask
    {
        public void Execute()
        {
            AutoMapperConfiguration.Init();
        }

        public int Order
        {
            get { return 0; }
        }
    }
}