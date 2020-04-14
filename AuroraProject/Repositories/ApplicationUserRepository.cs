using AuroraProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuroraProject.Repositories
{
    public class ApplicationUserRepository
    {
        private readonly ApplicationDbContext _context;
        public ApplicationUserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ApplicationUser GetUser(string userId)
        {
            return _context.Users.SingleOrDefault(u => u.Id == userId);
        }
    }
}