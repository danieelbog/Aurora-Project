using AuroraProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuroraProject.Core.ViewModels
{
    public class GigsViewModel
    {
        public IEnumerable<Gig> Gigs { get; set; }
        public bool ShowActions { get; set; }
        public string Heading { get; set; }

        public ILookup<int, FavouriteGig> FavouriteGigs { get; set; }
        public ILookup<int, FavouriteInfluencer> FavouriteInfluencers { get; set; }


        //SEARCHING FUNCTION
        public string SearchTerm { get; set; }

        public GigsViewModel()
        {

        }

        public GigsViewModel(IEnumerable<Gig> gigs, bool showActions, string heading, string searchTerm)
        {
            Gigs = gigs;
            ShowActions = showActions;
            Heading = heading;
            SearchTerm = searchTerm;
        }
    }
}