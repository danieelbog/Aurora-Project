using AuroraProject.Models;
using System.Collections.Generic;

namespace AuroraProject.Repositories
{
    public interface INotificationsRepository
    {
        IEnumerable<Notification> GetNotifications(string userId);
    }
}