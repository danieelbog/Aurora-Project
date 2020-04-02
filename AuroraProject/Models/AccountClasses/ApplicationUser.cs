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

namespace AuroraProject.Models
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

        ////NAVIGATION TO INFLUENCER  
        //public Influencer Influencer { get; set; }

        //RELATIONSHIP WITH FAVORITE GIGS
        public ICollection<FavouriteGig> Gigs { get; set; }

        //RELATION WITH FAVOURITE INFLUENCER
        public ICollection<FavouriteInfluencer> Influencers { get; set; }

        ////RELATION WITH WALLET
        //public int WalletID { get; set; }
        //public Wallet Wallet { get; set; }

        public ApplicationUser()
        {
            Gigs = new Collection<FavouriteGig>();
            Influencers = new Collection<FavouriteInfluencer>();
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

        //public void PayAmount(float amountToPay, Wallet wallet)
        //{
        //    if (wallet.Value >= amountToPay)
        //    {
        //        wallet.SubMoney(amountToPay, WalletID);
        //    }
        //}

        //public void DepositAmount(float amountToAdd, Wallet wallet)
        //{
        //    wallet.AddMoney(amountToAdd, WalletID);
        //}
    }
}