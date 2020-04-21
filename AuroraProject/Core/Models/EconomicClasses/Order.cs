using AuroraProject.Core.DTO;
using AuroraProject.Core.Repositories;
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
        public string Name { get; set; }
        public int Count { get; set; }
        public float Price { get; set; }
        public string Descreption { get; set; }
        public string Coupon { get; set; }
        public string SellerInstructions { get; set; }
        public DateTime DateOrdered { get; set; }
        public bool IsPayed { get; private set; }


        [Required]
        public int ShoppingCartID { get; set; }
        public ShoppingCart ShoppingCart { get; set; }

        [Required]
        public int GigID { get; set; }
        public Gig Gig { get; set; }

        protected Order()
        {
            DateOrdered = DateTime.Now;
        }

        public Order(string name,int count, float price, string descreption, string coupon, string sellerInstructions, int shoppingCartID, int gigID)
        {
            Name = name;
            Count = count;
            Price = price;
            Descreption = descreption;
            Coupon = coupon;
            SellerInstructions = sellerInstructions;
            DateOrdered = DateTime.Now;
            ShoppingCartID = shoppingCartID;
            GigID = gigID;
        }

        public static Order CreateOrder(int count, ISellingPackage sellingPackage, string coupon, string sellerInstructions, int shoppingCartID, int gigID)
        {
            var order = new Order(sellingPackage.PackageName, count, sellingPackage.Price, sellingPackage.PackageDescreption, coupon, sellerInstructions, shoppingCartID, gigID);

            order.Price = count * sellingPackage.Price;

            return order;
        }

        public void Modify(Order order)
        {
            Count = order.Count;
            Price = Count * order.Price;
            Descreption = order.Descreption;
            Coupon = order.Coupon;
            SellerInstructions = order.SellerInstructions;
            DateOrdered = DateTime.Now;
        }

        public void Payed()
        {
            IsPayed = true;
        }
    }
}