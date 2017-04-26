using AC.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;

namespace AC.Web.Framework.UI
{
    public partial class PageHeadBuilder : IPageHeadBuilder
    {
        #region Fields

        private static readonly object s_lock = new object();

        private readonly Dictionary<ResourceLocation, List<ScriptReferenceMeta>> _scriptParts;
        private readonly Dictionary<ResourceLocation, List<CssReferenceMeta>> _cssParts;

        #endregion
            
        
        #region Ctor
        
        public PageHeadBuilder()
        {
            this._scriptParts = new Dictionary<ResourceLocation, List<ScriptReferenceMeta>>();
            this._cssParts = new Dictionary<ResourceLocation, List<CssReferenceMeta>>();
        }

        #endregion

        #region Utilities

        protected virtual string GetBundleVirtualPath(string prefix, string extension, string[] parts)
        {
            if(parts == null || parts.Length == 0)
            {
                throw new ArgumentException("parts");
            }

            // calculate hash
            var hash = "";
            using(SHA256 sha = new SHA256Managed())
            {
                // string concatenation
                var hashInput = "";
                foreach(var part in parts)
                {
                    hashInput += part;
                    hashInput += ",";
                }

                byte[] input = sha.ComputeHash(Encoding.Unicode.GetBytes(hashInput));
                hash = HttpServerUtility.UrlTokenEncode(input);
            }

            var sb = new StringBuilder(prefix);
            sb.Append(hash);

            return sb.ToString();
        }

        protected virtual IItemTransform GetCssTransform()
        {
            return new CssRewriteUrlTransform();
        }

        #endregion

        #region Methods

        public virtual void AddScriptParts(ResourceLocation location, string part, bool excludeFromBundle, bool isAsync)
        {
            if (!_scriptParts.ContainsKey(location))
                _scriptParts.Add(location, new List<ScriptReferenceMeta>());

            if (string.IsNullOrEmpty(part))
                return;

            _scriptParts[location].Add(new ScriptReferenceMeta
            {
                ExcludeFromBundle = excludeFromBundle,
                IsAsync = isAsync,
                Part = part
            });
        }

        public virtual void AppendScriptParts(ResourceLocation location, string part, bool excludeFromBundle, bool isAsync)
        {
            if (!_scriptParts.ContainsKey(location))
                _scriptParts.Add(location, new List<ScriptReferenceMeta>());

            if (string.IsNullOrEmpty(part))
                return;

            _scriptParts[location].Insert(0, new ScriptReferenceMeta
            {
                ExcludeFromBundle = excludeFromBundle,
                IsAsync = isAsync,
                Part = part
            });
        }

        public virtual string GenerateScripts(UrlHelper urlHerlper, ResourceLocation location, bool? bundleFiles = null)
        {
            if (!_scriptParts.ContainsKey(location) || _scriptParts[location] == null)
                return "";

            if (!_scriptParts.Any())
                return "";

            if (!bundleFiles.HasValue)
            {
                bundleFiles = BundleTable.EnableOptimizations;
            }
            if (bundleFiles.Value)
            {
                var partsToBundle = _scriptParts[location]
                    .Where(x => !x.ExcludeFromBundle)
                    .Select(x => x.Part)
                    .Distinct()
                    .ToArray();
                var partsToDontBundle = _scriptParts[location]
                    .Where(x => x.ExcludeFromBundle)
                    .Select(x => new { x.Part, x.IsAsync })
                    .Distinct()
                    .ToArray();

                var result = new StringBuilder();

                if(partsToBundle.Length > 0)
                {
                    string bundleVirtualPath = GetBundleVirtualPath("~/bundles/scripts",".js", partsToBundle);

                    // create bundle
                    lock (s_lock)
                    {
                        var bundleFor = BundleTable.Bundles.GetBundleFor(bundleVirtualPath);
                        if(bundleFor == null)
                        {
                            var bundle = new ScriptBundle(bundleVirtualPath);

                            bundle.Orderer = new AsIsBundleOrderer();

                            bundle.EnableFileExtensionReplacements = false;
                            bundle.Include(partsToBundle);
                            BundleTable.Bundles.Add(bundle);
                        }
                    }
                    // parts to bundle
                    result.AppendLine(Scripts.Render(bundleVirtualPath).ToString());
                }
                // parts to bundle
                foreach(var item in partsToDontBundle)
                {
                    result.AppendFormat("<script {2}src=\"{0}\" type=\"{1}\"></script>", urlHerlper.Content(item.Part),MimeTypes.TextJavascript, item.IsAsync ? "async" : "");
                }
                return result.ToString();
            }
            else
            {
                // bundling is disabled
                var result = new StringBuilder();
                foreach(var item in _scriptParts[location].Select(x=>new { x.Part, x.IsAsync }).Distinct())
                {
                    result.AppendFormat("<script {2}src=\"{0}\" type=\"{1}\"></script>", urlHerlper.Content(item.Part), MimeTypes.TextJavascript, item.IsAsync ? "async": "");
                    result.Append(Environment.NewLine);
                }
                return result.ToString();
            }
        }

