using MongoDB.Bson;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Wrappers;
using NS.MongoTransaction.Common.Entities;
using NS.MongoTransaction.DAL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.MongoTransaction.DAL
{
    public class WalletProvider : BaseProvider
    {
        public Wallet GetUserWalletById(int userId)
        {
            var wallet = GetUserWallet.FindOne(Query.EQ("userId", userId));

            return wallet;
        }

        public void Deposit(int userId, double amount)
        {
            var setStatement = new BsonDocument
            {
                {
                    "$inc", new BsonDocument
                    {
                        { "balance", amount }
                    }
                }
            };

            var updateWrapper = UpdateWrapper.Create(setStatement);

            GetUserWallet.Update(Query.EQ("userId", userId), updateWrapper);
        }

        public void Withdraw(int userId, double amount)
        {
            var userWallet = GetUserWallet.FindOne(Query.EQ("userId", userId));

            var setStatement = new BsonDocument
            {
                {
                    "$inc", new BsonDocument
                    {
                        { "balance", -amount }
                    }
                }
            };

            var updateWrapper = UpdateWrapper.Create(setStatement);

            GetUserWallet.Update(Query.EQ("userId", userId), updateWrapper);
        }

        public void InsertWallet(Wallet wallet)
        {
            GetUserWallet.Save(wallet);
        }
    }
}
