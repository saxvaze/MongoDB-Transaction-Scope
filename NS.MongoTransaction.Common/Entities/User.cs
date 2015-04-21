using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NS.MongoTransaction.Common.Entities
{
    [BsonIgnoreExtraElements]
    public class User
    {
        [BsonId]
        public int UserId { get; set; }

        [BsonElement("username")]
        [BsonRepresentation(BsonType.String)]
        [Required(ErrorMessage = "Field is required", AllowEmptyStrings = false)]
        public string Username { get; set; }

        [BsonElement("password")]
        [BsonRepresentation(BsonType.String)]
        [Required(ErrorMessage = "Field is required", AllowEmptyStrings = false)]
        public string Password { get; set; }

        [BsonElement("firstname")]
        [BsonRepresentation(BsonType.String)]
        [Required(ErrorMessage = "Field is required", AllowEmptyStrings = false)]
        public string FirstName { get; set; }

        [BsonElement("lastname")]
        [BsonRepresentation(BsonType.String)]
        [Required(ErrorMessage = "Field is required", AllowEmptyStrings = false)]
        public string LastName { get; set; }

        [BsonElement("personalNumber")]
        [BsonRepresentation(BsonType.String)]
        [Required(ErrorMessage = "Field is required", AllowEmptyStrings = false)]
        public string PersonalNumber { get; set; }

        [BsonElement("birthDate")]
        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local, DateOnly = true)]
        [Required(ErrorMessage = "Field is required", AllowEmptyStrings = false)]
        public DateTime BirthDate { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("info")]
        public UserInfo UserInfo { get; set; }

        [BsonIgnoreIfNull]
        public Wallet UserWallet { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class UserInfo
    {
        [BsonIgnoreIfNull]
        [BsonElement("mobile")]
        [BsonRepresentation(BsonType.String)]
        [Required(ErrorMessage = "Field is required", AllowEmptyStrings = false)]
        public string Mobile { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("email")]
        [BsonRepresentation(BsonType.String)]
        [Required(ErrorMessage = "Field is required", AllowEmptyStrings = false)]
        public string EMail { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("address")]
        [BsonRepresentation(BsonType.String)]
        [Required(ErrorMessage = "Field is required", AllowEmptyStrings = false)]
        public string Address { get; set; }
    }
}
