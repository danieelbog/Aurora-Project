using AuroraProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using AuroraProject.Core.DTO;
using AutoMapper;
using AuroraProject.Persistence;
using AuroraProject.Core;

namespace AuroraProject.Controllers.API
{
    [Authorize]
    public class NotificationsController : ApiController
    {
        private readonly IUnitOfWork unitOfWork;
        public NotificationsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        //GET NOTIFICATIONS
        public IEnumerable<NotificationDto> GetNotifications()
        {
            var userId = User.Identity.GetUserId();
            var notifications = unitOfWork.NotificationsRepository.GetNotifications(userId);

            return notifications.Select(Mapper.Map<Notification, NotificationDto>);
        }

        [HttpPost]
        //MARK NOTIFICATION AS READ
        public IHttpActionResult MarkAsRead(NotificationDto userNotificationDto)
        {

            var userId = User.Identity.GetUserId();

            var notification = unitOfWork.UserNotificationsRepository.GetNotificationsToDisplay(userNotificationDto.NotificationID);

            if (notification == null)
                return BadRequest("No Notification Found");

            if (notification.UserId != userId)
                return Unauthorized();

            notification.Read();

            unitOfWork.Complete();

            return Ok();
        }
        //DELETE NOTIFICATION
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {

            var userId = User.Identity.GetUserId();

            var notification = unitOfWork.UserNotificationsRepository.GetNotificationsToDelete(id);

            if (notification == null)
                return BadRequest("No Notification Found");

            if (notification.UserId != userId)
                return Unauthorized();

            unitOfWork.UserNotificationsRepository.RemoveUserNotification(notification);

            unitOfWork.Complete();

            return Ok(id);
        }
    }
}
