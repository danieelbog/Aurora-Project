using AuroraProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuroraProject.Core.ViewModels
{
    public class ShoppingCartViewModel
    {
        public ShoppingCart ShoppingCart { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public ShoppingCartViewModel()
        {

        }

        public ShoppingCartViewModel(ShoppingCart shoppingCart, IEnumerable<Order> orders)
        {
            Orders = orders;
            ShoppingCart = shoppingCart;
        }
    }
}