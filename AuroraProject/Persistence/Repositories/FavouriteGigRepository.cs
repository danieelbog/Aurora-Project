using AuroraProject.Core.Models;
using AuroraProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AuroraProject.Persistence.Repositories
{
    public class FavouriteGigRepository : IFavouriteGigRepository
    {
        private readonly ApplicationDbContext _context;
        public FavouriteGigRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public FavouriteGig GetFavouriteGig(int gigID, string userId)
        {
            return _context.FavouriteGigs
                    .SingleOrDefault(f => f.GigID == gigID && f.ActionerID == userId);
        }

        public IEnumerable<FavouriteGig> GetFavouriteGigs(string userId)
        {
            return _context.FavouriteGigs.Where(f => f.ActionerID == userId);
        }

        public IEnumerable<Gig> GetFavouriteGigsFullInfo(string userId)
        {
            var gigs = _context.FavouriteGigs
                .Where(f => f.ActionerID == userId)
                .Select(f => f.Gig)
                .Include(g => g.User)
                .Include(g => g.BasicPackage)
                .Include(g => g.SpecificIndustry)
                .Include(g => g.Influencer)
                .Include(g => g.Influencer.FileUploads)
                .Include(i => i.FileUploads)
                .ToList();

            // SORT THE GIG WITH THE CORRECT SORTER
            Sorter.SortLogic(gigs);

            return gigs;
        }

        public void AddFavouriteGig(FavouriteGig favouriteGig)
        {
            _context.FavouriteGigs.Add(favouriteGig);
        }

        public void RemoveFavouriteGig(FavouriteGig favouriteGig)
        {
            _context.FavouriteGigs.Remove(favouriteGig);
        }
    }
}