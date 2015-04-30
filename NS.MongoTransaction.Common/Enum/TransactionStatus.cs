using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.MongoTransaction.Common.Enum
{
    public enum TransactionStatus
    {
        Initiate = 1,
        Pending = 2,
        Success = 3,
        Canceled = 4
    }
}
