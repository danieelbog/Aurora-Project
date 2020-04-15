using AuroraProject.Core.Models;
using AuroraProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AuroraProject.Persistence.Repositories
{
    public class InfluencerRepository : IInfluencerRepository
    {
        private readonly ApplicationDbContext _context;
        public InfluencerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Influencer GetInfluencerForUser(string userId)
        {
            return _context.Influencers.SingleOrDefault(i => i.User.Id == userId);
        }

        public Influencer GetInfluencerForForm(string userId)
        {
            return _context.Influencers
                .Include(i => i.MembershipType)
                .Include(i => i.FileUploads)
                .Include(i => i.User)
                .SingleOrDefault(i => i.User.Id == userId);
        }

        public Influencer GetInfluencerForUpdate(int influencerId)
        {
            return _context.Influencers
                .Include(i => i.MembershipType)
                .Include(i => i.User)
                .Include(i => i.User.Wallet)
                .Include(i => i.FileUploads)
                .SingleOrDefault(i => i.ID == influencerId);
        }

        public void AddInfluencer(Influencer influencer)
        {
            _context.Influencers.Add(influencer);
        }

        public void RemoveInfluencer(Influencer influencer)
        {
            _context.Influencers.Remove(influencer);
        }
    }
}