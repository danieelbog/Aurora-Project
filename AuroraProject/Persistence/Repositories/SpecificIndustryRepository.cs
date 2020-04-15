using AuroraProject.Core.Models;
using AuroraProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AuroraProject.Persistence.Repositories
{
    public class SpecificIndustryRepository : ISpecificIndustryRepository
    {
        private readonly ApplicationDbContext _context;
        public SpecificIndustryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public SpecificIndustry GetSpecificIndustry(int? specificIndustryId)
        {
            return _context.SpecificIndustries.SingleOrDefault(sp => sp.ID == specificIndustryId);
        }

        public IEnumerable<SpecificIndustry> GetSpecificIndustries()
        {
            return _context.SpecificIndustries
                .Include(sp => sp.Industry);
        }

        public IEnumerable<SpecificIndustry> GetSpecificIndustriesPerIndustry(int industryId)
        {
            return _context.SpecificIndustries
                            .Where(sp => sp.IndustryID == industryId);
        }


    }
}