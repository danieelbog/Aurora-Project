using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuroraProject.Models
{
    public class Auction
    {
        public int ID { get; set; }
        public float Bet { get; set; }
        public int PositionOnMarket { get; set; }

        [Required]
        public int SpecificIndustryID { get; set; }
        public SpecificIndustry SpecificIndustry { get; set; }
        
        [Required]
        public int GigID { get; set; }
        public Gig Gig { get; set; }

        public void PutBet(List<Auction> auctions, Auction newAuction, ApplicationUser user, List<Gig> allGigs, AuroraWallet auroraWallet)
        {
            auctions.Add(newAuction);
            BubbleSort.SortDescendingBet(auctions);

            var counter = 0;

            foreach (var auction in auctions)
            {
                counter++;
                auction.PositionOnMarket = counter;
            }

            if(newAuction.PositionOnMarket < 5)
            {
                if(user.Wallet.Value >= newAuction.Bet)
                {
                    user.TransferMoneyToAurora(user.Wallet, auroraWallet, newAuction.Bet);
                    Auction.PutGigOnTheMarket(allGigs, newAuction);
                }
                else
                {
                    newAuction.Bet = user.Wallet.Value;
                    PutBet(auctions, newAuction, user, allGigs, auroraWallet);
                }             
            }
            
        }

        public static List<Gig> PutGigOnTheMarket(List<Gig> gigs, Auction newAuction)
        {
            //NICE CHANCE FOR REFLECTION HERE

            //gigs[newAuction.PositionOnMarket] = newAuction.Gig;
            gigs.Insert(newAuction.PositionOnMarket, newAuction.Gig);


            return gigs;
        }
    }
}