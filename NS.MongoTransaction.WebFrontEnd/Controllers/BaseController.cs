using MongoDB.Driver;
using NS.MongoTransaction.Common.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NS.MongoTransaction.WebFrontEnd.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled)
                return;

            filterContext.ExceptionHandled = true;
            filterContext.Result = new RedirectResult("~/Error/Index");
        }
    }
}
