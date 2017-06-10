using System.Web;

namespace AC.Core
{
    public partial interface IWebHelper
    {
        string GetThisPageUrl(bool includeQueryString);

        string GetStoreHost();

        string ServerVariables(string name);

        string ModifyQueryString(string url, string queryStringModification, string anchor);

        string RemoveQueryString(string url, string queryString);
    }
}
