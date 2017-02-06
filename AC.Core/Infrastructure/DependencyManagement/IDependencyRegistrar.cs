using Autofac;
using AC.Core.Configuration;

namespace AC.Core.Infrastructure.DependencyManagement
{
    public interface IDependencyRegistrar
    {
        void Register(ContainerBuilder builder, ITypeFinder typeFinder, ACConfig config);

        int Order { get; }
    }
}
