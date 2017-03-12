using System.Data.Common;

namespace AC.Core.Data
{
    public interface IDataProvider
    {
        /// <summary>
        /// Инициализация фабрики
        /// </summary>
        void InitConnectionFactory();
        
        /// <summary>
        /// Значение показывающее поддерживает ли поставщик данных хранимые процедуры
        /// </summary>
        bool StoredProceduredSupported { get; }

        /// <summary>
        /// Значение показывающее поддержку бэкапа 
        /// </summary>
        bool BackupSupported { get; }

        /// <summary>
        /// Получить параметр
        /// </summary>
        /// <returns>Параметр бд</returns>
        DbParameter GetParameter();

        /// <summary>
        /// Maximum length of the data for HASHBYTES functions
        /// returns 0 if HASHBYTES function is not supported
        /// </summary>
        /// <returns>Length of the data for HASHBYTES functions</returns>
        int SupportedLengthOfBinaryHash();
    }
}
