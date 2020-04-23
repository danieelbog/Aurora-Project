using AuroraProject.Core.Models;
using AuroraProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AuroraProject.Persistence.Repositories
{
    public class AuctionRepository : IAuctionRepository
    {
        private readonly ApplicationDbContext _context;
        public AuctionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Auction> GetAuctionsForProIndex(int? specificIndustryId)
        {
            var auctions = _context.Auctions
                .Include(a => a.Gig)
                .Include(a => a.Gig.User)
                .Include(a => a.Gig.BasicPackage)
                .Include(g => g.Gig.SpecificIndustry)
                .Include(g => g.Gig.SpecificIndustry.Industry)
                .Include(g => g.Gig.Influencer)
                .Include(g => g.Gig.Influencer.FileUploads)
                .Where(g => g.SpecificIndustryID == specificIndustryId)
                .ToList();

            // SORT THE GIG WITH THE CORRECT SORTER
            BubbleSort.SortDescendingBet(auctions);

            return auctions;
        }

        public IEnumerable<Auction> GetAuctionsForAuction()
        {
            var auctions = _context.Auctions.Include(a => a.Gig).ToList();

            BubbleSort.SortDescendingBet(auctions);

            return auctions;
        }

        public Auction GetAuctionForGig(int gigId)
        {
            return _context.Auctions.SingleOrDefault(a => a.GigID == gigId);
        }

        public void AddAuctionForGig(Auction auction)
        {
            _context.Auctions.Add(auction);
        }

        public void RemoveAuctionForGig(int gigId)
        {
            var auction = GetAuctionForGig(gigId);

            _context.Auctions.Remove(auction);
        }

        public IEnumerable<Auction> GetAuctionsForFormAuction(string userId)
        {
            var auctions = _context.Auctions.Where(a => a.Gig.UserID == userId).Include(a => a.Gig).ToList();

            BubbleSort.SortDescendingBet(auctions);

            return auctions;
        }
    }
}