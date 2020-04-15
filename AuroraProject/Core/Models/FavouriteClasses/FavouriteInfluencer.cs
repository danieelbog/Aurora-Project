using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AuroraProject.Core.Models
{
    public class FavouriteInfluencer
    {
        [Key]
        [Column(Order = 1)]
        public string FollowerID { get; set; }

        [Key]
        [Column(Order = 2)]
        public int InfluencerID { get; set; }

        public ApplicationUser Follower { get; set; }
        public Influencer Influencer { get; set; }
    }
}