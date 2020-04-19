using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace AuroraProject.Core.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage = "Please Enter your First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please Enter your Last Name")]
        public string LastName { get; set; }

        public string UserFullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        //NAVIGATION TO INFLUENCER  
        public Influencer Influencer { get; set; }

        //RELATIONSHIP WITH FAVORITE GIGS
        public ICollection<FavouriteGig> Gigs { get; set; }

        //RELATION WITH FAVOURITE INFLUENCER
        public ICollection<FavouriteInfluencer> Influencers { get; set; }

        //NAVIGATION TO WALLET
        public Wallet Wallet { get; set; }

        //RELATION WITH USER NOTIFICATION
        public ICollection<UserNotification> UserNotifications { get; set; }

        //RELATION WITH THE SHOPPING CART
        public ShoppingCart ShoppingCart { get; set; }


        public ApplicationUser()
        {
            Gigs = new Collection<FavouriteGig>();
            Influencers = new Collection<FavouriteInfluencer>();
            UserNotifications = new Collection<UserNotification>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public static string FullName(ApplicationUser applicationUser)
        {
            return applicationUser.FirstName + " " + applicationUser.LastName;
        }

        public void TransferMoneyToUser(Wallet fromWallet, Wallet toWallet, float amount)
        {
            if (amount <= fromWallet.Value)
            {
                fromWallet.SubMoney(amount, fromWallet.ID);
                toWallet.AddMoney(amount, toWallet.ID);
            }

        }

        public void TransferMoneyToAurora(Wallet fromWallet, AuroraWallet toAuroraWallet, float amount)
        {
            if (amount <= fromWallet.Value)
            {
                fromWallet.SubMoney(amount, fromWallet.ID);
                toAuroraWallet.AddMoney(amount, toAuroraWallet.ID);
            }

        }

        public void RecieveMoneyFromAurora(AuroraWallet fromAuroraWallet, Wallet toWallet, float amount)
        {
            if (amount <= fromAuroraWallet.Balance)
            {
                fromAuroraWallet.SubMoney(amount, fromAuroraWallet.ID);
                toWallet.AddMoney(amount, toWallet.ID);
            }

        }

        public void Notify(Notification notification)
        {
            UserNotifications.Add(new UserNotification(this, notification));
        }
    }
}