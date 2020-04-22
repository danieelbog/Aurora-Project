using AuroraProject.Core.DTO;
using AuroraProject.Core.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuroraProject.App_Start
{
    public class OrganizationProfile : Profile
    {
        public OrganizationProfile()
        {
            CreateMap<Notification, NotificationDto>();
            CreateMap<Order, OrderDto>();
        }
    }
}