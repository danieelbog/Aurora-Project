﻿using AuroraProject.Interfaces;
using AuroraProject.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuroraProject.Models
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

        public void SellPackage(ApplicationUser user, Wallet toUserWallet, AuroraWallet toAuroraWallet)
        {
            var auroraMortage = Price * 0.05f;
            var clearPrice = Price - auroraMortage;

            user.TransferMoneyToAurora(user.Wallet, toAuroraWallet, auroraMortage);
            user.TransferMoneyToUser(user.Wallet, toUserWallet, clearPrice);
        }
    }
}