using System.Configuration;
using System.Runtime.CompilerServices;
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


        /// <summary>
        /// Sets the static engine instance to the supplied engine. Use this method to supply your own engine implementation.
        /// </summary>
        /// <param name="engine">The engine to use.</param>
        /// <remarks>Only use this method if you know what you're doing.</remarks>
        public static void Replace(IEngine engine)
        {
            Singleton<IEngine>.Instance = engine;
        }


        #endregion

        #region Properties

        /// <summary>
        /// Gets the singleton Nop engine used to access Nop services.
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
