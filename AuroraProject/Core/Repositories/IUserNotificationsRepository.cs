using AuroraProject.Core.Models;

namespace AuroraProject.Core.Repositories
{
    public interface IUserNotificationsRepository
    {
        void AddUserNotification(UserNotification userNotification);
        UserNotification GetNotifications(int notificationId);
        void RemoveUserNotification(UserNotification userNotification);
    }
}