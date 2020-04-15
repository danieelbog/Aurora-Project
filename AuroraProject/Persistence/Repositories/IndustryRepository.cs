using AuroraProject.Core.Models;
using AuroraProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuroraProject.Persistence.Repositories
{
    public class IndustryRepository : IIndustryRepository
    {
        private readonly ApplicationDbContext _context;

        public IndustryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Industry> GetIndustries()
        {
            return _context.Industries.ToList();
        }
    }
}