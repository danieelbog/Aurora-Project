using AuroraProject.Models;
using System.Collections.Generic;

namespace AuroraProject.Repositories
{
    public interface IGigRepository
    {
        void AddGig(Gig gig);
        Gig GetGigForDetails(int gigID);
        Gig GetGigForForm(int gigID);
        Gig GetGigForPurchase(int gigId);
        IEnumerable<Gig> GetGigsForAuction(string userId);
        IEnumerable<Gig> GetGigsForIndexWithSearch(int? specificIndustryID, string query = null);
        IEnumerable<Gig> GetGigsForMine(string userId);
        void RemoveGig(Gig gig);
    }
}