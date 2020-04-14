﻿using AuroraProject.Models;
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

        public Influencer GetInfluencerForUser(string userId)
        {
            return _context.Influencers.SingleOrDefault(i => i.User.Id == userId);
        }

    }
}