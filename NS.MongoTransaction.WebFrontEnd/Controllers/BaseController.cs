using MongoDB.Driver;
using NS.MongoTransaction.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NS.MongoTransaction.WebFrontEnd.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// returns db context according to param dbName
        /// </summary>
        /// <param name="dbName">dbName identifies which database to return</param>
        public MongoDatabase Database(string dbName)
        {
            MongoDatabase mongoDBContext;
            
            string MongoDBConnectionString = "mongodb://localhost";
            var client = new MongoClient(MongoDBConnectionString);
            var server = client.GetServer();

            mongoDBContext = server.GetDatabase(dbName);

            return mongoDBContext;
        }

        /// <summary>
        /// returns MongoDB Collection User of database test
        /// </summary>
        /// <remarks>
        /// carries data about collection User
        /// </remarks>
        public MongoCollection<User> CollectionUser
        {
            get { return Database("test").GetCollection<User>("User"); }
        }
    }
}
