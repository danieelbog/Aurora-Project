using AuroraProject.Models;
using System.Collections.Generic;

namespace AuroraProject.Repositories
{
    public interface IAuctionRepository
    {
        void AddAuctionForGig(Auction auction);
        Auction GetAuctionForGig(int gigId);
        IEnumerable<Auction> GetAuctionsForAuction(string userId);
        IEnumerable<Auction> GetAuctionsForProIndex(int? specificIndustryId);
        void RemoveAuctionForGig(int gigId);
    }
}