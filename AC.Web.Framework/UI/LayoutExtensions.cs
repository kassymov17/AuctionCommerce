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

        /// <summary>
        /// Generate all css parts
        /// </summary>
        /// <param name="html">Html helper</param>
        /// <param name="urlHelper">url helper</param>
        /// <param name="location">location of script element</param>
        /// <param name="bundleFiles">A value indicating whether to bundle script elements</param>
        /// <returns>Generated string</returns>
        public static MvcHtmlString ACCssFiles(this HtmlHelper html, UrlHelper urlHelper, ResourceLocation location, bool? bundleFiles = null)
        {
            var pageHeadBuilder = EngineContext.Current.Resolve<IPageHeadBuilder>();
            return MvcHtmlString.Create(pageHeadBuilder.GenerateCssFiles(urlHelper, location, bundleFiles));
        }

        ///<summary>
        /// generate all script parts
        /// </summary>
        /// <param name="html">HTML helper</param>
        /// <param name="urlHelper">URL helper</param>
        /// <param name="location">A location of script element</param>
        /// <param name="bundleFiles">A value indicating whether to bundle script elements</param>
        /// <returns>Generated scripts</returns>
        public static MvcHtmlString ACScripts(this HtmlHelper html, UrlHelper urlHelper, ResourceLocation location, bool? bundleFiles = null)
        {
            var pageHeadBuilder = EngineContext.Current.Resolve<IPageHeadBuilder>();
            return MvcHtmlString.Create(pageHeadBuilder.GenerateScripts(urlHelper, location, bundleFiles));
        }
    }
}
