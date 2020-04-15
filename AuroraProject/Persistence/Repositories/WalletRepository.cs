using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using AuroraProject.Core.Repositories;
using AuroraProject.Core.Models;

namespace AuroraProject.Persistence.Repositories
{
    public class WalletRepository : IWalletRepository
    {
        private readonly ApplicationDbContext _context;
        public WalletRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Wallet GetWallet(string userId)
        {
            return _context.Wallets
                .Include(w => w.Owner.UserNotifications)
                .Include(w => w.Owner.UserNotifications.Select(u => u.Notification))
                .SingleOrDefault(w => w.Owner.Id == userId);
        }

        public Wallet GetWalletForUpdate(string userId)
        {
            return _context.Wallets
                .Include(w => w.Owner)
                .Single(w => w.Owner.Id == userId);
        }
    }
}