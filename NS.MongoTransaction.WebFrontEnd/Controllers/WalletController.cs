using NS.MongoTransaction.BLL;
using NS.MongoTransaction.Common.Entities;
using NS.MongoTransaction.Common.Exceptions;
using NS.MongoTransaction.WebFrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NS.MongoTransaction.WebFrontEnd.Controllers
{
    public class WalletController : Controller
    {
        UserService _userService;
        WalletService _walletService;
        TransactionService _transactionService;

        public WalletController()
        {
            _userService = new UserService();
            _walletService = new WalletService();
            _transactionService = new TransactionService();
        }

        public ActionResult TransferBalances()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TransferBalances(TransferBalancesModel model)
        {
            if (ModelState.IsValid)
            {
                var sourceUser = _userService.GetUserByPersonalNumber(model.SourceUserPersonalNumber);
                var destinationUser = _userService.GetUserByPersonalNumber(model.DestinationUserPersonalNumber);

                if (sourceUser == null || destinationUser == null)
                {
                    ViewBag.Success = false;
                    ViewBag.Message = "User not found!";

                    return View();
                }

                var sourceUserWallet = _walletService.GetUserWalletByUserId(sourceUser.UserId);

                if (model.Amount > sourceUserWallet.Balance)
                {
                    ViewBag.Success = false;
                    ViewBag.Message = "User doesn't have enought money!";
                    ModelState.AddModelError("Amount", "");

                    return View();
                }

                Transaction transaction = new Transaction
                {
                    Amount = model.Amount,
                    SourceUserId = sourceUser.UserId,
                    DestinationUserId = destinationUser.UserId,
                };

                try
                {
                    _transactionService.ProcessTransaction(transaction);

                    ViewBag.Success = true;
                    ViewBag.Message = "Transfer finished successfully";
                }
                catch (CannotCompleteOperationException ex)
                {
                    ViewBag.Success = false;
                    ViewBag.Message = ex.Message;
                }
                catch (Exception)
                {
                    ViewBag.Success = false;
                    ViewBag.Message = "General Error";
                }
            }
            else
            {
                ViewBag.Success = false;
                ViewBag.Message = "All fields are required!";

                return View();
            }

            return View();
        }
    }
}
