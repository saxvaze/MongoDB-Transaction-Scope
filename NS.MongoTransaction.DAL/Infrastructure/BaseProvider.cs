using MongoDB.Driver;
using NS.MongoTransaction.Common.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.MongoTransaction.DAL.Infrastructure
{
    public class BaseProvider
    {
        /// <summary>
        /// returns db context according to param dbName
        /// </summary>
        /// <param name="dbName">dbName identifies which database to return</param>
        private MongoDatabase Database(string dbName)
        {
            MongoDatabase mongoDBContext;

            string MongoDBConnectionString = ConfigurationManager.ConnectionStrings["MongoDBConnectionString"].ConnectionString;
            var client = new MongoClient(MongoDBConnectionString);
            var server = client.GetServer();

            mongoDBContext = server.GetDatabase(dbName);

            return mongoDBContext;
        }

        /// <summary>
        /// returns MongoDB Collection User of database foo
        /// </summary>
        /// <remarks>
        /// carries data about collection User
        /// </remarks>
        protected MongoCollection<User> GetUserCollection
        {
            get { return Database("foo").GetCollection<User>("user"); }
        }

        /// <summary>
        /// returns MongoDB Collection avaulableUserIds of database foo
        /// </summary>
        /// <remarks>
        /// carries data about collection avaulableUserIds
        /// </remarks>
        protected MongoCollection<AvailableUserId> GetAvailableUserIds
        {
            get { return Database("foo").GetCollection<AvailableUserId>("availableUserIds"); }
        }

        /// <summary>
        /// returns User Wallet
        /// </summary>
        /// <remarks>
        /// carries data about collection wallet
        /// </remarks>
        protected MongoCollection<Wallet> GetUserWallet
        {
            get { return Database("foo").GetCollection<Wallet>("wallet"); }
        }
    }
}
