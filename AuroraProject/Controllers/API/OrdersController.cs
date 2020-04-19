using AuroraProject.Core;
using AuroraProject.Core.DTO;
using AuroraProject.Core.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AuroraProject.Controllers.API
{
    [Authorize]
    public class OrdersController : ApiController
    {
        private readonly IUnitOfWork unitOfWork;
        public OrdersController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IHttpActionResult AddOrder(OrderDto orderDto)
        {
            var userId = User.Identity.GetUserId();

            var shoppingCart = unitOfWork.ShoppingCartRepository.GetShoppingCart(userId);

            if (shoppingCart == null)
                return BadRequest();

            if(orderDto.BasicPackageID != null)
            {
                var sellingPackage = unitOfWork.BasicPackageRepository.GetBasicPackagePurchase(orderDto.BasicPackageID);

                if (sellingPackage == null)
                    return BadRequest();

                var order = Order.SetOrder(sellingPackage, null,null,orderDto.Count, shoppingCart);
                shoppingCart.Orders.Add(order);

            }
            else if (orderDto.AdvancedPackageID != null)
            {
                var sellingPackage = unitOfWork.AdvancedPackageRepository.GetAdvancedPackagePurchase(orderDto.AdvancedPackageID);

                if (sellingPackage == null)
                    return BadRequest();

                var order = Order.SetOrder(null, sellingPackage, null, orderDto.Count, shoppingCart);
                shoppingCart.Orders.Add(order);
            }
            else if (orderDto.PremiumPackageID != null)
            {
                var sellingPackage = unitOfWork.PremiumPackageRepository.GetPremiumPackagePurchase(orderDto.PremiumPackageID);

                if (sellingPackage == null)
                    return BadRequest();

                var order = Order.SetOrder(null, null, sellingPackage, orderDto.Count, shoppingCart);
                shoppingCart.Orders.Add(order);
            }
            else
            {
                return BadRequest();
            }

            unitOfWork.Complete();

            return Ok();
        }
    }
}
