using AuroraProject.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using AuroraProject.ViewModels;

namespace AuroraProject.Controllers
{
    [Authorize]
    public class WalletController : Controller
    {
        private ApplicationDbContext context;
        public WalletController()
        {
            context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }

        //GET WALLET
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var wallet = context.Wallets
                .Include(w => w.Owner)
                .Single(w => w.Owner.Id == userId);

            if (wallet == null)
                return HttpNotFound("You dont have a wallet?");

            var viewModel = new WalletViewModel(wallet.Value, wallet.Owner.UserFullName, "My Wallet");

            return View("MyWallet", viewModel);
        }

        //POST: UPDATE WALLET
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(WalletViewModel viewModel, string submitButton)
        {
            var userId = User.Identity.GetUserId();
            var walletDb = context.Wallets.Single(w => w.Owner.Id == userId);

            if (walletDb == null || viewModel.Transaction < 0)
                return HttpNotFound("You dont have a wallet?");

            switch (submitButton)
            {
                case "AddMoney":
                    walletDb.AddMoney(viewModel.Transaction, walletDb.ID);
                    context.SaveChanges();
                    break;
                case "WithdrawMoney":
                    walletDb.WithdrawMoney(viewModel.Transaction, walletDb.ID);
                    context.SaveChanges();
                    break;
                default:
                    return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}