using AuroraProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuroraProject.Repositories
{
    public class PremiumPackageRepository
    {
        private readonly ApplicationDbContext _context;
        public PremiumPackageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddPremiumPackage(PremiumPackage premiumPackage)
        {
            _context.PremiumPackages.Add(premiumPackage);
        }

        public void RemovePremiumPackage(PremiumPackage premiumPackage)
        {
            _context.PremiumPackages.Remove(premiumPackage);
        }
    }
}