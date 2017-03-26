using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AC.Core;
using AC.Data.Abstract;
using AC.Core.Domain.Localization;
using AC.Core.Data;
using AC.Data;

namespace AC.Services.Localization
{
    /// <summary>
    /// Предоставляет информацию о локализации
    /// </summary>
    public partial class LocalizationService : ILocalizationService
    {
        private readonly IRepository<LocaleStringResource> _lsrRepository;
        private readonly IWorkContext _workContext;
        // private readonly ILogger _logger;
        // private readonly ILanguageService _languageService;
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        // private readonly CommonSettings _commonSettings;
        // private readonly LocalizationSettings _localizationSettings;
        // private readonly IEventPublisher _eventPublisher;

        public LocalizationService(IRepository<LocaleStringResource> lsrRepository, IWorkContext workContext, IDataProvider dataProvider, IDbContext dbContext)
        {
            _lsrRepository = lsrRepository;
            _workContext = workContext;
            _dataProvider = dataProvider;
            _dbContext = dbContext;
        }

        #region Methods

        public virtual void DeleteLocaleStringResource(LocaleStringResource localeStringResource)
        {
            if (localeStringResource == null)
                throw new ArgumentNullException("localeStringResource");

            _lsrRepository.Delete(localeStringResource);

            // cache

            // уведомление
        }

        public virtual LocaleStringResource GetLocaleStringResourceById(int localeStringResourceId)
        {
            if (localeStringResourceId == 0)
                return null;

            return _lsrRepository.GetById(localeStringResourceId);
        }

        public virtual LocaleStringResource GetLocaleStringResourceByName(string resourceName)
        {
            if (_workContext.WorkingLanguage != null)
                // working language id изменить аргумент
                return GetLocaleStringResourceByName(resourceName, 1);

            return null;
        }

        public virtual LocaleStringResource GetLocaleStringResourceByName(string resourceName, int languageId,
            bool logIfNotFound = true)
        {
            var query = from lsr in _lsrRepository.Table
                orderby lsr.ResourceName
                where lsr.LanguageId == languageId && lsr.ResourceName == resourceName
                select lsr;

            var localeStringResource = query.FirstOrDefault();

            if (localeStringResource == null && logIfNotFound)
            {
                // [todo] записать в логи
            }

            return localeStringResource;
        }

        public virtual IList<LocaleStringResource> GetAllResources(int languageId)
        {
            var query = from l in _lsrRepository.Table
                orderby l.ResourceName
                where l.LanguageId == languageId
                select l;

            var locales = query.ToList();
            return locales;
        }


        public virtual void InsertLocaleStringResource(LocaleStringResource localeStringResource)
        {
            if(localeStringResource == null)
                throw new Exception("localeStringResource");

            _lsrRepository.Insert(localeStringResource);
        }

        public virtual void UpdateLocaleStringResource(LocaleStringResource localeStringResource)
        {
            if (localeStringResource == null)
                throw new ArgumentNullException("localeStringResource");

            _lsrRepository.Update(localeStringResource);
        }

        public virtual Dictionary<string, KeyValuePair<int, string>> GetAllResourceValues(int languageId)
        {
            var query = from l in _lsrRepository.TableNoTracking
                        orderby l.ResourceName
                        where l.LanguageId == languageId
                        select l;
            var locales = query.ToList();
            //format: <name, <id, value>>
            var dictionary = new Dictionary<string, KeyValuePair<int, string>>();
            foreach (var locale in locales)
            {
                var resourceName = locale.ResourceName.ToLowerInvariant();
                if (!dictionary.ContainsKey(resourceName))
                    dictionary.Add(resourceName, new KeyValuePair<int, string>(locale.Id, locale.ResourceValue));
            }
            return dictionary;
        }

        public virtual string GetResource(string resourceKey)
        {
            if (_workContext.WorkingLanguage != null)
                return GetResource(resourceKey, 1);

            return "";
        }

        public virtual string GetResource(string resourceKey, int languageId, bool logIfNotFound = true,
            string defaultValue = "", bool returnEmptyIfNotFound = false)
        {
            string result = string.Empty;
            if (resourceKey == null)
                resourceKey = string.Empty;
            resourceKey = resourceKey.Trim().ToLowerInvariant();

            var resources = GetAllResourceValues(languageId);
            if (resources.ContainsKey(resourceKey))
            {
                result = resources[resourceKey].Value;
            }

            if (String.IsNullOrEmpty(result))
            {
                if (!String.IsNullOrEmpty(defaultValue))
                {
                    result = defaultValue;
                }
                else
                {
                    if (!returnEmptyIfNotFound)
                        result = resourceKey;
                }
            }
            return result;
        }
        #endregion

    }
}
