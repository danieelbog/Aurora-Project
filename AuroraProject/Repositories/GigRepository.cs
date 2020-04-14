using AuroraProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AuroraProject.Repositories
{
    public class GigRepository
    {
        private readonly ApplicationDbContext _context;
        public GigRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Gig GetGigForDetails(int gigID)
        {
            return _context.Gigs
                .Include(g => g.User)
                .Include(g => g.BasicPackage)
                .Include(g => g.AdvancedPackage)
                .Include(g => g.PremiumPackage)
                .Include(g => g.SpecificIndustry)
                .Include(g => g.Influencer)
                .Include(g => g.Influencer.FileUploads)
                .Include(i => i.FileUploads)
                .SingleOrDefault(g => g.ID == gigID);
        }

        public IEnumerable<FavouriteGig> GetFavouriteGigs(int gigID, string userId)
        {
            return _context.FavouriteGigs
                    .Where(f => f.GigID == gigID && f.ActionerID == userId)
                    .ToList();
        }

    }
}