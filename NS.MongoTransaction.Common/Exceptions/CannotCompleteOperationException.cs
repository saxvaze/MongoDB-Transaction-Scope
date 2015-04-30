using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.MongoTransaction.Common.Exceptions
{
    public class CannotCompleteOperationException : Exception
    {
        public CannotCompleteOperationException() : base() { }

        public CannotCompleteOperationException(string message) : base(message) { }
    }
}
