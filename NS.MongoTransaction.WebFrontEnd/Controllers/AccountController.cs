using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using NS.MongoTransaction.BLL;
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
        UserService _userService;

        public AccountController()
        {
            _userService = new UserService();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _userService.RegisterUser(model);

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
