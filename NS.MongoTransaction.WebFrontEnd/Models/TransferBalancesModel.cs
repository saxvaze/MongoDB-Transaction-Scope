using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NS.MongoTransaction.WebFrontEnd.Models
{
    public class TransferBalancesModel
    {
        public string FromUserPersonalNumber { get; set; }

        public string ToUserPersonalNumber { get; set; }

        public double Amount { get; set; }
    }
}