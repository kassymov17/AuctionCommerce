using System.Collections.Generic;
using AC.Core.Domain.Localization;

namespace AC.Services.Localization
{
    /// <summary>
    /// Диспетчер локализации
    /// </summary>
    public partial interface ILocalizationService
    {
        /// <summary>
        /// Удаляет ресурсную строку
        /// </summary>
        /// <param name="localeStringResource">Строка ресурса</param>
        void DeleteLocaleStringResource(LocaleStringResource localeStringResource);
        
        /// <summary>
        /// Получить ресурсную строку по id
        /// </summary>
        /// <param name="localeStringResourceId">id ресурсной строки</param>
        /// <returns>Ресурсная строчка</returns>
        LocaleStringResource GetLocaleStringResourceById(int localeStringResourceId);

        /// <summary>
        /// Получить ресурсную строку по имени
        /// </summary>
        /// <param name="resourseName">имя строки</param>
        /// <returns></returns>
        LocaleStringResource GetLocaleStringResourceByName(string resourseName);

        /// <summary>
        /// Получить ресурсную строку
        /// </summary>
        /// <param name="resourceName">название</param>
        /// <param name="languageId">id языка</param>
        /// <param name="logIfNotFound">записать в логи, если не найдена ресурсная строка</param>
        /// <returns>Ресурсная строка</returns>
        LocaleStringResource GetLocaleStringResourceByName(string resourceName, int languageId, bool logIfNotFound = true);

        /// <summary>
        /// Получить все ресурсные строки по id языка
        /// </summary>
        /// <param name="languageId">id языка</param>
        /// <returns>Список строк</returns>
        IList<LocaleStringResource> GetAllResources(int languageId);

        /// <summary>
        /// Вставить ресурсную строкла
        /// </summary>
        /// <param name="localeStringResource">объект типа LocaleStringResource</param>
        void InsertLocaleStringResource(LocaleStringResource localeStringResource);
        
        /// <summary>
        /// Обновить ресурсную строку
        /// </summary>
        /// <param name="localeStringResource">Строка</param>
        void UpdateLocaleStringResource(LocaleStringResource localeStringResource);

        /// <summary>
        /// Получить все ресурсные строки по id языка
        /// </summary>
        /// <param name="languageId">id языка</param>
        /// <returns>Locale string resources</returns>
        Dictionary<string, KeyValuePair<int, string>> GetAllResourceValues(int languageId);

        /// <summary>
        /// Получает ресурсную строку по ключу
        /// </summary>
        /// <param name="resourceKey">ключ</param>
        /// <returns>Строка представляющая ресурсную строку</returns>
        string GetResource(string resourceKey);
        
        /// <summary>
        /// Получает ресурсную строку по ключу 
        /// </summary>
        /// <param name="resourceKey">ключ</param>
        /// <param name="languageId">id языка</param>
        /// <param name="logIfNotFound">записать в логи</param>
        /// <param name="defaultValue">значение по умолчанию</param>
        /// <param name="returnEmptyIfNotFound">показывать строку</param>
        /// <returns>Строка представляющая ресурсную</returns>
        string GetResource(string resourceKey, int languageId, bool logIfNotFound = true, string defaultValue = "", bool returnEmptyIfNotFound = false);
        
        /// <summary>
        /// Экспортировать ресурсники в xml
        /// </summary>
        /// <param name="language">Язык</param>
        /// <returns>Результат в xml формате</returns>
        // string ExportResourcesToXml(Language language);

        /// <summary>
        /// Импортировать ресурсники из xml файла
        /// </summary>
        /// <param name="language">Язык</param>
        /// <param name="xml">XML</param>
        // void ImportResourcesFromXml(Language language, string xml);
    }
}
