using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NS.MongoTransaction.WebFrontEnd.Models
{
    public class TransferBalancesModel
    {
        [Required(ErrorMessage = "Field is required", AllowEmptyStrings = false)]
        public string SourceUserPersonalNumber { get; set; }

        [Required(ErrorMessage = "Field is required", AllowEmptyStrings = false)]
        public string DestinationUserPersonalNumber { get; set; }

        [Required(ErrorMessage = "Field is required")]
        public double Amount { get; set; }
    }
}