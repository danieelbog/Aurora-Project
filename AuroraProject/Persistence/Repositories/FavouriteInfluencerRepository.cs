using AuroraProject.Core.Models;
using AuroraProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AuroraProject.Persistence.Repositories
{
    public class FavouriteInfluencerRepository : IFavouriteInfluencerRepository
    {
        private readonly ApplicationDbContext _context;
        public FavouriteInfluencerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public FavouriteInfluencer GetFavouriteInfluencer(int influencerId, string userId)
        {
            return _context.FavouriteInfluencers
                    .SingleOrDefault(f => f.InfluencerID == influencerId && f.FollowerID == userId);
        }

        public IEnumerable<FavouriteInfluencer> GetFavouriteInfluencers(string userId)
        {
            return _context.FavouriteInfluencers.Where(f => f.FollowerID == userId);
        }

        public IEnumerable<Influencer> GetFavouriteInfluencersWithProperties(string userId)
        {
            return _context.FavouriteInfluencers
                .Where(f => f.FollowerID == userId)
                .Select(f => f.Influencer)
                .Include(i => i.FileUploads)
                .Include(i => i.User)
                .Include(i => i.User.Gigs)
                .ToList();
        }

        public void AddFavouriteInfluencer(FavouriteInfluencer favouriteInfluencer)
        {
            _context.FavouriteInfluencers.Add(favouriteInfluencer);
        }

        public void RemoveFavouriteInfluencer(FavouriteInfluencer favouriteInfluencer)
        {
            _context.FavouriteInfluencers.Remove(favouriteInfluencer);
        }
    }
}