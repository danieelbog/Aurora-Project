﻿using AuroraProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuroraProject.Repositories
{
    public class AuroraWalletRepository : IAuroraWalletRepository
    {
        private readonly ApplicationDbContext _context;
        public AuroraWalletRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public AuroraWallet GetAuroraWallet()
        {
            return _context.AuroraWallets.Single(w => w.ID == 1);
        }
    }
}