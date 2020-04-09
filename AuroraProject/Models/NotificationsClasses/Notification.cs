using AuroraProject.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuroraProject.Models
{
    public enum NotificationType
    {
        PurchaseGig = 1,
        SellGig = 2,
    }

    public class Notification
    {
        public int ID { get; private set; }
        public DateTime DateTime { get; private set; }
        public string Message { get; set; }
        public string BuyerName { get; set; }
        public string SellerName { get; set; }

        public NotificationType Type { get; private set; }

        [Required]
        public ISellingPackage SellingPackage { get; private set; }

        protected Notification()
        {

        }

        private Notification(NotificationType type, ISellingPackage sellingPackage, string sellerName, string buyerName)
        {
            if (sellingPackage == null)
                throw new ArgumentNullException("gig");

            Type = type;
            SellingPackage = sellingPackage;
            DateTime = DateTime.Now;
            BuyerName = buyerName;
            SellerName = sellerName;
        }

        public static Notification GigPurchased(ISellingPackage sellingPackage, string sellerName)
        {
            var purchaseNotification = new Notification(NotificationType.PurchaseGig, sellingPackage, sellerName, null);

            purchaseNotification.Message = $"{sellingPackage.PackageName} was purchased for {sellingPackage.Price}$ at {purchaseNotification.DateTime} from {purchaseNotification.SellerName}";

            return purchaseNotification;
        }

        public static Notification GigSold(ISellingPackage sellingPackage, string buyerName)
        {
            var sellNotification = new Notification(NotificationType.SellGig, sellingPackage, null, buyerName);

            sellNotification.Message = $"{sellingPackage.PackageName} was purchased for {sellingPackage.Price}$ at {sellNotification.DateTime} by {sellNotification.BuyerName}";

            return sellNotification;
        }
    }
}