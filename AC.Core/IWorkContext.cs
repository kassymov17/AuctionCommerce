using AC.Core.Domain.Localization;
using AC.Core.Domain.Users;

namespace AC.Core
{
    public interface IWorkContext
    {
        User CurrentUser { get; set; }

        User OriginalUserIfImpersonated { get; }

        Language WorkingLanguage { get; set; }
        
        /// <summary>
        /// Свойство показывающее находимся ли мы в админке
        /// </summary>
        bool IsAdmin { get; set; }
    }
}
