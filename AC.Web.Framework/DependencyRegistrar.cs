using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Autofac;
using Autofac.Builder;
using Autofac.Core;
using Autofac.Integration.Mvc;
using AC.Core.Infrastructure.DependencyManagement;
using AC.Core.Infrastructure;
using AC.Core.Configuration;
using AC.Web.Framework.UI;
using AC.Data;
using AC.Core.Data;
using AC.Services.Topics;

namespace AC.Web.Framework
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder, ACConfig config)
        {
            // controllers
            builder.RegisterControllers(typeFinder.GetAssemblies().ToArray());

            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerMatchingLifetimeScope();

            // services
            builder.RegisterType<PageHeadBuilder>().As<IPageHeadBuilder>().InstancePerLifetimeScope();
            builder.RegisterType<TopicService>().As<ITopicService>().InstancePerLifetimeScope();
        }

        public int Order
        {
            get { return 0; }
        }
    }
}
