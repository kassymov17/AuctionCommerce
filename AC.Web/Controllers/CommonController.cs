using AC.Web.Framework.UI;
using AC.Web.Models.Common;
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
        
        #endregion

        
        [ChildActionOnly]
        public ActionResult Footer()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult HeaderLinks()
        {
            var model = new HeaderLinksModel
            {
                // зарегистрирован ли пользователь
                IsAuthenticated = false,
                CustomerEmailUsername = "CustomerEmailUsername",
                ShoppingCartEnabled = true,
                WishlistEnabled = true,
                AllowPrivateMessages = true,
                UnreadPrivateMessages = "",
                AlertMessage = string.Empty
            };

            return PartialView(model);
        }
    }
}