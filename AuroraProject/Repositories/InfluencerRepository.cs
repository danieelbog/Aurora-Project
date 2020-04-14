using AuroraProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuroraProject.Repositories
{
    public class InfluencerRepository
    {
        private readonly ApplicationDbContext _context;
        public InfluencerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<FavouriteInfluencer> GetFavouriteInfluencers(int influencerId, string userId)
        {
            return _context.FavouriteInfluencers
                    .Where(f => f.InfluencerID == influencerId && f.FollowerID == userId);
        }
    }
}