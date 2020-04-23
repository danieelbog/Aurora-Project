using AuroraProject.Core.Models;
using System.Collections.Generic;

namespace AuroraProject.Core.Repositories
{
    public interface IAuctionRepository
    {
        void AddAuctionForGig(Auction auction);
        Auction GetAuctionForGig(int gigId);
        IEnumerable<Auction> GetAuctionsForAuction();
        IEnumerable<Auction> GetAuctionsForFormAuction(string userId);
        IEnumerable<Auction> GetAuctionsForProIndex(int? specificIndustryId);
        void RemoveAuctionForGig(int gigId);
    }
}