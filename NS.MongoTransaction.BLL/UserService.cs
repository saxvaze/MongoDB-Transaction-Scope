using NS.MongoTransaction.Common.Entities;
using NS.MongoTransaction.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.MongoTransaction.BLL
{
    public class UserService
    {
        UserProvider _userProvider;
        AccountProvider _accountProvider;

        public UserService()
        {
            _userProvider = new UserProvider();
            _accountProvider = new AccountProvider();
        }

        public void RegisterUser(User user)
        {
            user.UserId = _accountProvider.GetAvailableUserId();

            _userProvider.RegisterUser(user);

            _accountProvider.DeleteUserId(user.UserId);
        }

        public List<User> GetUsers()
        {
            return _userProvider.GetUsers();
        }
    }
}
