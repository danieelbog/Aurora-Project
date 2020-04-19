using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using AuroraProject.Persistence;
using AuroraProject.Core;
using AuroraProject.Core.ViewModels;
using AuroraProject.Core.Models;

namespace AuroraProject.Controllers
{
    [Authorize]
    public class InfluencerController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        public InfluencerController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        //GET: Influencer
        public ActionResult MineInfluencers()
        {
            var userId = User.Identity.GetUserId();

            // BRING THE INFLUENCERS THAT THE USER HAS FAVOURITED WITH ALL THEIR NEEDED PROPERTIES
            var influencers = unitOfWork.FavouriteInfluencerRepository.GetFavouriteInfluencersWithProperties(userId);

            var viewModel = new InfluencerViewModel(influencers, true, "My Favorite Influencers");

            return View("MineInfluencers", viewModel);
        }


        // GET: Details (MY PROFILE)
        public ActionResult Details()
        {
            var userId = User.Identity.GetUserId();
            var influencer = unitOfWork.InfluencerRepository.GetInfluencerForForm(userId);

            //CHECK IF THE INFLUENCER EXIST
            if (influencer == null)
                return RedirectToAction("Create");
            else
            {
                var viewModel = InfluencerFormViewModel.CreateFormViewModel(influencer, unitOfWork.MembershipTypeRepository.GetMembershipTypes().ToList(), 
                    "My Profile", null, ApplicationUser.FullName(influencer.User));

                return View("MyProfile", viewModel);
            }
        }

        // GET: Create
        public ActionResult Create()
        {
            //GETTING USER ID
            var userId = User.Identity.GetUserId();

            // GETTING THE USER'S INFLUENCER
            var influencer = unitOfWork.InfluencerRepository.GetInfluencerForForm(userId);

            // IF THE INFLUENCER ID IS NULL THEN WE WILL SEND IT TO THE CREATE
            if (influencer == null)
            {
                var viewModel = InfluencerFormViewModel.CreateFormViewModel(influencer, unitOfWork.MembershipTypeRepository.GetMembershipTypes().ToList(), "Add new Influencer", "Add", null);
                return View("InfluencerForm", viewModel);
            }
            // ELSE WE WILL UPLOAD ALL HIS PROPERTIES AND SEND THE VIEW MODEL TO CREATE FOR UPDATE
            else
            {
                var viewModel = InfluencerFormViewModel.CreateFormViewModel(influencer, unitOfWork.MembershipTypeRepository.GetMembershipTypes().ToList(), "Edit Influencer Info", "Update", null);

                return View("InfluencerForm", viewModel);
            }

        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InfluencerFormViewModel viewModel, HttpPostedFileBase upload)
        {
            // BAD SCENARIO IF THE MODEL IS INVALID
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Create");
            }
            
            // GET USER ID AND USER
            var userId = User.Identity.GetUserId();
            var user = unitOfWork.ApplicationUserRepository.GetUser(userId);

            // BRING AURORA WALLET TO ALLOW THE USER PAY US
            var auroraWallet = unitOfWork.AuroraWalletRepository.GetAuroraWallet();
            if (auroraWallet == null)
                return HttpNotFound();

            // THIS TRY CATCH CHECKS IF THE PAYMENT CAN BE DONE, AND IN GENERAL IF SOMETHING GOES WRONG
            try
            {
                //CREATE THE INFLUENCER
                var influencer = Influencer.CreateInflunecerWithPayment(viewModel, user, auroraWallet);

                //IF THERE IS NEW FILE UPLOADED
                if (upload != null && upload.ContentLength > 0)
                {
                    //WE WILL CREATE A NEW FILE WITH THE TYPE OF AVATAR (THIS IS WHAT I NEED HERE)
                    var avatar = FileUpload.GiveInfluencerAvatar(System.IO.Path.GetFileName(upload.FileName), upload.ContentType, null, FileType.Avatar, influencer.ID);

                    //BLACK MAGIC
                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    {
                        avatar.Content = reader.ReadBytes(upload.ContentLength);
                    }

                    // GIVE INFLUENCER THE LIST OF FILES WITH THE AVATAR FILE
                    influencer.FileUploads = new List<FileUpload> { avatar };
                }

                unitOfWork.InfluencerRepository.AddInfluencer(influencer);

                // SAVE CHANGES TO DB
                unitOfWork.Complete();
            }
            catch (Exception)
            {
                // HERE YOU CAN ADD THE SAME PAGE WITH A NEW VIEW PROPERTY TO DISPLAY THAT THE PAYMENT COULDNT BE DONE
                return RedirectToAction("Create");
            }

            // REDIRECT TO ADD A GIG (USER EXPIRIENCE)
            return RedirectToAction("Create", "Gig", null);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Update(InfluencerFormViewModel viewModel, HttpPostedFileBase upload)
        {
            // GET THE USER ID TO USE IT LATER
            var userId = User.Identity.GetUserId();

            // BRING THE INFLUENCER FOR EDIT
            var influencerDb = unitOfWork.InfluencerRepository.GetInfluencerForUpdate(viewModel.ID);

            // CHECK IF THE INFLUENCER EXIST
            if (influencerDb == null)
                return HttpNotFound();

            if(influencerDb.User.Id != userId)
                return new HttpUnauthorizedResult();

            // BRING AURORA WALLET FOR RETURNING MONEY TO USER AND GETTING OUR CUT IF NEEDED
            var auroraWallet = unitOfWork.AuroraWalletRepository.GetAuroraWallet();
            if (auroraWallet == null)
                return HttpNotFound();

            // THIS TRY CATCH CHECKS IF THE PAYMENT CAN BE DONE, AND IN GENERAL IF SOMETHING GOES WRONG
            try
            {
                influencerDb.Modify(viewModel, influencerDb, auroraWallet);

                // IF THERE IS MEW FILE UPLOADED THEN WE WILL DELETE THE INFLUENCER FILE FOR AVATAR FROM HIS FILES
                if (upload != null && upload.ContentLength > 0)
                {
                    if (influencerDb.FileUploads.Any(f => f.FileType == FileType.Avatar))
                        unitOfWork.FileUploadRepository.RemoveGigAvatarFileUpload(influencerDb);

                    // THEN WE WILL CREATE NEW FILE AND GIVE IT TO THE USER
                    var avatar = FileUpload.GiveInfluencerAvatar(System.IO.Path.GetFileName(upload.FileName), upload.ContentType, null, FileType.Avatar, influencerDb.ID);

                    // BLACK MAGIC
                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    {
                        avatar.Content = reader.ReadBytes(upload.ContentLength);
                    }

                    // WE ADD THE LIST WITH THE NEW AVATAR FILE TO THE INFLUENCER LIST
                    influencerDb.FileUploads = new List<FileUpload> { avatar };
                }

            }
            catch (Exception)
            {
                return RedirectToAction("Update", viewModel);
            }

            // SAVE CHANGES TO DB
            unitOfWork.Complete();

            // REDIRECT TO ADD A GIG (USER EXPIRIENCE)
            return RedirectToAction("Create", "Gig", null);
        }
    }
}