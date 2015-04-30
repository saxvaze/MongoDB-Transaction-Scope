using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.MongoTransaction.Common.Helpers
{
    public static class Utils
    {
        public static string GenerateTransactionId(DateTime date, int sourceUserId, int destinationUserId)
        {
            return String.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}", date.Year.ToString("D2"), date.Month.ToString("D2"), date.Day.ToString("D2"), date.Hour.ToString("D2"),
                date.Minute.ToString("D2"), date.Second.ToString("D2"), date.Millisecond.ToString("D2"), sourceUserId.ToString("D3"), destinationUserId.ToString("D3"));
        }
    }
}
