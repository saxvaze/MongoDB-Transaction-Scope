using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.MongoTransaction.Common.Entities
{
    public class User
    {
        [BsonId]
        public int UserId { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string Username { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string Password { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string FirstName { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string LastName { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public string BirthDate { get; set; }
    }
}
