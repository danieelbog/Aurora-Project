using AuroraProject.Core.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuroraProject.Core.Models
{
    public class Order
    {
        public int ID { get; set; }
        public int? BasicPackageID { get; set; }
        public BasicPackage BasicPackage { get; set; }

        public int? AdvancedPackageID { get; set; }
        public AdvancedPackage AdvancedPackage { get; set; }

        public int? PremiumPackageID { get; set; }
        public PremiumPackage PremiumPackage { get; set; }
        public int Count { get; set; }
        public float Price { get; set; }
        public DateTime DateOrdered { get; set; }

        [Required]
        public string UserID { get; set; }
        public ApplicationUser User { get; set; }

        public int ShoppingCartID { get; set; }
        public ShoppingCart ShoppingCart { get; set; }

        protected Order()
        {

        }

        private Order(int? basicPackageID, int? advancedPackageID, int? premiumPackageID, int count, ShoppingCart shoppingCart)
        {
            BasicPackageID = basicPackageID;
            AdvancedPackageID = advancedPackageID;
            PremiumPackageID = premiumPackageID;
            DateOrdered = DateTime.Now;
            Count = count;
            UserID = shoppingCart.Owner.Id;
            ShoppingCartID = shoppingCart.ID;
        }

        public static Order SetOrder(BasicPackage basicPackage, AdvancedPackage advancedPackage, PremiumPackage premiumPackage, int count, ShoppingCart shoppingCart)
        {
            if (basicPackage != null)
            {
                var order = new Order(basicPackage.ID, null, null, count, shoppingCart);
                order.Price = count * basicPackage.Price;
                return order;

            }
            else if (advancedPackage != null)
            {
                var order = new Order(null, advancedPackage.ID, null, count, shoppingCart);
                order.Price = count * advancedPackage.Price;
                return order;

            }
            else if (premiumPackage != null)
            {
                var order = new Order(null, null, premiumPackage.ID, count, shoppingCart);
                order.Price = count * premiumPackage.Price;
                return order;

            }
            else
            {
                return SetOrder(basicPackage, advancedPackage, premiumPackage, count, shoppingCart);
            }
        }
    }
}