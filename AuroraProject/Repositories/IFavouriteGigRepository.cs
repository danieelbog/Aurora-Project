using AuroraProject.Models;
using System.Collections.Generic;

namespace AuroraProject.Repositories
{
    public interface IFavouriteGigRepository
    {
        void AddFavouriteGig(FavouriteGig favouriteGig);
        FavouriteGig GetFavouriteGig(int gigID, string userId);
        IEnumerable<FavouriteGig> GetFavouriteGigs(string userId);
        IEnumerable<Gig> GetFavouriteGigsFullInfo(string userId);
        void RemoveFavouriteGig(FavouriteGig favouriteGig);
    }
}