using AuroraProject.Core.Models;

namespace AuroraProject.Core.Repositories
{
    public interface IUserNotificationsRepository
    {
        void AddUserNotification(UserNotification userNotification);
        UserNotification GetNotificationsToDisplay(int notificationId);
        UserNotification GetNotificationsToDelete(int notificationId);
        void RemoveUserNotification(UserNotification userNotification);
    }
}