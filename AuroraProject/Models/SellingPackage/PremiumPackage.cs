using AuroraProject.Interfaces;
using AuroraProject.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuroraProject.Models
{
    public class PremiumPackage : ISellingPackage
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
        protected PremiumPackage()
        {

        }

        public PremiumPackage(GigFormViewModel viewModel)
        {
            Price = viewModel.PremiumPrice;
            PackageName = viewModel.PremiumPackageName;
            PackageDescreption = viewModel.PremiumPackageDescreption;
            DeliveryTime = viewModel.PremiumDeliveryTime;
        }

        public void Modify(GigFormViewModel updatedViewModel)
        {
            //CODE FOR ADVANCED PACKAGE
            Price = updatedViewModel.PremiumPrice;
            PackageName = updatedViewModel.PremiumPackageName;
            PackageDescreption = updatedViewModel.PremiumPackageDescreption;
            DeliveryTime = updatedViewModel.PremiumDeliveryTime;
        }

        public void SellPackage(ApplicationUser user, Wallet toUserWallet, AuroraWallet toAuroraWallet)
        {
            var auroraMortage = Price * 0.05f;
            var clearPrice = Price - auroraMortage;

            user.TransferMoneyToAurora(user.Wallet, toAuroraWallet, auroraMortage);
            user.TransferMoneyToUser(user.Wallet, toUserWallet, clearPrice);
        }
    }
}