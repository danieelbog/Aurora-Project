using AuroraProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuroraProject.Core.ViewModels
{
    public class GigDetailsViewModel
    {
        public Gig Gig { get; set; }
        public bool ShowActions { get; set; }
        public string Heading { get; set; }


        public bool isFavourited { get; set; }
        public bool isFollowing { get; set; }

        public GigDetailsViewModel()
        {

        }
        public GigDetailsViewModel(Gig gig, string heading)
        {
            Gig = gig;
            Heading = heading;
        }
    }
}