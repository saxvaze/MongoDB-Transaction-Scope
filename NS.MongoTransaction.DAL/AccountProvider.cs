using MongoDB.Driver;
using MongoDB.Driver.Builders;
using NS.MongoTransaction.DAL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.MongoTransaction.DAL
{
    public class AccountProvider : BaseProvider
    {
        public int GetAvailableUserId()
        {
            return GetAvailableUserIds.Find(new QueryDocument()).SetSortOrder(SortBy.Ascending("_id")).First().Id;
        }

        public void DeleteUserId(int userId)
        {
            GetAvailableUserIds.Remove(Query.EQ("_id", userId));
        }
    }
}
