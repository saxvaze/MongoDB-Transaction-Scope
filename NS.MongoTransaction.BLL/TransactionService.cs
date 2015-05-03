using NS.MongoTransaction.Common.Entities;
using NS.MongoTransaction.Common.Enum;
using NS.MongoTransaction.Common.Exceptions;
using NS.MongoTransaction.Common.Helpers;
using NS.MongoTransaction.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.MongoTransaction.BLL
{
    public class TransactionService
    {
        WalletProvider _walletProvider;
        TransactionProvider _transactionProvider;

        public TransactionService()
        {
            _walletProvider = new WalletProvider();
            _transactionProvider = new TransactionProvider();
        }

        public void ProcessTransaction(Transaction transaction)
        {
            string transactionId = InitiateTransaction(transaction);

            UpdateTransactionStatus(transaction.Id, TransactionStatus.Pending);

            // Withdraw amount from source user
            try
            {
                _walletProvider.Withdraw(transaction.SourceUserId, transaction.Amount);
            }
            catch
            {
                UpdateTransactionStatus(transaction.Id, TransactionStatus.Canceled);

                throw new CannotCompleteOperationException("Cannot withdraw from source user");
            }

            // Deposit amount to destination user
            try
            {
                _walletProvider.Deposit(transaction.DestinationUserId, transaction.Amount);
            }
            catch
            {
                _walletProvider.Deposit(transaction.SourceUserId, transaction.Amount);
                UpdateTransactionStatus(transaction.Id, TransactionStatus.Canceled);

                throw new CannotCompleteOperationException("Cannot deposit to destination user");
            }

            // Finish transaction successfully
            UpdateTransactionStatus(transaction.Id, TransactionStatus.Success);

        }

        private string InitiateTransaction(Transaction transaction)
        {
            transaction.TransactionDate = DateTime.Now;
            transaction.TransactionStatus = TransactionStatus.Initiate;
            transaction.Id = Utils.GenerateTransactionId(transaction.TransactionDate, transaction.SourceUserId, transaction.DestinationUserId);

            _transactionProvider.InitiateTransaction(transaction);

            return transaction.Id;
        }

        private void UpdateTransactionStatus(string transactionId, TransactionStatus transactionStatus)
        {
            _transactionProvider.UpdateTransactionStatus(transactionId, transactionStatus);
        }
    }
}
