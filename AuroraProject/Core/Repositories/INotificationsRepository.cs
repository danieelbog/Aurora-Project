using AuroraProject.Core.Models;
using System.Collections.Generic;

namespace AuroraProject.Core.Repositories
{
    public interface INotificationsRepository
    {
        IEnumerable<Notification> GetNotifications(string userId);
    }
}