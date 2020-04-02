using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuroraProject.Models
{
    public class Influencer
    {
        public int ID { get; set; }

        [Required]
        public string MainLanguage { get; set; }

        [Required]
        public string MainPlatform { get; set; }

        [Required]
        public string Exposure { get; set; }

        [Required]
        public string MainTopic { get; set; }

        [Required]
        public string AudienceAge { get; set; }

        [Required]
        public string AudienceMainCountry { get; set; }

        public string AudienceMainState { get; set; }

        [Required]
        public string AudienceMainTrait { get; set; }

        [Required]
        public string AboutTheInfluencer { get; set; }

        //RELATION WITH APPLICATION USER
        public ApplicationUser User { get; set; }

        // RELATION WITH MEMBERSHIPTYPE
        [Required]
        public int MembershipTypeID { get; set; }
        public MembershipType MembershipType { get; set; }

        //RELATION WITH FAVOURITE INFLUENCER
        public ICollection<FavouriteInfluencer> Followers { get; set; }
    }
}