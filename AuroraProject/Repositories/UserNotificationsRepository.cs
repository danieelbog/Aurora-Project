using AuroraProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuroraProject.Repositories
{
    public class UserNotificationsRepository
    {
        private readonly ApplicationDbContext _context;
        public UserNotificationsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public UserNotification GetNotifications(int notificationId)
        {
            return _context.UserNotifications
                 .Single(un => !un.IsRead && notificationId == un.NotificationId);
        }

        public void AddUserNotification(UserNotification userNotification)
        {
            _context.UserNotifications.Add(userNotification);
        }
        public void RemoveUserNotification(UserNotification userNotification)
        {
            _context.UserNotifications.Remove(userNotification);
        }
    }
}