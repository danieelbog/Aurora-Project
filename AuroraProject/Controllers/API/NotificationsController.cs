using AuroraProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using AuroraProject.DTO;
using AutoMapper;

namespace AuroraProject.Controllers.API
{
    [Authorize]
    public class NotificationsController : ApiController
    {
        private ApplicationDbContext context;

        public NotificationsController()
        {
            context = new ApplicationDbContext();
        }

        public IEnumerable<NotificationDto> GetNotifications()
        {
            var userId = User.Identity.GetUserId();
            var notifications = context.UserNotifications
                .Where(un => un.UserId == userId && !un.IsRead)
                .Select(un => un.Notification)
                .ToList();

            return notifications.Select(Mapper.Map<Notification, NotificationDto>);
        }

        [HttpPost]
        public IHttpActionResult MarkAsRead(NotificationDto userNotificationDto)
        {

            var userId = User.Identity.GetUserId();

            var notification = context.UserNotifications
                 .Single(un => un.UserId == userId && !un.IsRead && userNotificationDto.NotificationID == un.NotificationId);

            if (notification == null)
                return BadRequest("No Notification Found");

            notification.Read();

            context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {

            var userId = User.Identity.GetUserId();

            var notification = context.UserNotifications
                 .Single(un => un.UserId == userId && id == un.NotificationId);

            if (notification == null)
                return BadRequest("No Notification Found");

            context.UserNotifications.Remove(notification);

            context.SaveChanges();

            return Ok(id);
        }
    }
}
