using MongoDB.Bson;
using MongoDB.Driver.Builders;
using NS.MongoTransaction.Common.Entities;
using NS.MongoTransaction.Common.Enum;
using NS.MongoTransaction.DAL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.MongoTransaction.DAL
{
    public class TransactionProvider : BaseProvider
    {
        public void InitiateTransaction(Transaction transaction)
        {
            GetTransactionCollection.Save(transaction);
        }

        public Transaction GetTransaction(string transactionId)
        {
            return GetTransactionCollection.FindOne(Query.EQ("_id", new BsonString(transactionId)));
        }

        public void UpdateTransactionStatus(string transactionId, TransactionStatus transactionStatus)
        {
            GetTransactionCollection.Update(Query.EQ("_id", transactionId), new UpdateBuilder().Set("transactionStatus", transactionStatus));
        }
    }
}
