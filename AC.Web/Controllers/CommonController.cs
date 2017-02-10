using AC.Web.Framework.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AC.Web.Controllers
{
    public partial class CommonController : BasePublicController
    {
        #region Fields
        private readonly IPageHeadBuilder _pageHeadBuilder;


        #endregion

        public CommonController(IPageHeadBuilder pageHeadBuilder)
        {
            this._pageHeadBuilder = pageHeadBuilder;
        }

        [ChildActionOnly]
        public ActionResult Footer()
        {
            return PartialView();
        }
    }
}