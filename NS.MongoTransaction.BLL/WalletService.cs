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

        public Wallet GetUserWalletById(int userId)
        {
            return _walletProvider.GetUserWalletById(userId);
        }

        public void IsertWallet(Wallet wallet)
        {
            _walletProvider.InsertWallet(wallet);
        }
    }
}
