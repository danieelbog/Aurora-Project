using AuroraProject.Core.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using AuroraProject.Core.ViewModels;
using AuroraProject.Persistence;
using AuroraProject.Core;

namespace AuroraProject.Controllers
{
    [Authorize]
    public class WalletController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        public WalletController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        //GET WALLET
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            var wallet = unitOfWork.WalletRepository.GetWallet(userId);

            if (wallet == null)
                return HttpNotFound("You dont have a wallet?");

            var viewModel = new WalletViewModel(wallet.Value, wallet.Owner.UserFullName, "My Wallet", wallet.Owner.UserNotifications);

            return View("MyWallet", viewModel);
        }

        //POST: UPDATE WALLET
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(WalletViewModel viewModel, string submitButton)
        {
            var userId = User.Identity.GetUserId();
            var walletDb = unitOfWork.WalletRepository.GetWalletForUpdate(userId);

            if (walletDb == null || viewModel.Transaction < 0)
                return HttpNotFound("You dont have a wallet?");
            //BASED ON WHAT SUBMIT WAS THERE WILL BE AN ADD OR A WITHDRAW MONEY
            switch (submitButton)
            {
                case "AddMoney":
                    walletDb.AddMoney(viewModel.Transaction, walletDb.ID);

                    var depostiNotification = Notification.MoneyDeposited(viewModel.Transaction);
                    walletDb.Owner.Notify(depostiNotification);
                    unitOfWork.Complete();

                    break;
                case "WithdrawMoney":
                    walletDb.WithdrawMoney(viewModel.Transaction, walletDb.ID);

                    var withdrawNotification = Notification.MoneyWithdroawed(viewModel.Transaction);
                    walletDb.Owner.Notify(withdrawNotification);
                    unitOfWork.Complete();

                    break;
                default:
                    return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}