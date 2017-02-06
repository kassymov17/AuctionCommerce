﻿using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using AC.Core.Configuration;
using AC.Core.Infrastructure;
using AC.Core.Infrastructure.DependencyManagement;
using Autofac;
using Autofac.Integration.Mvc;

namespace AC.Core.Infrastructure
{
    public class ACEngine : IEngine
    {
        #region Fields

        private ContainerManager _containerManager;

        #endregion

        #region Utilities

        protected virtual void RunStartupTasks()
        {
            var typeFinder = _containerManager.Resolve<ITypeFinder>();
            var startUpTaskTypes = typeFinder.FindClassesOfType<IStartupTask>();
            var startUpTasks = new List<IStartupTask>();
            foreach(var startUpTaskType in startUpTaskTypes)
            {
                startUpTasks.Add((IStartupTask)Activator.CreateInstance(startUpTaskType));
            }
            // sort
            startUpTasks = startUpTasks.AsQueryable().OrderBy(st => st.Order).ToList();
            foreach(var startUpTask in startUpTasks)
            {
                startUpTask.Execute();
            }
        }

        /// <summary>
        ///  register dependecies
        /// </summary>
        /// <param name="config">Config</param>
        protected virtual void RegisterDependencies(ACConfig config)
        {
            var builder = new ContainerBuilder();
            var container = builder.Build();
            this._containerManager = new ContainerManager(container);

            //dependecies
            builder = new ContainerBuilder();
            builder.RegisterInstance(config).As<ACConfig>().SingleInstance();
            builder.RegisterInstance(this).As<IEngine>().SingleInstance();
            builder.Update(container);
            
            // set dependency resolver
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        #endregion

        #region Methods

        public void Initialize(ACConfig config)
        {
            // зарегистрировать зависимости
            //RegisterDependencies(config);

            // стартовые задачи
            if (!config.IgnoreStartupTasks)
            {
                RunStartupTasks();
            }
        }

        public T Resolve<T>() where T : class
        {
            return ContainerManager.Resolve<T>();
        }

        public object Resolve(Type type)
        {
            return ContainerManager.Resolve(type);
        }

        public T[] ResolveAll<T>()
        {
            return ContainerManager.ResolveAll<T>();
        }

        
        #endregion

        #region Properties

        public ContainerManager ContainerManager
        {
            get { return _containerManager; }
        }

        #endregion
    }
}
