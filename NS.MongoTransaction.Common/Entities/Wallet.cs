using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.MongoTransaction.Common.Entities
{
    [BsonIgnoreExtraElements]
    public class Wallet
    {
        [BsonId]
        public int WalletId { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("userId")]
        [BsonRepresentation(BsonType.Int32)]
        public int UserId { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("balance")]
        [BsonRepresentation(BsonType.Double)]
        public double Balance { get; set; }
    }
}
