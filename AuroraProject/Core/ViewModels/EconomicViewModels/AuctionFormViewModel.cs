using AuroraProject.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuroraProject.Core.ViewModels
{
    public class AuctionFormViewModel
    {
        public float Bet { get; set; }
        public int PositionOnMarket { get; set; }

        [Required]
        public int GigID { get; set; }
        public IEnumerable<Gig> Gigs { get; set; }
        public IEnumerable<Auction> Auctions { get; set; }

        public AuctionFormViewModel()
        {
              
        }

        public AuctionFormViewModel(float bet, int positionOnMarket, IEnumerable<Gig> gigs)
        {
            Bet = bet;
            PositionOnMarket = positionOnMarket;
            Gigs = gigs;
        }
    }
}