using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NS.MongoTransaction.Common.Enum;

namespace NS.MongoTransaction.Common.Entities
{
    public class Transaction
    {
        [BsonId]
        public string Id { get; set; }

        [BsonElement("sourceUserId")]
        [BsonRepresentation(BsonType.Int32)]
        public int SourceUserId { get; set; }

        [BsonElement("destinationUserId")]
        [BsonRepresentation(BsonType.Int32)]
        public int DestinationUserId { get; set; }

        [BsonElement("amount")]
        [BsonRepresentation(BsonType.Double)]
        public double Amount { get; set; }

        [BsonElement("transactionDate")]
        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime TransactionDate { get; set; }

        [BsonElement("transactionStatus")]
        [BsonRepresentation(BsonType.Int32)]
        public TransactionStatus TransactionStatus { get; set; }
    }
}
