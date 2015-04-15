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

        [BsonElement("username")]
        [BsonRepresentation(BsonType.String)]
        public string Username { get; set; }

        [BsonElement("password")]
        [BsonRepresentation(BsonType.String)]
        public string Password { get; set; }

        [BsonElement("firstname")]
        [BsonRepresentation(BsonType.String)]
        public string FirstName { get; set; }

        [BsonElement("lastname")]
        [BsonRepresentation(BsonType.String)]
        public string LastName { get; set; }

        [BsonElement("personalNumber")]
        [BsonRepresentation(BsonType.String)]
        public string PersonalNumber { get; set; }

        [BsonElement("birthDate")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime BirthDate { get; set; }

        [BsonRepresentation(BsonType.String)]
        [BsonElement("info")]
        public UserInfo UserInfo { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class UserInfo
    {
        [BsonIgnoreIfNull]
        [BsonElement("mobile")]
        [BsonRepresentation(BsonType.String)]
        public string Mobile { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("email")]
        [BsonRepresentation(BsonType.String)]
        public string EMail { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("address")]
        [BsonRepresentation(BsonType.String)]
        public string Address { get; set; }
    }
}
