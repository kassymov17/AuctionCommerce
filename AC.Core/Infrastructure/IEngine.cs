using AC.Core.Configuration;
using AC.Core.Infrastructure.DependencyManagement;
using System;

namespace AC.Core.Infrastructure
{

    public interface IEngine
    {
        ContainerManager ContainerManager { get; }

        void Initialize(ACConfig config);

        T Resolve<T>() where T : class;

        object Resolve(Type type);

        T[] ResolveAll<T>();
    }
}
