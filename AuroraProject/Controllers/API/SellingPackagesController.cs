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

namespace AuroraProject.Controllers.API
{
    public class SellingPackagesController : ApiController
    {
        private ApplicationDbContext context;
        public SellingPackagesController()
        {
            context = new ApplicationDbContext();
        }

        [Authorize]
        [HttpPost]
        public IHttpActionResult PurchasePackage(GigDto gigDto)
        {
            var userId = User.Identity.GetUserId();

            var buyer = context.Users
                .Include(u => u.Wallet)
                .Single(u => u.Id == userId);

            var gig = context.Gigs
                .Include(g => g.User)
                .Include(g => g.User.Wallet)
                .Single(u => u.ID == gigDto.ID);

            var auroraWallet = context.AuroraWallets.Single(a => a.ID == 1);

            if (gigDto.BasicPackageID != null && gigDto.AdvancedPackageID == null && gigDto.PremiumPackageID == null)
                context.BasicPackages.Single(b => b.ID == gigDto.BasicPackageID).SellPackage(buyer, gig.User, auroraWallet);

            else if (gigDto.BasicPackageID == null && gigDto.AdvancedPackageID != null && gigDto.PremiumPackageID == null)
                context.AdvancedPackages.Single(b => b.ID == gigDto.AdvancedPackageID).SellPackage(buyer, gig.User, auroraWallet);

            else if (gigDto.BasicPackageID == null && gigDto.AdvancedPackageID == null && gigDto.PremiumPackageID != null)
                context.PremiumPackages.Single(b => b.ID == gigDto.PremiumPackageID).SellPackage(buyer, gig.User, auroraWallet);
            else
                return BadRequest();

            context.SaveChanges();
            return Ok();
        }

    }
}
