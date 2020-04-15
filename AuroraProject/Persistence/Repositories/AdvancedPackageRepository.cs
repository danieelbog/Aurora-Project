using AuroraProject.Core.Models;
using AuroraProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuroraProject.Persistence.Repositories
{
    public class AdvancedPackageRepository : IAdvancedPackageRepository
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

        public AdvancedPackage GetAdvancedPackagePurchase(int? advancedPackageId)
        {
            return _context.AdvancedPackages.Single(b => b.ID == advancedPackageId);
        }
    }
}