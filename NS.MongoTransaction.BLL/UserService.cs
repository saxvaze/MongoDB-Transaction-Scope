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
        WalletProvider _walletProvider;

        public UserService()
        {
            _userProvider = new UserProvider();
            _accountProvider = new AccountProvider();
            _walletProvider = new WalletProvider();
        }

        public void RegisterUser(User user)
        {
            user.UserId = _accountProvider.GetAvailableUserId();

            _userProvider.RegisterUser(user);

            _walletProvider.InsertWallet(new Wallet 
            {
                WalletId = user.UserId,
                UserId = user.UserId,
                Balance = 0
            });

            _accountProvider.DeleteUserId(user.UserId);
        }

        public List<User> GetUsers()
        {
            var users = _userProvider.GetUsers();

            foreach (var user in users)
            {
                user.UserWallet = _walletProvider.GetUserWalletById(user.UserId);
            }
            
            return users;
        }
    }
}
