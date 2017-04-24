using System.Web.Compilation;
using AC.Core;
using AC.Core.Infrastructure;
using AC.Services.Localization;
using AC.Web.Framework.Mvc;
using Antlr.Runtime;

namespace AC.Web.Framework
{
    public class ACResourceDisplayName : System.ComponentModel.DisplayNameAttribute, IModelAttribute
    {
        private string _resourceValue = string.Empty;

        public ACResourceDisplayName(string resourceKey) : base(resourceKey)
        {
            ResourceKey = resourceKey;
        }

        public string ResourceKey { get; set; }

        public override string DisplayName
        {
            get
            {
                var langId = EngineContext.Current.Resolve<IWorkContext>().WorkingLanguage.Id;
                _resourceValue = EngineContext.Current.Resolve<ILocalizationService>()
                    .GetResource(ResourceKey, langId, true, ResourceKey);

                return _resourceValue;
            }
        }

        public string Name
        {
            get { return "ACResourceDisplayName"; }
        }
    }
}
