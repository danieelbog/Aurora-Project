using AuroraProject.Controllers;
using AuroraProject.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace AuroraProject.Core.ViewModels
{
    public class InfluencerFormViewModel
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Main Language")]
        public string MainLanguage { get; set; }

        [Required]
        [Display(Name = "Main Media")]
        public string MainPlatform { get; set; }

        [Required]
        public string Exposure { get; set; }

        [Required]
        [Display(Name = "Main Topic")]
        public string MainTopic { get; set; }

        [Required]
        [Display(Name = "Audience Age")]
        public string AudienceAge { get; set; }

        [Required]
        [Display(Name = "Audience Main Origins")]
        public string AudienceMainCountry { get; set; }

        [Display(Name = "Audience Main State")]
        public string AudienceMainState { get; set; }

        [Required]
        [Display(Name = "Audience Main Trait")]
        public string AudienceMainTrait { get; set; }

        [Required]
        [Display(Name = "About Yourself")]
        public string AboutTheInfluencer { get; set; }

        // RELATION WITH MEMBERSHIP TYPE
        [Required(ErrorMessage = "Please pick a membership type")]
        [Display(Name = "Membership Type")]
        public int MembershipTypeID { get; set; }

        [Display(Name = "Membership Type")]
        public IEnumerable<MembershipType> MembershipTypes { get; set; }

        // PROPERTIES FOR VIEW
        public string PageName { get; set; }
        public string ButtonName { get; set; }
        public MembershipType MembershipType { get; set; }
        public string FullName { get; set; }

        // RELATION WITH USER ID
        public string UserID { get; set; }


        // RELATION WITH FILE
        public IEnumerable<FileUpload> FileUploads { get; set; }
        public HttpPostedFileBase upload { get; set; }

        // WHAT ACTION SHOULD RUN IS DECIDED HERE
        public string Action
        {
            get
            {
                Expression<Func<InfluencerController, ActionResult>> update =
                    (c => c.Update(this, upload));
                Expression<Func<InfluencerController, ActionResult>> create =
                    (c => c.Create(this, upload));

                var action = (ID != 0) ? update : create;
                var actionName = (action.Body as MethodCallExpression).Method.Name;

                return actionName;
            }
        }

        public InfluencerFormViewModel()
        {

        }

        private InfluencerFormViewModel(Influencer influencer, IEnumerable<MembershipType> membershipTypes, string pageName, string buttonName, string fullName)
        {
            ID = influencer.ID;
            MainLanguage = influencer.MainLanguage;
            MainPlatform = influencer.MainPlatform;
            Exposure = influencer.Exposure;
            MainTopic = influencer.MainTopic;
            AudienceAge = influencer.AudienceAge;
            AudienceMainCountry = influencer.AudienceMainCountry;
            AudienceMainState = influencer.AudienceMainState;
            AudienceMainTrait = influencer.AudienceMainTrait;
            AboutTheInfluencer = influencer.AboutTheInfluencer;
            MembershipTypeID = influencer.MembershipTypeID;
            MembershipTypes = membershipTypes;
            MembershipType = influencer.MembershipType;
            //UserID = influencer.UserID;

            //VIEW PROPERTIES
            PageName = pageName;
            ButtonName = buttonName;
            FullName = fullName;

            //FILES
            FileUploads = influencer.FileUploads;
        }

        public static InfluencerFormViewModel CreateFormViewModel(Influencer influencer, IEnumerable<MembershipType> membershipTypes, string pageName, string buttonName, string fullName)
        {
            if (influencer == null)
            {
                var viewModel = new InfluencerFormViewModel()
                {
                    MembershipTypes = membershipTypes,

                    //VIEW PROPERTIES
                    PageName = pageName,
                    ButtonName = buttonName,
                    FullName = fullName,
                };
                return viewModel;
            }
            else
            {
                var viewModel = new InfluencerFormViewModel(influencer, membershipTypes, pageName, buttonName, fullName);
                return viewModel;
            }

        }

    }
}