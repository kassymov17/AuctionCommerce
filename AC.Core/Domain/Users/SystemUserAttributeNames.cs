
namespace AC.Core.Domain.Users
{
    public static partial class SystemUserAttributeNames
    {
        // поля формы
        public static string FirstName { get { return "FirstName"; } }
        public static string LastName { get { return "LastName"; } }
        public static string Gender { get { return "Gender"; } }

        // другие аттрибуты
        public static string ImpersonatedUserId { get { return "ImpersonatedUserId"; } }
        public static string LanguageAutomaticallyDetected { get { return "LanguageAutomaticallyDetected"; } }
        public static string LanguageId { get { return "LanguageId"; } }
    }
}
