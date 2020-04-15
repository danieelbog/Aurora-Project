using AuroraProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuroraProject.Core.Models
{
    public enum NotificationType
    {
        PurchaseGig = 1,
        SellGig = 2,
        PurchaseMembership = 3,
        DepositMoney = 4,
        WithdrawMoney = 5
    }

    public class Notification
    {
        public int ID { get; private set; }
        public DateTime DateTime { get; private set; }
        public string Message { get; set; }
        public string BuyerName { get; set; }
        public string SellerName { get; set; }
        public NotificationType Type { get; private set; }

        protected Notification()
        {

        }

        private Notification(NotificationType type, string sellerName, string buyerName)
        {
            Type = type;
            DateTime = DateTime.Now;
            BuyerName = buyerName;
            SellerName = sellerName;
        }

        public static Notification GigPurchased(ISellingPackage sellingPackage, string sellerName)
        {
            var purchaseNotification = new Notification(NotificationType.PurchaseGig, sellerName, null);

            purchaseNotification.Message = $"{sellingPackage.PackageName} was purchased for {sellingPackage.Price}$ at {purchaseNotification.DateTime} from {purchaseNotification.SellerName}";

            return purchaseNotification;
        }

        public static Notification GigSold(ISellingPackage sellingPackage, string buyerName)
        {
            var sellNotification = new Notification(NotificationType.SellGig, null, buyerName);

            sellNotification.Message = $"{sellingPackage.PackageName} was sold for {sellingPackage.Price}$ at {sellNotification.DateTime} to {sellNotification.BuyerName}";

            return sellNotification;
        }

        //public static Notification SubscriptionPurchased(MembershipType membershipType, string buyerName)
        //{
        //    var purchaseNotification = new Notification(NotificationType.PurchaseMembership, "Aurora", buyerName);

        //    purchaseNotification.Message = $"You purchased {membershipType.Name} membership, for {membershipType.Price}$ at {purchaseNotification.DateTime} from {purchaseNotification.SellerName}";

        //    return purchaseNotification;
        //}

        public static Notification MoneyDeposited(float ammount)
        {
            var notification = new Notification(NotificationType.DepositMoney, null, null);

            notification.Message = $"You Deposited {ammount}$ to your Wallet at {notification.DateTime}";

            return notification;
        }

        public static Notification MoneyWithdroawed(float ammount)
        {
            var notification = new Notification(NotificationType.WithdrawMoney, "Aurora", null);

            notification.Message = $"You Withdrawed {ammount}$ from your Wallet at {notification.DateTime}";

            return notification;
        }
    }
}