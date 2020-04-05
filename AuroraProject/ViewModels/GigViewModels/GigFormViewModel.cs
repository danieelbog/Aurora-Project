using AuroraProject.Controllers;
using AuroraProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace AuroraProject.ViewModels
{
    public class GigFormViewModel
    {
        // GIG
        public int GigID { get; set; }

        [Display(Name = "User Rating")]
        [Range(0, 5)]
        public byte UserRating { get; set; }

        [Required(ErrorMessage = "You must chose a Name for your Gig")]
        [Display(Name = "Pick a Name for your Gig")]
        [MaxLength(15)]
        public string GigName { get; set; }

        [Required(ErrorMessage = "You must chose a Wallpaper for your Gig")]
        [Display(Name = "Add a Wallpaper to your Gig")]
        public string GigWallpaper { get; set; }

        [Required(ErrorMessage = "You must write a small Descreption for your Gig")]
        [StringLength(40)]
        [DataType(DataType.MultilineText)]
        public string Descreption { get; set; }

        // BASIC PACKAGE
        public int BasicPackageID { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public int BasicPrice { get; set; }

        [Required(ErrorMessage = "You must give a name to your package")]
        [Display(Name = "Name your Package")]
        public string BasicPackageName { get; set; }

        [Required(ErrorMessage = "You must give a Descreption to your package")]
        [StringLength(40)]
        [Display(Name = "Describe what your customer will get")]
        public string BasicPackageDescreption { get; set; }

        [Required]
        [Display(Name = "Estimated delivery time")]
        public int BasicDeliveryTime { get; set; }

        // ADVANCED PACKAGE
        public int AdvancedPackageID { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public int AdvancedPrice { get; set; }

        [Required(ErrorMessage = "You must give a name to your package")]
        [Display(Name = "Name your Package")]
        public string AdvancedPackageName { get; set; }

        [Required(ErrorMessage = "You must give a Descreption to your package")]
        [StringLength(40)]
        [Display(Name = "Describe what your customer will get")]
        public string AdvancedPackageDescreption { get; set; }

        [Required]
        [Display(Name = "Estimated delivery time")]
        public int AdvancedDeliveryTime { get; set; }

        // PREMIUM PACKAGE
        public int PremiumPackageID { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public int PremiumPrice { get; set; }

        [Required(ErrorMessage = "You must give a name to your package")]
        [Display(Name = "Name your Package")]
        public string PremiumPackageName { get; set; }

        [Required(ErrorMessage = "You must give a Descreption to your package")]
        [StringLength(40)]
        [Display(Name = "Describe what your customer will get")]
        public string PremiumPackageDescreption { get; set; }

        [Required]
        [Display(Name = "Estimated delivery time")]
        public int PremiumDeliveryTime { get; set; }

        //SPECIFIC INDUSTRY
        public int SpecificIndustryID { get; set; }
        public IEnumerable<SpecificIndustry> SpecificIndustries { get; set; }

        //VIEW PROPERTIES
        public string PageName { get; set; }
        public string ButtonName { get; set; }

        public string Action
        {
            get
            {
                Expression<Func<GigController, ActionResult>> update =
                    (c => c.Update(this));
                Expression<Func<GigController, ActionResult>> create =
                    (c => c.Create(this));
                //Expression<Func<GigController, ActionResult>> delete =
                //    (c => c.Delete(this));

                var action = (GigID != 0) ? update : create;
                var actionName = (action.Body as MethodCallExpression).Method.Name;

                return actionName;
            }
        }

        //REFACTORING V1
        public GigFormViewModel()
        {

        }

        private GigFormViewModel(Gig gig, IEnumerable<SpecificIndustry> specificIndustries, string pageName, string buttonName)
        {
            GigID = gig.ID;
            UserRating = gig.UserRating;
            GigName = gig.GigName;
            GigWallpaper = gig.GigWallpaper;
            Descreption = gig.Descreption;
            BasicPackageID = gig.BasicPackageID;
            BasicPrice = gig.BasicPackage.Price;
            BasicPackageName = gig.BasicPackage.PackageName;
            BasicPackageDescreption = gig.BasicPackage.PackageDescreption;
            BasicDeliveryTime = gig.BasicPackage.DeliveryTime;
            AdvancedPackageID = gig.AdvancedPackageID;
            AdvancedPrice = gig.AdvancedPackage.Price;
            AdvancedPackageName = gig.AdvancedPackage.PackageName;
            AdvancedPackageDescreption = gig.AdvancedPackage.PackageDescreption;
            AdvancedDeliveryTime = gig.AdvancedPackage.DeliveryTime;
            PremiumPackageID = gig.PremiumPackageID;
            PremiumPrice = gig.PremiumPackage.Price;
            PremiumPackageName = gig.PremiumPackage.PackageName;
            PremiumPackageDescreption = gig.PremiumPackage.PackageDescreption;
            PremiumDeliveryTime = gig.PremiumPackage.DeliveryTime;
            SpecificIndustryID = gig.SpecificIndustryID;
            SpecificIndustries = specificIndustries;

            //VIEW PROPERTIES
            PageName = pageName;
            ButtonName = buttonName;
        }

        public static GigFormViewModel CreateFormViewModel(Gig gig, IEnumerable<SpecificIndustry> specificIndustries, string pageName, string buttonName)
        {
            if (gig == null)
            {
                var viewModel = new GigFormViewModel()
                {
                    SpecificIndustries = specificIndustries,

                    //VIEW PROPERTIES
                    PageName = pageName,
                    ButtonName = buttonName
                };
                return viewModel;
            }
            else
            {
                var viewModel = new GigFormViewModel(gig, specificIndustries, pageName, buttonName);
                return viewModel;
            }

        }
    }
}