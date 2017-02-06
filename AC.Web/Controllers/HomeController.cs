using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AC.Web.Controllers
{
    public partial class HomeController : BasePublicController
    {
        public ActionResult Index()
        {
            return View();
        }
        
    }
}