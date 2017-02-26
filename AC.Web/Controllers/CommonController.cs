using AC.Data.Abstract;
using AC.Data.Entities.Common;
using AC.Web.Framework.UI;
using AC.Web.Models.Common;
using System.Web.Mvc;

namespace AC.Web.Controllers
{
    public partial class CommonController : BasePublicController
    {
        #region Fields
        private readonly IPageHeadBuilder _pageHeadBuilder;
        private readonly IRepository<Student> _studentRepo; 
        #endregion

        public CommonController(IPageHeadBuilder pageHeadBuilder, IRepository<Student> studentRepo)
        {
            _pageHeadBuilder = pageHeadBuilder;
            _studentRepo = studentRepo;
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

        [ChildActionOnly]
        public ActionResult Footer()
        {

            return PartialView();
        }
    }
}