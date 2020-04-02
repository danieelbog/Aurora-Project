using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuroraProject.Models
{
    public class Gig
    {
        public int ID { get; set; }
        public bool IsDisabled { get; private set; }

        [Display(Name = "Rating")]
        public byte UserRating { get; set; }

        [Required]
        [Display(Name = "Gig Name")]
        public string GigName { get; set; }

        [Required]
        [Display(Name = "Gig Wallpaper")]
        public string GigWallpaper { get; set; }

        [Required]
        [StringLength(255)]
        public string Descreption { get; set; }

        // SELLING PACKAGES RELATIONS
        [Required]
        public int BasicPackageID { get; set; }
        public BasicPackage BasicPackage { get; set; }

        [Required]
        public int AdvancedPackageID { get; set; }
        public AdvancedPackage AdvancedPackage { get; set; }

        [Required]
        public int PremiumPackageID { get; set; }
        public PremiumPackage PremiumPackage { get; set; }

        // SPECIFIC INDUSTRY RELATION
        [Required]
        public int SpecificIndustryID { get; set; }
        public SpecificIndustry SpecificIndustry { get; set; }

        //RELATION WITH APPLICATION USER
        [Required]
        public string UserID { get; set; }
        public ApplicationUser User { get; set; }

        //RELATION WITH INFLUENCER
        //[Required]
        //public int InfluencerID { get; set; }
        //public Influencer Influencer { get; set; }

        //RELATIONSHIP WITH FAVORITE GIGS
        //public ICollection<FavouriteGig> Actioners { get; set; }
    }
}