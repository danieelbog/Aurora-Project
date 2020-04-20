using AuroraProject.Core.Models;
using AuroraProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuroraProject.Persistence.Repositories
{
    public class UserNotificationsRepository : IUserNotificationsRepository
    {
        private readonly ApplicationDbContext _context;
        public UserNotificationsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public UserNotification GetNotificationsToDisplay(int notificationId)
        {
            return _context.UserNotifications
                 .Single(un => !un.IsRead && notificationId == un.NotificationId);
        }
        public UserNotification GetNotificationsToDelete(int notificationId)
        {
            return _context.UserNotifications
                 .Single(un => un.NotificationId == notificationId);
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