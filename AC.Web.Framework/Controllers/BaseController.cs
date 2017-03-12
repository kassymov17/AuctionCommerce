using AC.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AC.Web.Framework.Controllers
{
    public class BaseController : Controller
    {
        //public IUnitOfWork UnitOfWork { get; set; }
        
        //protected override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    if (!filterContext.IsChildAction)
        //        UnitOfWork.BeginTransaction();
        //}

        //protected override void OnActionExecuted(ActionExecutedContext filterContext)
        //{
        //    if (!filterContext.IsChildAction)
        //        UnitOfWork.Commit();
        //}
    }
}
