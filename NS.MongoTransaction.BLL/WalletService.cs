using NS.MongoTransaction.Common.Entities;
using NS.MongoTransaction.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.MongoTransaction.BLL
{
    public class WalletService
    {
        WalletProvider _walletProvider;

        public WalletService()
        {
            _walletProvider = new WalletProvider();
        }

        public Wallet GetUserWalletByUserId(int userId)
        {
            return _walletProvider.GetUserWalletById(userId);
        }

        public void InsertWallet(Wallet wallet)
        {
            _walletProvider.InsertWallet(wallet);
        }

        public void Withdraw(int userId, double amount)
        {
            _walletProvider.Withdraw(userId, amount);
        }
    }
}
