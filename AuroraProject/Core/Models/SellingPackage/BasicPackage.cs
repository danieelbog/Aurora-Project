using AuroraProject.Core.Repositories;
using AuroraProject.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuroraProject.Core.Models
{
    public class BasicPackage : ISellingPackage
    {
        public int ID { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public string PackageName { get; set; }

        [Required]
        [StringLength(255)]
        public string PackageDescreption { get; set; }

        [Required]
        public int DeliveryTime { get; set; }

        protected BasicPackage()
        {

        }

        public BasicPackage(GigFormViewModel viewModel)
        {
            Price = viewModel.BasicPrice;
            PackageName = viewModel.BasicPackageName;
            PackageDescreption = viewModel.BasicPackageDescreption;
            DeliveryTime = viewModel.BasicDeliveryTime;
        }

        public void Modify(GigFormViewModel updatedViewModel)
        {
            //CODE FOR ADVANCED PACKAGE
            Price = updatedViewModel.BasicPrice;
            PackageName = updatedViewModel.BasicPackageName;
            PackageDescreption = updatedViewModel.BasicPackageDescreption;
            DeliveryTime = updatedViewModel.BasicDeliveryTime;
        }

        public void SellPackage(ApplicationUser buyerUser, ApplicationUser sellerUser, AuroraWallet toAuroraWallet)
        {
            var auroraMortage = Price * 0.05f;
            var clearPrice = Price - auroraMortage;

            buyerUser.TransferMoneyToAurora(buyerUser.Wallet, toAuroraWallet, auroraMortage);
            buyerUser.TransferMoneyToUser(buyerUser.Wallet, sellerUser.Wallet, clearPrice);

            var purchaseNotification = Notification.GigPurchased(this, sellerUser.UserFullName);
            var soldNotification = Notification.GigSold(this, buyerUser.UserFullName);

            buyerUser.Notify(purchaseNotification);
            sellerUser.Notify(soldNotification);
        }
    }
}