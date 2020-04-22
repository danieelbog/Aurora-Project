using AuroraProject.Core;
using AuroraProject.Core.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuroraProject.Controllers
{
    [Authorize]
    public class ShoppingCartController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        public ShoppingCartController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: ShoppingCart
        public ActionResult ShoppingCart()
        {
            var userId = User.Identity.GetUserId();
            //GET SHOPPING CAR
            var shoppingCart = unitOfWork.ShoppingCartRepository.GetShoppingCart(userId);
            //GET ORDERS
            var orders = unitOfWork.OrderRepository.GetOrders(shoppingCart.ID);
            //SEND DATA TO VIEWMODEL
            var viewModel = new ShoppingCartViewModel(shoppingCart, orders);

            return View("ShoppingCart",viewModel);
        }
    }
}