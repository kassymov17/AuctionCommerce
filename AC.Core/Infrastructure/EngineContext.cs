using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AC.Core.Configuration;

namespace AC.Core.Infrastructure
{
    public class EngineContext
    {
        #region Methods
        /// <summary>
        /// инициализация статического экземпляра фабрики
        /// </summary>
        /// <param name="forceRecreate">Создает новый экземпляр фабрики</param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static IEngine Initialize(bool forceRecreate)
        {
            if (Singleton<IEngine>.Instance == null || forceRecreate)
            {
                Singleton<IEngine>.Instance = new ACEngine();

                var config = ConfigurationManager.GetSection("ACConfig") as ACConfig;
                Singleton<IEngine>.Instance.Initialize(config);
            }
            return Singleton<IEngine>.Instance;
        }

        #endregion

        #region Properties
        
        /// <summary>
        /// Паттерн синглтон-одиночка
        /// </summary>
        public static IEngine Current
        {
            get
            {
                if (Singleton<IEngine>.Instance == null)
                {
                    Initialize(false);
                }
                return Singleton<IEngine>.Instance;
            }
        }
        #endregion
    }
}
