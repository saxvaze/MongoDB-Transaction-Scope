using MongoDB.Bson;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NS.MongoTransaction.WebFrontEnd.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            //var a = base.CollectionUser.FindOne(Query.EQ("_id", new BsonInt32(1)));

            return View();
        }
    }
}
