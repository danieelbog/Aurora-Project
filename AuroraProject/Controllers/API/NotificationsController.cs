﻿using AuroraProject.Models;
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
using AuroraProject.Persistence;

namespace AuroraProject.Controllers.API
{
    [Authorize]
    public class NotificationsController : ApiController
    {
        private readonly ApplicationDbContext context;
        private readonly UnitOfWork unitOfWork;
        public NotificationsController()
        {
            context = new ApplicationDbContext();
            unitOfWork = new UnitOfWork(context);

        }

        public IEnumerable<NotificationDto> GetNotifications()
        {
            var userId = User.Identity.GetUserId();
            var notifications = unitOfWork.NotificationsRepository.GetNotifications(userId);

            return notifications.Select(Mapper.Map<Notification, NotificationDto>);
        }

        [HttpPost]
        public IHttpActionResult MarkAsRead(NotificationDto userNotificationDto)
        {

            var userId = User.Identity.GetUserId();

            var notification = unitOfWork.UserNotificationsRepository.GetNotifications(userNotificationDto.NotificationID);

            if (notification == null)
                return BadRequest("No Notification Found");

            if (notification.UserId != userId)
                return Unauthorized();

            notification.Read();

            unitOfWork.Complete();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {

            var userId = User.Identity.GetUserId();

            var notification = unitOfWork.UserNotificationsRepository.GetNotifications(id);

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
