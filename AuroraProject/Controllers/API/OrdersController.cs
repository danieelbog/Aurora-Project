using AuroraProject.Core;
using AuroraProject.Core.DTO;
using AuroraProject.Core.Models;
using AutoMapper;
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
        //GET ORDERS
        public IEnumerable<OrderDto> GetOrders()
        {
            var userId = User.Identity.GetUserId();

            var shoppingCart = unitOfWork.ShoppingCartRepository.GetShoppingCart(userId);
            var orders = unitOfWork.OrderRepository.GetUnpayedOrders(shoppingCart.ID);

            return orders.Select(Mapper.Map<Order, OrderDto>);
        }
        //DELETE ORDERS
        [HttpDelete]
        public IHttpActionResult DeleteOrder(OrderDto orderDto)
        {
            var userId = User.Identity.GetUserId();

            var order = unitOfWork.OrderRepository.GetOrder(orderDto.OrderID);
            if (order == null)
                return BadRequest();

            unitOfWork.OrderRepository.RemoveOrder(order);

            unitOfWork.Complete();

            return Ok(orderDto.OrderID);
        }
        //PAY ORDERS
        [HttpPut]
        public IHttpActionResult PayOrder(OrderDto orderDto)
        {
            var userId = User.Identity.GetUserId();

            var shoppingCart = unitOfWork.ShoppingCartRepository.GetShoppingCart(userId);
            if (shoppingCart == null)
                return BadRequest();

            var order = unitOfWork.OrderRepository.GetOrder(orderDto.OrderID);
            if (order == null)
                return BadRequest();

            order.Payed();

            unitOfWork.Complete();

            return Ok();
        }
        //ADD ORDER
        [HttpPost]
        public IHttpActionResult AddOrder(OrderDto orderDto)
        {
            var userId = User.Identity.GetUserId();

            var shoppingCart = unitOfWork.ShoppingCartRepository.GetShoppingCart(userId);
            if (shoppingCart == null)
                return BadRequest();

            if (orderDto.BasicPackageID != null && orderDto.AdvancedPackageID == null && orderDto.PremiumPackageID == null)
            {
                //BRING THE PACKAGE FOR PURCHASE
                var package = unitOfWork.BasicPackageRepository.GetBasicPackagePurchase(orderDto.BasicPackageID);
                // CHECK IF THE PACKAGE EXIST
                if (package == null)
                    return NotFound();
                else
                {
                    var order = Order.CreateOrder(orderDto.Count, package, orderDto.Coupon, orderDto.SellerInstructions, shoppingCart.ID, orderDto.GigID);
                    shoppingCart.Orders.Add(order);
                }
            }
            else if (orderDto.BasicPackageID == null && orderDto.AdvancedPackageID != null && orderDto.PremiumPackageID == null)
            {
                //BRING THE PACKAGE FOR PURCHASE
                var package = unitOfWork.AdvancedPackageRepository.GetAdvancedPackagePurchase(orderDto.AdvancedPackageID);
                // CHECK IF THE PACKAGE EXIST
                if (package == null)
                    return NotFound();
                else
                {
                    var order = Order.CreateOrder(orderDto.Count, package, orderDto.Coupon, orderDto.SellerInstructions, shoppingCart.ID, orderDto.GigID);
                    shoppingCart.Orders.Add(order);
                }
            }
            else if (orderDto.BasicPackageID == null && orderDto.AdvancedPackageID == null && orderDto.PremiumPackageID != null)
            {
                //BRING THE PACKAGE FOR PURCHASE
                var package = unitOfWork.PremiumPackageRepository.GetPremiumPackagePurchase(orderDto.PremiumPackageID);
                // CHECK IF THE PACKAGE EXIST
                if (package == null)
                    return NotFound();
                else
                {
                    var order = Order.CreateOrder(orderDto.Count, package, orderDto.Coupon, orderDto.SellerInstructions, shoppingCart.ID, orderDto.GigID);
                    shoppingCart.Orders.Add(order);
                }
            }
            else
                return BadRequest();

            unitOfWork.Complete();

            return Ok();
        }
    }
}
