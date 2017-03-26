using System.Collections.Generic;
using AC.Core.Domain.Localization;

namespace AC.Services.Localization
{
    public partial interface ILanguageService
    {
        IList<Language> GetAllLanguages(bool showHidden = false);
    }
}
