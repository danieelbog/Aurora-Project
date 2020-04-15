using AuroraProject.Core.DTO;
using AuroraProject.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuroraProject.Core.Models
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

        //RELATION WITH FILE - UPLOADING IMAGES ETC
        public ICollection<FileUpload> FileUploads { get; set; }


        protected Influencer()
        {
            Followers = new Collection<FavouriteInfluencer>();
        }

        private Influencer(InfluencerFormViewModel viewModel, ApplicationUser user)
        {
            AboutTheInfluencer = viewModel.AboutTheInfluencer;
            AudienceAge = viewModel.AudienceAge;
            AudienceMainCountry = viewModel.AudienceMainCountry;
            AudienceMainState = viewModel.AudienceMainState;
            AudienceMainTrait = viewModel.AudienceMainTrait;
            Exposure = viewModel.Exposure;
            MainLanguage = viewModel.MainLanguage;
            MainTopic = viewModel.MainTopic;
            MembershipTypeID = viewModel.MembershipTypeID;
            MainPlatform = viewModel.MainPlatform;
            Followers = new Collection<FavouriteInfluencer>();
            //UserID = user.Id;
            User = user;
        }

        public static Influencer CreateInflunecerWithPayment(InfluencerFormViewModel viewModel, ApplicationUser user, AuroraWallet auroraWallet)
        {
            var influencer = new Influencer(viewModel, user);
            user.Influencer = influencer;

            MembershipType.SellMembershipType(user, viewModel.MembershipTypeID, auroraWallet);

            return influencer;
        }

        public void Modify(InfluencerFormViewModel updatedViewModel, Influencer oldInfluencer, AuroraWallet auroraWallet)
        {
            if (oldInfluencer.MembershipTypeID != updatedViewModel.MembershipTypeID)
                MembershipType.ModifyMembershipType(oldInfluencer.User, oldInfluencer.MembershipTypeID, updatedViewModel.MembershipTypeID, auroraWallet);

            AboutTheInfluencer = updatedViewModel.AboutTheInfluencer;
            AudienceAge = updatedViewModel.AudienceAge;
            AudienceMainCountry = updatedViewModel.AudienceMainCountry;
            AudienceMainState = updatedViewModel.AudienceMainState;
            AudienceMainTrait = updatedViewModel.AudienceMainTrait;
            Exposure = updatedViewModel.Exposure;
            MainLanguage = updatedViewModel.MainLanguage;
            MainTopic = updatedViewModel.MainTopic;
            MembershipTypeID = updatedViewModel.MembershipTypeID;
            MainPlatform = updatedViewModel.MainPlatform;
        }

        public void Modify(InfluencerDto influencerDto, Influencer oldInfluencer, AuroraWallet auroraWallet)
        {
            if (oldInfluencer.MembershipTypeID != influencerDto.MembershipTypeID)
                MembershipType.ModifyMembershipType(oldInfluencer.User, oldInfluencer.MembershipTypeID, influencerDto.MembershipTypeID, auroraWallet);

            AboutTheInfluencer = influencerDto.AboutTheInfluencer;
            AudienceAge = influencerDto.AudienceAge;
            AudienceMainCountry = influencerDto.AudienceMainCountry;
            AudienceMainState = influencerDto.AudienceMainState;
            AudienceMainTrait = influencerDto.AudienceMainTrait;
            Exposure = influencerDto.Exposure;
            MainLanguage = influencerDto.MainLanguage;
            MainTopic = influencerDto.MainTopic;
            MembershipTypeID = influencerDto.MembershipTypeID;
            MainPlatform = influencerDto.MainPlatform;
        }
    }
}