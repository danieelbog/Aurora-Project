using AuroraProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using AuroraProject.Core.Repositories;

namespace AuroraProject.Persistence.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;
        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ICollection<Order> GetOrders(string userId)
        {
            return _context.Orders
                .Include(o => o.BasicPackage)
                .Include(o => o.AdvancedPackage)
                .Include(o => o.PremiumPackage)
                .Include(o => o.User)
                .Where(o => o.UserID == userId)
                .ToList();
        }

        public Order GetOrder(int orderId)
        {
            return _context.Orders
                .Include(o => o.BasicPackage)
                .Include(o => o.AdvancedPackage)
                .Include(o => o.PremiumPackage)
                .Include(o => o.User)
                .SingleOrDefault(o => o.ID == orderId);

        }

        public IEnumerable<Order> GetOrdersInShoppingCart(string userId)
        {
            return _context.ShoppingCarts
                .Select(s => s.Orders.SingleOrDefault(o => o.User.Id == userId))
                .Include(o => o.BasicPackage)
                .Include(o => o.AdvancedPackage)
                .Include(o => o.PremiumPackage)
                .Include(o => o.User);
        }

        public void AddOrder(Order order)
        {
            _context.Orders.Add(order);
        }

        public void RemoveOrder(Order order)
        {
            _context.Orders.Remove(order);
        }
    }
}