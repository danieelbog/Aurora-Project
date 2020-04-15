using AuroraProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuroraProject.Core.ViewModels
{
    public class AuctionViewModel
    {
        public IEnumerable<Auction> Auctions { get; set; }
        public bool ShowActions { get; set; }
        public string Heading { get; set; }

        public AuctionViewModel()
        {

        }

        public AuctionViewModel(IEnumerable<Auction> auctions, bool showActions, string heading)
        {
            Auctions = auctions;
            ShowActions = showActions;
            Heading = heading;
        }
    }
}