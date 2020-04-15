using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuroraProject.Core.Models
{
    public class MembershipType
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }

        [Display(Name = "Duration in months left")]
        public int DurationInDays { get; set; }
        public float Discount { get; set; }

        public static void SellMembershipType(ApplicationUser user, int membershipTypeID, AuroraWallet auroraWallet)
        {
            var payment = 0.0f;

            switch (membershipTypeID)
            {
                case 1:
                    payment = 20.00f;
                    break;
                case 2:
                    payment = 50.00f;
                    break;
                case 3:
                    payment = 190.00f;
                    break;
                case 4:
                    payment = 500.00f;
                    break;
                default:
                    payment = 0.0f;
                    break;
            }
            user.TransferMoneyToAurora(user.Wallet, auroraWallet, payment);
        }

        public static void ModifyMembershipType(ApplicationUser user, int oldMembershipTypeID, int newMembershipTypeID, AuroraWallet auroraWallet)
        {
            var pricePerDay = 0.0f;
            var durationInDays = 0;
            var discount = 0.0f;

            switch (oldMembershipTypeID)
            {
                case 1:
                    pricePerDay = 1.5f;
                    durationInDays = 30;
                    discount = 0;
                    break;
                case 2:
                    if (newMembershipTypeID < 2)
                    {
                        pricePerDay = 0.55f;
                        durationInDays = 90;
                        discount = 10;
                    }
                    else
                    {
                        pricePerDay = 0.55f;
                        durationInDays = 90;
                        discount = 0;
                    }
                    break;
                case 3:
                    if (newMembershipTypeID < 3)
                    {
                        pricePerDay = 0.52f;
                        durationInDays = 365;
                        discount = 15;
                    }
                    else
                    {
                        pricePerDay = 0.52f;
                        durationInDays = 365;
                        discount = 0;
                    }
                    break;
                case 4:
                    if (newMembershipTypeID < 4)
                    {
                        pricePerDay = 1.37f;
                        durationInDays = 365;
                        discount = 20;
                    }
                    else
                    {
                        pricePerDay = 1.37f;
                        durationInDays = 365;
                        discount = 0;
                    }
                    break;
                default:
                    pricePerDay = 0;
                    break;
            }
            //ALGORYTHM FOR THE PAYMENT
            float payment = pricePerDay * durationInDays - (pricePerDay * durationInDays * discount) / 100;

            //DEPOSIT ANY MONEY LEFT BASED ON THE DURATION
            user.RecieveMoneyFromAurora(auroraWallet, user.Wallet, payment);

            //BY THE NEW MEMBERSHIP TYPE
            SellMembershipType(user, newMembershipTypeID, auroraWallet);
        }
    }
}
    