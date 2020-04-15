using AuroraProject.Core.Repositories;
using AuroraProject.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuroraProject.Core.Models
{
    public class AdvancedPackage : ISellingPackage
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

        protected AdvancedPackage()
        {

        }

        public AdvancedPackage(GigFormViewModel viewModel)
        {
            Price = viewModel.AdvancedPrice;
            PackageName = viewModel.AdvancedPackageName;
            PackageDescreption = viewModel.AdvancedPackageDescreption;
            DeliveryTime = viewModel.AdvancedDeliveryTime;
        }

        public void Modify(GigFormViewModel updatedViewModel)
        {
            //CODE FOR ADVANCED PACKAGE
            Price = updatedViewModel.AdvancedPrice;
            PackageName = updatedViewModel.AdvancedPackageName;
            PackageDescreption = updatedViewModel.AdvancedPackageDescreption;
            DeliveryTime = updatedViewModel.AdvancedDeliveryTime;
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