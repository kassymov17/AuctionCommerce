﻿using System.Web.Mvc;

namespace AC.Web.Framework.UI
{
    public partial interface IPageHeadBuilder
    {
        void AddScriptParts(ResourceLocation location, string part, bool excludeFromBundle, bool isAsync);
        void AppendScriptParts(ResourceLocation location, string part, bool excludeFromBundle, bool isAsync);
        string GenerateScripts(UrlHelper urlHelper, ResourceLocation location, bool? bundleFiles = null);

        void AddCssFileParts(ResourceLocation location, string part, bool excludeFromBundle = false);
        void AppendCssFileParts(ResourceLocation location, string part, bool excludeFromBundle = false);
        string GenerateCssFiles(UrlHelper urlHelper, ResourceLocation location, bool? bundleFiles = null);
    }
}
