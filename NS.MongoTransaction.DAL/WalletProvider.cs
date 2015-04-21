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

        public bool Deposit(int userId, double amount)
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

            try
            {
                GetUserWallet.Update(Query.EQ("userId", userId), updateWrapper);

                return true;
            }
            catch 
            {
                return false;
            }
        }

        public bool Withdraw(int userId, double amount)
        {
            var userWallet = GetUserWallet.FindOne(Query.EQ("userId", userId));

            if (userWallet.Balance < amount)
                return false;

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

            try
            {
                GetUserWallet.Update(Query.EQ("userId", userId), updateWrapper);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public void InsertWallet(Wallet wallet)
        {
            GetUserWallet.Save(wallet);
        }
    }
}
