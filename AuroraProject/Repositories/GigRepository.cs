﻿using AuroraProject.Models;
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

        public IEnumerable<Gig> GetGigsForIndexWithSearch(int? specificIndustryID, string query = null)
        {
            var gigs = _context.Gigs
                .Include(g => g.User)
                .Include(g => g.BasicPackage)
                .Include(g => g.SpecificIndustry)
                .Include(g => g.SpecificIndustry.Industry)
                .Include(g => g.Influencer)
                .Include(g => g.Influencer.FileUploads)
                .Include(i => i.FileUploads)
                .Where(g => !g.IsDisabled)
                .ToList();

            if (specificIndustryID != null)
                gigs = gigs.Where(g => g.SpecificIndustryID == specificIndustryID).ToList();

            if (!String.IsNullOrWhiteSpace(query))
            {
                gigs = gigs
                    .Where(g =>
                                g.User.FirstName.Contains(query) ||
                                g.User.LastName.Contains(query) ||
                                g.User.UserFullName.Contains(query) ||
                                g.SpecificIndustry.Name.Contains(query) ||
                                g.GigName.Contains(query)).ToList();
            }

            // SORT THE GIG WITH THE CORRECT SORTER
            Sorter.SortLogic(gigs);

            return gigs;
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

        public IEnumerable<Gig> GetGigsForMine(string userId)
        {
            var gigs = _context.Gigs
                .Where(g => g.UserID == userId)
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

        public Gig GetGigForForm(int gigID)
        {
            return _context.Gigs
                .Include(g => g.BasicPackage)
                .Include(g => g.AdvancedPackage)
                .Include(g => g.PremiumPackage)
                .Include(g => g.SpecificIndustry)
                .Include(g => g.Influencer)
                .Include(g => g.Influencer.FileUploads)
                .Include(i => i.FileUploads)
                .SingleOrDefault(g => g.ID == gigID);
        }

        public void AddGig(Gig gig)
        {
            _context.Gigs.Add(gig);
        }

        public void RemoveGig(Gig gig)
        {
            _context.Gigs.Remove(gig);
        }
    }
}