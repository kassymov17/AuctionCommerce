using System.Collections.Generic;

namespace AC.Core.Domain.Localization
{
    public partial class Language : BaseEntity
    {
        private ICollection<LocaleStringResource> _localeStringResources;

        public string Name { get; set; }

        public string LanguageCulture { get; set; }

        public string UniqueSeoCode { get; set; }

        public string FlagImageFileName { get; set; }

        public bool Published { get; set; }

        public int DisplayOrder { get; set; }

        public virtual ICollection<LocaleStringResource> LocaleStringResources
        {
            get { return _localeStringResources ?? (_localeStringResources = new List<LocaleStringResource>()); }
            protected set { _localeStringResources = value; }
        }
    }
}
