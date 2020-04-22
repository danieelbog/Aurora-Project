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

        public ICollection<Order> GetOrders(int shoppingCartID)
        {
            return _context.Orders
                .Include(o => o.Gig)
                .Include(o => o.Gig.BasicPackage)
                .Include(o => o.Gig.AdvancedPackage)
                .Include(o => o.Gig.PremiumPackage)
                .Include(o => o.Gig.User)
                .Include(o => o.Gig.FileUploads)
                .Where(o => o.ShoppingCartID == shoppingCartID)
                .ToList();
        }

        public ICollection<Order> GetUnpayedOrders(int shoppingCartID)
        {
            return _context.Orders
                .Include(o => o.Gig)
                .Include(o => o.Gig.BasicPackage)
                .Include(o => o.Gig.AdvancedPackage)
                .Include(o => o.Gig.PremiumPackage)
                .Include(o => o.Gig.User)
                .Include(o => o.Gig.FileUploads)
                .Where(o => o.ShoppingCartID == shoppingCartID && !o.IsPayed)
                .ToList();
        }

        public Order GetOrder(int orderId)
        {
            return _context.Orders
                .Include(o => o.Gig)
                .Include(o => o.Gig.User)
                .Include(o => o.Gig.FileUploads)
                .SingleOrDefault(o => o.ID == orderId);
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