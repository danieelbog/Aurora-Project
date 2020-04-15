using AuroraProject.Models;
using AuroraProject.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuroraProject.Repositories
{
    public class MembershipTypeRepository
    {
        private readonly ApplicationDbContext _context;
        public MembershipTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<MembershipType> GetMembershipTypes()
        {
            return _context.MembershipTypes;
        }
    }
}