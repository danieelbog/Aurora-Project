using AuroraProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AuroraProject.Repositories
{
    public class FavouriteGigRepository
    {
        private readonly ApplicationDbContext _context;
        public FavouriteGigRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<FavouriteGig> GetFavouriteGig(int gigID, string userId)
        {
            return _context.FavouriteGigs
                    .Where(f => f.GigID == gigID && f.ActionerID == userId);
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
    }
}