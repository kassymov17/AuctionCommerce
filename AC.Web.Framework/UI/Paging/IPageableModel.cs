
namespace AC.Web.Framework.UI.Paging
{
    public interface IPageableModel
    {
        int PageIndex { get; }

        int PageNumber { get; set; }

        int PageSize { get; set; }
        
        int TotalItems { get; set; }

        int TotalPages { get; set; }
        
        int FirstItem { get; }

        int LastItem { get; }

        bool HasPreviousPage { get; }

        bool HasNextPage { get; }
    }

    public interface IPagination<T> : IPageableModel
    {
    
    }
}
