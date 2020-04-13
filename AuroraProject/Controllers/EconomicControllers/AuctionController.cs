using AuroraProject.Models;
using AuroraProject.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace AuroraProject.Controllers
{
    [Authorize]
    public class AuctionController : Controller
    {

        private ApplicationDbContext context;
        public AuctionController()
        {
            context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }

        public ActionResult AuroraPro(int? specificIndustryID)
        {
            // BRING THE GIGS WITH THE DATA I WANT
            var auctions = context.Auctions
                .Include(a => a.Gig)
                .Include(a => a.Gig.User)
                .Include(a => a.Gig.BasicPackage)
                .Include(g => g.Gig.SpecificIndustry)
                .Include(g => g.Gig.SpecificIndustry.Industry)
                .Include(g => g.Gig.Influencer)
                .Where(g => g.SpecificIndustryID == specificIndustryID)
                .ToList();

            // SORT THE GIG WITH THE CORRECT SORTER
            BubbleSort.SortDescendingBet(auctions);

            // SEND GIGS TO THE VIEW
            var viewModel = new AuctionViewModel(auctions, User.Identity.IsAuthenticated,
                specificIndustryID == null ? "No Gigs were Found" : $"All {context.SpecificIndustries.SingleOrDefault(sp => sp.ID == specificIndustryID).Name} Pro Gigs");

            //SEND THE SORTED LIST TO THE VIEW
            return View("AuroraPro", viewModel);
        }

        // GET: Auction
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            var gigs = context.Gigs.Where(g => g.UserID == userId && g.IsDisabled == false).ToList();
            var auctions = context.Auctions.Where(a => a.Gig.UserID == userId).Include(a => a.Gig).ToList();

            BubbleSort.SortDescendingBet(auctions);

            foreach (var auction in auctions)
            {
                int index = auctions.IndexOf(auction);
                auction.PositionOnMarket = index + 1;
                context.SaveChanges();
            }

            // CREATE VIEW MODEL TO SEND IT TO THE VIEW
            var viewModel = new AuctionFormViewModel
            {
                Gigs = gigs,
                Auctions = auctions
            };

            BubbleSort.SortDescendingBet(auctions);

            return PartialView("_Auction", viewModel);
        }

        // POST: Auction
        [HttpPost]
        public ActionResult Create(AuctionFormViewModel viewModel)
        {
            // CHECK IF MODEL IS VALID
            if (!ModelState.IsValid)
                return RedirectToAction("Details", "influencer");

            var userId = User.Identity.GetUserId();

            var gig = context.Gigs
                .Include(g => g.User)
                .Include(g => g.User.Wallet)
                .Include(g => g.SpecificIndustry)
                .Single(g => g.UserID == userId && g.ID == viewModel.GigID);

            var auctions = context.Auctions.Where(a => a.SpecificIndustryID == gig.SpecificIndustry.ID).ToList();

            if (context.Auctions.SingleOrDefault(a => a.GigID == viewModel.GigID) != null)
                context.Auctions.Remove(context.Auctions.SingleOrDefault(a => a.GigID == viewModel.GigID));

            var auction = Auction.CreateAuction(viewModel, gig, context.AuroraWallets.Single(a => a.ID == 1));

            //auctions.Add(auction);
            //BubbleSort.SortDescendingBet(auctions);
            //int index = auctions.IndexOf(auction);
            //auction.PositionOnMarket = index;


            context.Auctions.Add(auction);
            context.SaveChanges();

            // WHEN EVERYTHING IS DONE GO TO INDEX
            return RedirectToAction("Details", "influencer");
        }
    }
}