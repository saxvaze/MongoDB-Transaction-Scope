using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NS.MongoTransaction.WebFrontEnd.Controllers
{
    public class AccountController : BaseController
    {
        public ActionResult Register()
        {
            return View(); 
        }
    }
}
