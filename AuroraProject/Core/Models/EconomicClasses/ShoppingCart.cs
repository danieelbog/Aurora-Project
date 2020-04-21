using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace AuroraProject.Core.Models
{
    public class ShoppingCart
    {
        public int ID { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ApplicationUser Owner { get; set; }

        public ShoppingCart()
        {
            Orders = new Collection<Order>();
        }
    }
}