using AuroraProject.Models;

namespace AuroraProject.Repositories
{
    public interface IUserNotificationsRepository
    {
        void AddUserNotification(UserNotification userNotification);
        UserNotification GetNotifications(int notificationId);
        void RemoveUserNotification(UserNotification userNotification);
    }
}