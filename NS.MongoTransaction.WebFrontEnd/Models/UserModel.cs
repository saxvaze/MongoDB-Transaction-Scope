using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NS.MongoTransaction.Common.Entities;

namespace NS.MongoTransaction.WebFrontEnd.Models
{
    public class UserModel
    {
        public User User { get; set; }

        public Wallet UserWallet { get; set; }
    }
}