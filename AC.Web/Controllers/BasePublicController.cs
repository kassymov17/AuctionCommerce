using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AC.Core.Infrastructure;
using AC.Web.Framework.Controllers;

namespace AC.Web.Controllers
{
    public abstract partial class BasePublicController : BaseController
    {
        protected virtual ActionResult InvokeHttp404()
        {
            // вызов целевого контроллера
            IController errorController = EngineContext.Current.Resolve<CommonController>();

            var routeData = new RouteData();
            routeData.Values.Add("controller", "Common");
            routeData.Values.Add("action", "PageNotFound");

            errorController.Execute(new RequestContext(this.HttpContext, routeData));

            return new EmptyResult();
        }

        protected void SaveSelectedTabName(string tabName = "", bool persistForTheNextRequest = true)
        {
            if (string.IsNullOrEmpty(tabName))
            {
                tabName = this.Request.Form["selected-tab-name"];
            }

            if (!string.IsNullOrEmpty(tabName))
            {
                const string dataKey = "ac.selected-tab-name";
                if (persistForTheNextRequest)
                {
                    TempData[dataKey] = tabName;
                }
                else
                {
                    ViewData[dataKey] = tabName;
                }
            }
        }
    }
}