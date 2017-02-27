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
using AC.Core.Data;
using AC.Data.Abstract;
using AC.Data.Concrete;
using AC.Services.Topics;

namespace AC.Web.Framework
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder, ACConfig config)
        {
            // controllers
            builder.RegisterControllers(typeFinder.GetAssemblies().ToArray());

            // data layer

            builder.Register<IUnitOfWork>(c => new UnitOfWork()).InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
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
