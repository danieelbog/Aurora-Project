using AuroraProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuroraProject.Repositories
{
    public class NotificationsRepository
    {
        private readonly ApplicationDbContext _context;
        public NotificationsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Notification> GetNotifications(string userId)
        {
            return _context.UserNotifications
                .Where(un => un.UserId == userId && !un.IsRead)
                .Select(un => un.Notification)
                .ToList();
        }
    }
}