        public virtual void AddCssFileParts(ResourceLocation location, string part, bool excludeFromBundle = false)
        {
            if (!_cssParts.ContainsKey(location))
                _cssParts.Add(location, new List<CssReferenceMeta>());

            if (string.IsNullOrEmpty(part))
                return;

            _cssParts[location].Add(new CssReferenceMeta
            {
                ExcludeFromBundle = excludeFromBundle,
                Part = part
            });
        }

        public virtual void AppendCssFileParts(ResourceLocation location, string part, bool excludeFromBundle = false)
        {
            if (!_cssParts.ContainsKey(location))
                _cssParts.Add(location, new List<CssReferenceMeta>());
            if (string.IsNullOrEmpty(part))
                return;
            _cssParts[location].Insert(0, new CssReferenceMeta
            {
                ExcludeFromBundle = excludeFromBundle,
                Part = part
            });
        }

        public virtual string GenerateCssFiles(UrlHelper urlHelper, ResourceLocation location, bool? bundleFiles = null)
        {
            if (!_cssParts.ContainsKey(location) || _cssParts[location] == null)
                return "";

            if (!_cssParts.Any())
                return "";

            if (!bundleFiles.HasValue)
            {
                //use setting if no value is specified
                bundleFiles = BundleTable.EnableOptimizations;
            }

            if (bundleFiles.Value)
            {
                var partsToBundle = _cssParts[location]
                    .Where(x => !x.ExcludeFromBundle)
                    .Select(x => x.Part)
                    .Distinct()
                    .ToArray();

                var partsToDontBundle = _cssParts[location]
                    .Where(x => x.ExcludeFromBundle)
                    .Select(x => x.Part)
                    .Distinct()
                    .ToArray();

                var result = new StringBuilder();

                if(partsToBundle.Length > 0)
                {
                    // do not use css bundling in virtual categories
                    string bundleVirtualPath = GetBundleVirtualPath("~/bundles/styles/", ".css", partsToBundle);

                    //create bundle
                    lock (s_lock)
                    {
                        var bundleFor = BundleTable.Bundles.GetBundleFor(bundleVirtualPath);
                        if(bundleFor == null)
                        {
                            var bundle = new StyleBundle(bundleVirtualPath);

                            bundle.Orderer = new AsIsBundleOrderer();

                            bundle.EnableFileExtensionReplacements = false;
                            foreach(var ptb in partsToBundle)
                            {
                                bundle.Include(ptb, GetCssTransform());
                            }
                            BundleTable.Bundles.Add(bundle);
                        }
                    }

                    //parts to bundle
                    result.AppendLine(Styles.Render(bundleVirtualPath).ToString());
                }

                //parts to bundle
                foreach(var item in partsToDontBundle)
                {
                    result.AppendFormat("<link href=\"{0}\" rel=\"stylesheet\" type=\"{1}\" />", urlHelper.Content(item), MimeTypes.TextCss);
                    result.Append(Environment.NewLine);
                }

                return result.ToString();
            }
            else
            {
                //bundling is disabled
                var result = new StringBuilder();
                foreach (var path in _cssParts[location].Select(x=>x.Part).Distinct())
                {
                    result.AppendFormat("<link href=\"{0}\" rel=\"stylesheet\" type=\"{1}\" />", urlHelper.Content(path), MimeTypes.TextCss);
                    result.AppendLine();
                }
                return result.ToString();
            }
        }

        #endregion

        #region Nested classes

        public class ScriptReferenceMeta {

            public bool ExcludeFromBundle { get; set; }

            public bool IsAsync { get; set; }

            public string Part { get; set; }

        }

        private class CssReferenceMeta
        {
            public bool ExcludeFromBundle { get; set; }

            public string Part { get; set; }
        }

        #endregion

    }
}
