using AuroraProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuroraProject.Core.ViewModels
{
    public class InfluencerViewModel
    {
        public IEnumerable<Influencer> Influencers { get; set; }
        public bool ShowActions { get; set; }
        public string Heading { get; set; }

        public ILookup<int, FavouriteInfluencer> FavouriteInfluencers { get; set; }

        //RELATION WITH FILE - UPLOADING IMAGES ETC
        public ICollection<FileUpload> FileUploads { get; set; }
        public InfluencerViewModel()
        {

        }
        public InfluencerViewModel(IEnumerable<Influencer> influencers, bool showActions, string heading)
        {
            Influencers = influencers;
            ShowActions = showActions;
            Heading = heading;
        }
    }
}