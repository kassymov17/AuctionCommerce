using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AC.Core.Domain.Localization;
using AC.Data.Abstract;

namespace AC.Services.Localization
{
    public partial class LanguageService : ILanguageService
    {
        #region Поля

        private readonly IRepository<Language> _languageRepository;

        #endregion

        #region Конструктор

        public LanguageService(IRepository<Language> languageRepository)
        {
            _languageRepository = languageRepository;
        }

        #endregion

        #region Методы

        public virtual IList<Language> GetAllLanguages(bool showHidden = false)
        {
            var query = _languageRepository.Table;
            if (!showHidden)
                query = query.Where(l => l.Published);

            query = query.OrderBy(l => l.DisplayOrder);
            return query.ToList();
        }

        #endregion
    }
}
