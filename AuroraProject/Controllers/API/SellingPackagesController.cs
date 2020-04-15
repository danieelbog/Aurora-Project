using AuroraProject.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using AuroraProject.DTO;
using AuroraProject.Persistence;

namespace AuroraProject.Controllers.API
{
    public class SellingPackagesController : ApiController
    {
        private readonly ApplicationDbContext context;
        private readonly UnitOfWork unitOfWork;
        public SellingPackagesController()
        {
            context = new ApplicationDbContext();
            unitOfWork = new UnitOfWork(context);
        }

        [Authorize]
        [HttpPost]
        public IHttpActionResult PurchasePackage(GigDto gigDto)
        {
            var userId = User.Identity.GetUserId();

            var buyer = unitOfWork.ApplicationUserRepository.GetUser(userId);
            if(buyer == null)
                return NotFound();

            var gig = unitOfWork.GigsRepository.GetGigForPurchase(gigDto.ID);
            if(gig == null)
                return NotFound();

            var auroraWallet = unitOfWork.AuroraWalletRepository.GetAuroraWallet();
            if (auroraWallet == null)
                return NotFound();

            if (gigDto.BasicPackageID != null && gigDto.AdvancedPackageID == null && gigDto.PremiumPackageID == null)
            {
                //BRING THE PACKAGE FOR PURCHASE
                var basicPackage = unitOfWork.BasicPackageRepository.GetBasicPackagePurchase(gigDto.BasicPackageID);
                // CHECK IF THE PACKAGE EXIST
                if (basicPackage == null)
                    return NotFound();
                else
                {
                    // CHECK IF THE PAYMENT CAN BE DONE
                    try
                    {
                        basicPackage.SellPackage(buyer, gig.User, auroraWallet);
                    }
                    catch (Exception)
                    {
                        return NotFound();
                    }
                }
            }
            else if (gigDto.BasicPackageID == null && gigDto.AdvancedPackageID != null && gigDto.PremiumPackageID == null)
            {
                //BRING THE PACKAGE FOR PURCHASE
                var advancedPackage = unitOfWork.AdvancedPackageRepository.GetAdvancedPackagePurchase(gigDto.AdvancedPackageID);
                // CHECK IF THE PACKAGE EXIST
                if (advancedPackage == null)
                    return NotFound();
                else
                {
                    // CHECK IF THE PAYMENT CAN BE DONE
                    try
                    {
                        advancedPackage.SellPackage(buyer, gig.User, auroraWallet);
                    }
                    catch (Exception)
                    {
                        return NotFound();
                    }
                }
            }
            else if (gigDto.BasicPackageID == null && gigDto.AdvancedPackageID == null && gigDto.PremiumPackageID != null)
            {
                //BRING THE PACKAGE FOR PURCHASE
                var premiumPackage = unitOfWork.PremiumPackageRepository.GetPremiumPackagePurchase(gigDto.PremiumPackageID);
                // CHECK IF THE PACKAGE EXIST
                if (premiumPackage == null)
                    return NotFound();
                else
                {
                    // CHECK IF THE PAYMENT CAN BE DONE
                    try
                    {
                        premiumPackage.SellPackage(buyer, gig.User, auroraWallet);
                    }
                    catch (Exception)
                    {
                        return NotFound();
                    }
                }
            }
            else
                return BadRequest();

            unitOfWork.Complete();
            return Ok();
        }

    }
}
