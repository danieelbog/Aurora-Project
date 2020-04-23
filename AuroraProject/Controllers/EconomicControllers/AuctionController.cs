using AuroraProject.Core.Models;
using AuroraProject.Core.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using AuroraProject.Persistence;
using AuroraProject.Core;

namespace AuroraProject.Controllers
{
    [Authorize]
    public class AuctionController : Controller
    {

        private readonly IUnitOfWork unitOfWork;
        public AuctionController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        //BRING GIGS TO AURO PRO VIEW
        public ActionResult AuroraPro(int? specificIndustryID)
        {
            // BRING THE GIGS WITH THE DATA I WANT
            var auctions = unitOfWork.AuctionRepository.GetAuctionsForProIndex(specificIndustryID);

            // SEND GIGS TO THE VIEW
            var viewModel = new AuctionViewModel(auctions, User.Identity.IsAuthenticated,
                specificIndustryID == null ? "No Gigs were Found" : $"All {unitOfWork.SpecificIndustryRepository.GetSpecificIndustry(specificIndustryID).Name} Pro Gigs");

            if (User.Identity.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId();

                viewModel.FavouriteGigs = unitOfWork.FavouriteGigRepository.GetFavouriteGigs(userId)
                    .ToList()
                    .ToLookup(f => f.GigID);

                viewModel.FavouriteInfluencers = unitOfWork.FavouriteInfluencerRepository.GetFavouriteInfluencers(userId)
                    .ToList()
                    .ToLookup(f => f.InfluencerID);
            }

            //SEND THE SORTED LIST TO THE VIEW
            return View("AuroraPro", viewModel);
        }
        //GET AUCTION TO MY PROFILE
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            var gigs = unitOfWork.GigsRepository.GetGigsForAuction(userId).ToList();
            var auctions = unitOfWork.AuctionRepository.GetAuctionsForAuction().ToList();

            //THE VIEW THAT A USER GETS SHOULD BE ALWAYS UPDATED
            //WHEN SOMEONE UPDATES THE VIEW ALL AUCTIONS ARE SORTED AGAIN
            foreach (var auction in auctions)
            {
                int index = auctions.IndexOf(auction);
                auction.PositionOnMarket = index + 1;
                unitOfWork.Complete();
            }

            // CREATE VIEW MODEL TO SEND IT TO THE VIEW
            var viewModel = new AuctionFormViewModel
            {
                Gigs = gigs,
                Auctions = auctions.Where(a => a.Gig.UserID == userId)
            };

            return PartialView("_Auction", viewModel);
        }
        //FORM FOR THE AUCTION AT MY PROFILE
        public ActionResult AuctionForm()
        {
            var userId = User.Identity.GetUserId();

            var gigs = unitOfWork.GigsRepository.GetGigsForAuction(userId).ToList();
            var auctions = unitOfWork.AuctionRepository.GetAuctionsForFormAuction(userId).ToList();

            // CREATE VIEW MODEL TO SEND IT TO THE VIEW
            var viewModel = new AuctionFormViewModel
            {
                Gigs = gigs,
                Auctions = auctions
            };

            return PartialView("_AuctionForm", viewModel);
        }

        //POST A NEW AUTION
        [HttpPost]
        public ActionResult Create(AuctionFormViewModel viewModel)
        {
            // CHECK IF MODEL IS VALID
            if (!ModelState.IsValid)
                return RedirectToAction("Details", "influencer");

            var userId = User.Identity.GetUserId();

            var gig = unitOfWork.GigsRepository.GetGigForDetails(viewModel.GigID);
            if (gig == null)
                return HttpNotFound();

            if (gig.UserID != userId)
                return new HttpUnauthorizedResult();
            //IF THERE IS ALREADY AN AUCTION FOR THE GIG, REMOVE THE AUCTION AND POST A NEW ONE
            if (unitOfWork.AuctionRepository.GetAuctionForGig(viewModel.GigID) != null)
                unitOfWork.AuctionRepository.RemoveAuctionForGig(viewModel.GigID);
            //CREATE AUTION
            var auction = Auction.CreateAuction(viewModel, gig, unitOfWork.AuroraWalletRepository.GetAuroraWallet());
            //ADD AUCTION TO DB
            unitOfWork.AuctionRepository.AddAuctionForGig(auction);
            unitOfWork.Complete();

            // WHEN EVERYTHING IS DONE GO TO INDEX
            return RedirectToAction("Details", "influencer");
        }
    }
}