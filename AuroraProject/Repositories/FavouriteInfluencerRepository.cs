using AuroraProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuroraProject.Repositories
{
    public class FavouriteInfluencerRepository
    {
        private readonly ApplicationDbContext _context;
        public FavouriteInfluencerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<FavouriteInfluencer> GetFavouriteInfluencer(int influencerId, string userId)
        {
            return _context.FavouriteInfluencers
                    .Where(f => f.InfluencerID == influencerId && f.FollowerID == userId);
        }

        public IEnumerable<FavouriteInfluencer> GetFavouriteInfluencers(string userId)
        {
            return _context.FavouriteInfluencers.Where(f => f.FollowerID == userId);
        }
    }
}