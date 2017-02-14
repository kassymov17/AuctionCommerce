using AC.Web.Controllers;
using AC.Core.Configuration;
using AC.Core.Infrastructure;
using AC.Core.Infrastructure.DependencyManagement;
using Autofac;
using Autofac.Core;


namespace AC.Web.Infrastructure
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder, ACConfig config)
        {
            builder.RegisterType<CommonController>();
        }

        public int Order
        {
            get { return 2; }
        }
    }
}