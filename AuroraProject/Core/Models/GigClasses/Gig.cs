using AuroraProject.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuroraProject.Core.Models
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
        [Required]
        public int InfluencerID { get; set; }
        public Influencer Influencer { get; set; }

        //RELATIONSHIP WITH FAVORITE GIGS
        public ICollection<FavouriteGig> Actioners { get; set; }

        //RELATIONSHIP WITH FILES (BACKGROUND)
        public virtual ICollection<FileUpload> FileUploads { get; set; }


        protected Gig()
        {
            Actioners = new Collection<FavouriteGig>();
        }

        public Gig(GigFormViewModel viewModel, string userID, int influencerID)
        {
            UserRating = viewModel.UserRating;
            GigName = viewModel.GigName;
            Descreption = viewModel.Descreption;
            BasicPackageID = viewModel.BasicPackageID;
            AdvancedPackageID = viewModel.BasicPackageID;
            PremiumPackageID = viewModel.PremiumPackageID;
            SpecificIndustryID = viewModel.SpecificIndustryID;
            UserID = userID;
            InfluencerID = influencerID;
            Actioners = new Collection<FavouriteGig>();
        }

        public void Modify(GigFormViewModel updatedViewModel)
        {
            //CODE FOR GIG
            Descreption = updatedViewModel.Descreption;
            GigName = updatedViewModel.GigName;
            UserRating = updatedViewModel.UserRating;

            //CODE FOR BASIC PACKAGE
            BasicPackage.Modify(updatedViewModel);

            //CODE FOR ADVANCED PACKAGE
            AdvancedPackage.Modify(updatedViewModel);

            //CODE FOR PREMIUM PACKAGE
            PremiumPackage.Modify(updatedViewModel);

            //CODE FOR SPECIFIC INDUSTRY
            SpecificIndustryID = updatedViewModel.SpecificIndustryID;
        }

        public void Disable()
        {
            IsDisabled = true;
        }

        public void Enable()
        {
            IsDisabled = false;
        }
    }
}