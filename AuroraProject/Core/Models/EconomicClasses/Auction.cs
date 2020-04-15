using AuroraProject.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuroraProject.Core.Models
{
    public class Auction
    {
        public int ID { get; set; }
        public float Bet { get; set; }
        public int PositionOnMarket { get; set; }
        
        [Required]
        public int GigID { get; set; }
        public Gig Gig { get; set; }

        public int SpecificIndustryID { get; set; }

        protected Auction()
        {

        }

        private Auction(AuctionFormViewModel viewModel, int specificIndustryID)
        {
            Bet = viewModel.Bet;
            PositionOnMarket = viewModel.PositionOnMarket;
            GigID = viewModel.GigID;
            SpecificIndustryID = specificIndustryID;
        }

        public static Auction CreateAuction(AuctionFormViewModel viewModel, Gig gig, AuroraWallet auroraWallet)
        {
            gig.User.TransferMoneyToAurora(gig.User.Wallet, auroraWallet, viewModel.Bet);

            var auction = new Auction(viewModel, gig.SpecificIndustryID);            

            return auction;
        }

    }
}