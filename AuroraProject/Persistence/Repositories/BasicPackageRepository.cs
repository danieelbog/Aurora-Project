using AuroraProject.Core.Models;
using AuroraProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuroraProject.Persistence.Repositories
{
    public class BasicPackageRepository : IBasicPackageRepository
    {
        private readonly ApplicationDbContext _context;
        public BasicPackageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddBasicPackage(BasicPackage basicPackage)
        {
            _context.BasicPackages.Add(basicPackage);
        }

        public void RemoveBasicPackage(BasicPackage basicPackage)
        {
            _context.BasicPackages.Remove(basicPackage);
        }

        public BasicPackage GetBasicPackagePurchase(int? basicPackageId)
        {
            return _context.BasicPackages.Single(b => b.ID == basicPackageId);
        }
    }
}