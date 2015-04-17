using MongoDB.Bson;
using NS.MongoTransaction.Common.Entities;
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

        [HttpPost]
        public ActionResult Register(User model)
        {
            model.UserId = 1; // TODO: Hard coded

            try
            {
                if (ModelState.IsValid)
                {
                    GetUserCollection.Save(model);

                    ViewBag.Success = true;
                }
                else
                {
                    ViewBag.Success = false;
                    ViewBag.Message = "All fileds are required";
                }
            }
            catch
            {
                ViewBag.Success = false;
            }

            return View();
        }
    }
}
