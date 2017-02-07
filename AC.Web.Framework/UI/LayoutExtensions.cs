using System.Web.Mvc;
using AC.Core.Infrastructure;

namespace AC.Web.Framework.UI
{
    /// <summary>
    ///  Расширения для разметки
    /// </summary>
    public static class LayoutExtensions
    {
        /// <summary>
        /// Append script element
        /// </summary>
        /// <param name="html">HTML helper</param>
        /// <param name="part">Script part</param>
        /// <param name="excludeFromBundle">A value indicating whether to exclude this script from bundling</param>
        /// <param name="isAsync">A value indicating whether to add an attribute "async" or not for js files</param>
        public static void AppendScriptParts(this HtmlHelper html, string part, bool excludeFromBundle = false, bool isAsync = false)
        {
            AppendScriptParts(html, ResourceLocation.Head, part, excludeFromBundle, isAsync);
        }
        /// <summary>
        /// Append script element
        /// </summary>
        /// <param name="html">HTML helper</param>
        /// <param name="location">A location of the script element</param>
        /// <param name="part">Script part</param>
        /// <param name="excludeFromBundle">A value indicating whether to exclude this script from bundling</param>
        /// <param name="isAsync">A value indicating whether to add an attribute "async" or not for js files</param>
        public static void AppendScriptParts(this HtmlHelper html, ResourceLocation location, string part, bool excludeFromBundle = false, bool isAsync = false)
        {
            var pageHeadBuilder = EngineContext.Current.Resolve<IPageHeadBuilder>();
            pageHeadBuilder.AppendScriptParts(location, part, excludeFromBundle, isAsync);
        }
    }
}
