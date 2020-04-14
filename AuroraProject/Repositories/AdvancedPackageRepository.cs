using AuroraProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuroraProject.Repositories
{
    public class AdvancedPackageRepository
    {
        private readonly ApplicationDbContext _context;
        public AdvancedPackageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddAdvancedPackage(AdvancedPackage advancedPackage)
        {
            _context.AdvancedPackages.Add(advancedPackage);
        }

        public void RemoveAdvancedPackage(AdvancedPackage advancedPackage)
        {
            _context.AdvancedPackages.Remove(advancedPackage);
        }
    }
}