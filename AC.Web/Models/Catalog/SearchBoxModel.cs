
namespace AC.Web.Models.Catalog
{
    public partial class SearchBoxModel
    {
        public bool AutoCompleteEnabled { get; set; }
        public bool ShowItemImagesInSearchAutoComplete { get; set; }
        public int SearchTermMinimumLength { get; set; }
    }
}