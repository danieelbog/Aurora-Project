using AuroraProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuroraProject.Repositories
{
    public class SpecificIndustryRepository
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
            return _context.SpecificIndustries.ToList();
        }
    }
}