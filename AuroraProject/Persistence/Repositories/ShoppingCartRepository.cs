using AuroraProject.Core.Models;
using AuroraProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AuroraProject.Persistence.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly ApplicationDbContext _context;
        public ShoppingCartRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ShoppingCart GetShoppingCart(string userId)
        {
            return _context.ShoppingCarts
                .Include(s => s.Owner)
                .Include(s => s.Orders)
                .SingleOrDefault(s => s.Owner.Id == userId);
        }
    }
}