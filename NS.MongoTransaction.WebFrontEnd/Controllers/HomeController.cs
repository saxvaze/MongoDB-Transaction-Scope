using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using NS.MongoTransaction.BLL;
using NS.MongoTransaction.Common.Entities;
using NS.MongoTransaction.WebFrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NS.MongoTransaction.WebFrontEnd.Controllers
{
    public class HomeController : BaseController
    {
        UserService _userService;
        WalletService _walletService;

        public HomeController()
        {
            _userService = new UserService();
            _walletService = new WalletService();
        }

        public ActionResult Index()
        {
            var model = _userService.GetUsers();

            return View(model);
        }

        public ActionResult TransaferBalances()
        {
            return View();
        }
    }
}
